using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CognitiveComplexity

namespace BalancedSearchTree
{
    /// <summary>
    ///     2-3 树。
    /// </summary>
    /// <typeparam name="TKey">键。</typeparam>
    /// <typeparam name="TValue">值。</typeparam>
    public class TwoThreeBst<TKey, TValue> : IOrderedSt<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        private int _count;
        private Node _root;

        /// <inheritdoc />
        public void Put(TKey key, TValue value)
        {
            if (_root == null)
            {
                _root = new Node(null);
                _root.AddPair(key, value);
                return;
            }

            var (ends, current, _) = Get(null, _root, key);
            if (current != null)
                throw new InvalidOperationException($"The Key {key} has already been added");

            ends.AddPair(key, value);
            _root = BalanceBottomUp(ends);
            _count++;
        }

        /// <inheritdoc />
        public TValue Get(TKey key)
        {
            if (_root == null)
                return default;

            var (_, node, index) = Get(null, _root, key);
            if (node == null)
                return default;

            return node.Contents[index].Value;
        }

        /// <inheritdoc />
        public void Delete(TKey key)
        {
            var (parent, node, index) = Get(null, _root, key);
            if (node == null)
            {
                throw new InvalidOperationException("trying to delete a key not exists");
            }

            var pairToRemove = node.Contents[index];
            if (node.IsLeaf())
            {
                if (parent == null)
                {
                    // root node
                    node.Contents.Remove(pairToRemove);
                    if (node.Contents.Count == 0)
                    {
                        _root = null;
                    }

                    _count--;
                    return;
                }
                
                if (node.Degree == 2)
                {
                    // node is 2-node, make it 3 or 4
                    // find sibling
                    Node sibling;
                    if (node == parent.Left)
                    {
                        sibling = parent.Children[1];
                    }
                    else if (node == parent.Right)
                    {
                        sibling = parent.Children[^2];
                    }
                    else
                    {
                        sibling = parent.Left.Degree > parent.Right.Degree ? parent.Left : parent.Right;
                    }

                    if (sibling.Degree == 2)
                    {
                        node = Merge(node, sibling);
                    }
                    else
                    {
                        node = Redistribution(node, sibling);
                    }
                }

                // now node is not 2-node, direct remove
                node.Contents.Remove(pairToRemove);
                // all children is null, just delete last one
                node.Children.RemoveAt(node.Degree - 1);
                _count--;
                return;
            }

            var min = Min(node.Right);
            var t = node.Contents[index];
            node.Contents[index] = min.Contents[0];
            min.Contents[0] = t;
            node.Right = DeleteMin(node.Right);
            _count--;
        }

        /// <inheritdoc />
        public bool Contains(TKey key)
        {
            return Get(null, _root, key).Node != null;
        }

        /// <inheritdoc />
        public bool IsEmpty()
        {
            return _root == null;
        }

        /// <inheritdoc />
        public int Size()
        {
            return _count;
        }

        private int Size(Node x)
        {
            if (x == null)
            {
                return 0;
            }
            
            if (x.Degree == 2)
            {
                return 1 + Size(x.Left) + Size(x.Right);
            }

            return 2 + Size(x.Left) + Size(x.Middle) + Size(x.Right);
        }

        /// <inheritdoc />
        public IEnumerable<TKey> Keys()
        {
            if (IsEmpty())
            {
                return new List<TKey>();
            }

            return Keys(Min(), Max());
        }

        /// <inheritdoc />
        public int Size(TKey lo, TKey hi)
        {
            if (lo == null)
            {
                throw new ArgumentNullException(nameof(lo), "first argument to Size() is null");
            }

            if (hi == null)
            {
                throw new ArgumentNullException(nameof(hi), "second argument to Size() is null");
            }

            if (lo.CompareTo(hi) > 0)
            {
                return 0;
            }

            if (Contains(hi))
            {
                return Rank(hi) - Rank(lo) + 1;
            }

            return Rank(hi) - Rank(lo);
        }

        /// <inheritdoc />
        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            if (lo == null)
            {
                throw new ArgumentNullException(nameof(lo), "first argument to Keys() is null");
            }

            if (hi == null)
            {
                throw new ArgumentNullException(nameof(hi), "second argument to Keys() is null");
            }

            var queue = new Queue<TKey>();
            Keys(_root, queue, lo, hi);
            return queue;
        }

        private void Keys(Node x, Queue<TKey> queue, TKey lo, TKey hi)
        {
            if (x == null)
            {
                return;
            }

            var cmpLo = lo.CompareTo(x.Contents[0].Key);
            var cmpHi = hi.CompareTo(x.Contents[0].Key);
            if (cmpLo < 0)
            {
                Keys(x.Left, queue, lo, hi);
            }

            if (cmpLo <= 0 && cmpHi >= 0)
            {
                queue.Enqueue(x.Contents[0].Key);
            }

            if (cmpHi > 0)
            {
                Keys(x.Children[1], queue, lo, hi);
            }

            // 3-node extra
            if (x.Children.Count == 3)
            {
                cmpLo = lo.CompareTo(x.Contents[1].Key);
                cmpHi = hi.CompareTo(x.Contents[1].Key);
                if (cmpLo < 0)
                {
                    Keys(x.Middle, queue, lo, hi);
                }

                if (cmpLo <= 0 && cmpHi >= 0)
                {
                    queue.Enqueue(x.Contents[1].Key);
                }

                if (cmpHi > 0)
                {
                    Keys(x.Right, queue, lo, hi);
                } 
            }
        }

        /// <inheritdoc />
        public TKey Min()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("BST is empty");
            }

            return Min(_root).Contents[0].Key;
        }

        private Node Min(Node h)
        {
            if (h.Left == null)
            {
                return h;
            }

            return Min(h.Left);
        }

        /// <inheritdoc />
        public TKey Max()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("BST is empty");
            }

            return Max(_root).Contents[^1].Key;
        }

        private Node Max(Node h)
        {
            if (h.Right == null)
            {
                return h;
            }

            return Max(h.Right);
        }

        /// <inheritdoc />
        public TKey Floor(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), "argument to Floor() is null");
            }

            if (IsEmpty())
            {
                throw new InvalidOperationException("calls Floor() with empty symbol table");
            }

            var x = Floor(_root, key);
            if (x == null)
            {
                throw new InvalidOperationException("argument to Floor() is too small");
            }

            return x.Contents[0].Key;
        }

        private Node Floor(Node x, TKey key)
        {
            if (x == null)
            {
                return null;
            }

            var cmp = key.CompareTo(x.Contents[0].Key);
            if (cmp == 0)
            {
                return x;
            }

            if (cmp < 0)
            {
                return Floor(x.Left, key);
            }

            if (x.Degree == 3)
            {
                cmp = key.CompareTo(x.Contents[1].Key);
                if (cmp == 0)
                {
                    return x;
                }

                if (cmp < 0)
                {
                    return Floor(x.Middle, key);
                }
            }
            
            var t = Floor(x.Right, key);
            if (t != null)
            {
                return t;
            }

            return x;
        }

        /// <inheritdoc />
        public TKey Ceiling(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), "argument to Ceiling() is null");
            }

            if (IsEmpty())
            {
                throw new InvalidOperationException("calls Ceiling with empty symbol table");
            }

            var x = Ceiling(_root, key);
            if (x == null)
            {
                throw new InvalidOperationException("argument to Ceiling is too small");
            }

            return x.Contents[^1].Key;
        }

        private Node Ceiling(Node x, TKey key)
        {
            if (x == null)
            {
                return null;
            }

            var cmp = key.CompareTo(x.Contents[0].Key);
            if (cmp == 0)
            {
                return x;
            }

            if (cmp > 0)
            {
                return Ceiling(x.Right, key);
            }

            if (x.Degree == 3)
            {
                cmp = key.CompareTo(x.Contents[1].Key);
                if (cmp == 0)
                {
                    return x;
                }

                if (cmp > 0)
                {
                    return Ceiling(x.Right, key);
                }
            }

            var t = Ceiling(x.Left, key);
            if (t != null)
            {
                return t;
            }

            return x;
        }


        /// <inheritdoc />
        public int Rank(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), "argument to Rank() is null");
            }

            return Rank(_root, key);
        }

        private int Rank(Node x, TKey key)
        {
            if (x == null)
            {
                return 0;
            }

            var cmp = key.CompareTo(x.Contents[0].Key);
            if (cmp < 0)
            {
                return Rank(x.Left, key);
            }
            if (cmp > 0)
            {
                if (x.Degree == 2)
                {
                    return 1 + Size(x.Left) + Rank(x.Right, key);
                }

                cmp = key.CompareTo(x.Contents[1].Key);
                if (cmp < 0)
                {
                    return 1 + Size(x.Left) + Rank(x.Right, key); 
                }

                if (cmp > 0)
                {
                    return 1 + Size(x.Left) + Size(x.Middle) + Rank(x.Right, key);
                }

                return Size(x.Left) + Size(x.Middle);
            }

            return Size(x.Left);
        }

        /// <inheritdoc />
        public TKey Select(int k)
        {
            if (k < 0 || k >= Size())
            {
                throw new ArgumentOutOfRangeException(nameof(k), "argument to Select() is invalid " + k);
            }

            return Select(_root, k);
        }

        private TKey Select(Node x, int rank)
        {
            if (x == null)
            {
                return default;
            }

            var leftSize = Size(x.Left);
            if (leftSize > rank)
            {
                return Select(x.Left, rank);
            }

            if (leftSize < rank)
            {
                if (x.Degree == 3)
                {
                    leftSize += Size(x.Middle);
                    if (leftSize > rank)
                    {
                        return Select(x.Middle, rank - leftSize - 1);
                    }

                    if (leftSize == rank)
                    {
                        return x.Contents[1].Key;
                    }
                }
                
                return Select(x.Right, rank - leftSize - 1);
            }
            
            return x.Contents[0].Key;
        }

        /// <inheritdoc />
        public void DeleteMin()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("BST underflow");
            }

            _root = DeleteMin(_root);
        }

        private Node DeleteMin(Node x)
        {
            if (x.Left == null)
            {
                // remove left key
                x.Contents.RemoveAt(0);
                x.Children.RemoveAt(0);
                return BalanceBottomUp(x);
            }

            if (x.Left.Degree != 2)
            {
                // left child is not 2-node, do nothing and turn left
                return DeleteMin(x.Left);
            }
            
            if (x.Children[1].Degree > 2)
            {
                // sibling is not 2-node, borrow one key into left
                
                // get key from parent
                x.Left.AddPair(x.Contents[0]);
                // parent get key from sibling
                x.Contents.RemoveAt(0);
                x.Contents.Insert(0, x.Children[1].Contents[0]);
                // sibling delete min key
                x.Children[1].Contents.RemoveAt(0);
                // move sibling's child to left's child
                x.Left.Children.Add(x.Children[1].Left);
                x.Children[1].Children.RemoveAt(0);

                return DeleteMin(x.Left);
            }
            
            // sibling is 2-node, merge them into 3-node
            if (x.Degree == 2)
            {
                // current node and its children are all 2-node
                x.AddPair(x.Left.Contents[0]);
                x.AddPair(x.Right.Contents[0]);
                x.Left.Children.ForEach(c => c.Parent = x);
                x.Right.Children.ForEach(c => c.Parent = x);
                var t = x.Left;
                x.Left = t.Left;
                x.MiddleLeft = t.Right;
                t = x.Right;
                x.MiddleRight = t.Left;
                x.Right = t.Right;
                return DeleteMin(x);
            }
            
            x.Left.AddPair(x.Contents[0]);
            x.Contents.RemoveAt(0);
            x.Left.AddPair(x.Children[1].Contents[0]);
            x.Left.MiddleRight = x.Children[1].Left;
            x.Left.Right = x.Children[1].Right;
            x.Children.RemoveAt(1);
            return DeleteMin(x.Left);
        }

        /// <inheritdoc />
        public void DeleteMax()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("BST is empty");
            }

            _root = DeleteMax(_root);
        }

        private Node DeleteMax(Node x)
        {
            if (x.Right == null)
            {
                // remove right key
                x.Contents.RemoveAt(x.Contents.Count - 1);
                x.Children.RemoveAt(x.Degree - 1);
                return BalanceBottomUp(x);
            }

            if (x.Right.Degree != 2)
            {
                // left child is not 2-node, do nothing and turn left
                return DeleteMax(x.Right);
            }
            
            if (x.Children[^2].Degree > 2)
            {
                // sibling is not 2-node, borrow one key into left
                
                // get key from parent
                x.Right.AddPair(x.Contents[^1]);
                // parent get key from sibling
                x.Contents.RemoveAt(x.Contents.Count - 1);
                x.Contents.Insert(x.Contents.Count - 1, x.Children[^2].Contents[^1]);
                // sibling delete max key
                x.Children[^2].Contents.RemoveAt(x.Children[^2].Contents.Count - 1);
                // move sibling's child to right's child
                x.Right.Children.Add(x.Children[^2].Right);
                x.Children[^2].Children.RemoveAt(x.Children[^2].Degree - 1);

                return DeleteMax(x.Right);
            }
            
            // sibling is 2-node, merge them into 3-node
            if (x.Degree == 2)
            {
                // current node and its children are all 2-node
                x.AddPair(x.Left.Contents[0]);
                x.AddPair(x.Right.Contents[0]);
                x.Left.Children.ForEach(c => c.Parent = x);
                x.Right.Children.ForEach(c => c.Parent = x);
                var t = x.Left;
                x.Left = t.Left;
                x.MiddleLeft = t.Right;
                t = x.Right;
                x.MiddleRight = t.Left;
                x.Right = t.Right;
                return DeleteMax(x);
            }
            
            x.Right.AddPair(x.Contents[^1]);
            x.Contents.RemoveAt(x.Contents.Count - 1);
            x.Right.AddPair(x.Children[^2].Contents[^1]);
            x.Left.MiddleRight = x.Children[^2].Left;
            x.Left.Right = x.Children[^2].Right;
            x.Children.RemoveAt(x.Degree - 2);
            return DeleteMax(x.Right);
        }

        private static Node BalanceBottomUp(Node node)
        {
            if (node.Degree != 4)
            {
                // not 4-node
                return BalanceBottomUp(node.Parent);
            }

            // break 4-node into 2 2-node
            var left = new Node(node.Parent);
            left.AddPair(node.Contents[0]);
            left.Left = node.Left;
            left.Right = node.MiddleLeft;

            var right = new Node(node.Parent);
            right.AddPair(node.Contents[2]);
            right.Left = node.MiddleRight;
            right.Right = node.Right;

            if (node.Parent == null)
            {
                // root is 4-node
                var root = new Node(null);
                root.AddPair(node.Contents[1]);
                root.Left = left;
                root.Right = right;
                left.Parent = root;
                right.Parent = root;
                return root;
            }

            node.Parent.AddPair(node.Contents[1]);
            if (node.Parent.Degree == 2)
            {
                // parent is 2-node
                if (node == node.Parent.Children[0])
                {
                    // 4-node is 2-node's left child
                    node.Parent.Left = left;
                    node.Parent.Middle = right;
                }
                else
                {
                    // 4-node is 2-node's right child
                    node.Parent.Middle = left;
                    node.Parent.Right = right;
                }

                return BalanceBottomUp(node.Parent);
            }

            // parent is 3-node
            if (node == node.Parent.Children[0])
            {
                // 4-node is 3-node's left child
                node.Parent.Left = left;
                node.Parent.MiddleLeft = right;
            }
            else if (node == node.Parent.Children[1])
            {
                // 4-node is 3-node's middle child
                node.Parent.MiddleLeft = left;
                node.Parent.MiddleRight = right;
            }
            else
            {
                // 4-node is 3-node's right child
                node.Parent.MiddleRight = left;
                node.Parent.Right = right;
            }

            return BalanceBottomUp(node.Parent);
        }

        private static (Node Parent, Node Node, int Index) Get(Node parent, Node current, TKey key)
        {
            if (current == null)
                return (parent, null, -1);

            for (var i = 0; i < current.Contents.Count; i++)
            {
                var pair = current.Contents[i];
                var cmp = key.CompareTo(pair.Key);
                if (cmp == 0)
                    return (parent, current, i);

                if (cmp < 0)
                    return Get(current, current.Children[i], key);
            }

            // larger to all keys, turn right
            return Get(current, current.Children[^1], key);
        }

        private static Node Merge(Node x, Node y)
        {
            if (x.Degree != 2 || y.Degree != 2)
            {
                throw new InvalidOperationException("x and y must all be 2-node to merge");
            }

            if (x.Parent != y.Parent)
            {
                throw new InvalidOperationException("two nodes must be siblings to perform merge");
            }

            var parent = x.Parent;
            if (parent.Degree == 2)
            {
                parent.AddPair(x.Contents[0]);
                parent.AddPair(y.Contents[0]);
                parent.Left = x.Left;
                parent.MiddleLeft = x.Right;
                parent.MiddleRight = y.Left;
                parent.Right = y.Right;
                return parent; 
            }

            if (x == parent.Left || y == parent.Left)
            {
                // merge middle to left
                x = parent.Left;
                y = parent.Middle;

                x.AddPair(parent.Contents[0]);
                x.AddPair(y.Contents[0]);
                x.MiddleRight = y.Left;
                x.Right = y.Right;
                parent.Contents.RemoveAt(0);
                parent.Children.Remove(y);
                return parent;
            }
            
            // merge middle to right
            x = parent.Middle;
            y = parent.Right;
            
            y.AddPair(parent.Contents[^1]);
            y.AddPair(x.Contents[0]);
            y.Left = x.Left;
            y.MiddleLeft = x.Right;
            parent.Contents.RemoveAt(parent.Contents.Count - 1);
            parent.Children.Remove(x);

            return parent;
        }

        private static Node Redistribution(Node node, Node sibling)
        {
            if (node.Degree != 2 || sibling.Degree == 2)
            {
                throw new InvalidOperationException("node must be 2-node and sibling must not be 2-node");
            }

            if (node.Parent != sibling.Parent)
            {
                throw new InvalidOperationException("two nodes must be siblings to perform merge");
            }

            var parent = node.Parent;
            if (node == parent.Left)
            {
                // flow to left
                node.AddPair(parent.Contents[0]);
                node.Right = sibling.Left;
                parent.Contents[0] = sibling.Contents[0];
                sibling.Contents.RemoveAt(0);
                sibling.Children.RemoveAt(0);
            }
            else if (node == parent.Right)
            {
                // flow to right
                node.AddPair(parent.Contents[^1]);
                node.Left = sibling.Right;
                parent.Contents[^1] = sibling.Contents[^1];
                sibling.Contents.RemoveAt(sibling.Contents.Count - 1);
                sibling.Children.RemoveAt(sibling.Children.Count - 1);
            }
            else
            {
                // flow to middle
                if (sibling == parent.Left)
                {
                    node.AddPair(parent.Contents[0]);
                    parent.Contents[0] = sibling.Contents[^1];
                    node.Children[0] = sibling.Right;
                    sibling.Contents.RemoveAt(sibling.Contents.Count - 1);
                    sibling.Children.RemoveAt(sibling.Children.Count - 1);
                }
                else
                {
                    node.AddPair(parent.Contents[^1]);
                    parent.Contents[^1] = sibling.Contents[0];
                    node.Children[^1] = sibling.Left;
                    sibling.Contents.RemoveAt(0);
                    sibling.Children.RemoveAt(0);
                }
            }

            return node;
        }

        private class Node
        {
            public Node(Node parent)
            {
                Parent = parent;
            }

            public Node Parent { get; set; }
            
            public List<Pair> Contents { get; } = new();
            
            public List<Node> Children { get; } = new() { null };

            public int Degree => Children.Count;

            public Node Left
            {
                get => Children[0];
                set => Children[0] = value;
            }

            public Node MiddleLeft
            {
                get
                    => Degree == 4
                        ? Children[1]
                        : throw new InvalidOperationException("only 4-node has middle left");
                set => Children[1] = value;
            }
            
            public Node Middle
            {
                get
                    => Degree == 3
                        ? Children[1]
                        : throw new InvalidOperationException("only 3-node has middle");
                set => Children[1] = value;
            }

            public Node MiddleRight
            {
                get
                    => Degree == 4
                        ? Children[2]
                        : throw new InvalidOperationException("only 4-node has middle right");
                set => Children[2] = value;
            }

            public Node Right
            {
                get => Children[^1];
                set => Children[^1] = value;
            }

            public void AddPair(TKey key, TValue value)
            {
                var pair = new Pair(key, value);
                AddPair(pair);
            }

            public void AddPair(Pair pair)
            {
                for (var i = 0; i < Contents.Count; i++)
                {
                    var cmp = pair.Key.CompareTo(Contents[i].Key);
                    if (cmp < 0)
                    {
                        Contents.Insert(i, pair);
                        Children.Insert(i + 1, null);
                        return;
                    }
                }

                Contents.Add(pair);
                Children.Add(null);
            }

            public bool IsLeaf()
            {
                return Children.All(c => c == null);
            }
        }

        private class Pair
        {
            public Pair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key { get; }
            public TValue Value { get; }
        }
    }
}