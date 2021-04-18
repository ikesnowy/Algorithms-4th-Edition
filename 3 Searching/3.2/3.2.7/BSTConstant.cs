using System;
using System.Collections.Generic;
using System.Text;
using BinarySearchTree;

namespace _3._2._7
{
    public class BSTConstant<TKey, TValue> : IST<TKey, TValue>, IOrderedST<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 二叉查找树的根结点。
        /// </summary>
        private Node root;

        /// <summary>
        /// 二叉树结点类型。
        /// </summary>
        private class Node
        {
            /// <summary>
            /// 键值对中的键。
            /// </summary>
            /// <value>
            /// 键。
            /// </value>
            public TKey Key { get; set; }
            /// <summary>
            /// 键值对中的值。
            /// </summary>
            /// <value>值。</value>
            public TValue Value { get; set; }
            /// <summary>
            /// 左子树的引用。
            /// </summary>
            /// <value>左子树的引用。</value>
            public Node Left { get; set; }
            /// <summary>
            /// 右子树的引用。
            /// </summary>
            /// <value>右子树的引用。</value>
            public Node Right { get; set; }
            /// <summary>
            /// 子树的结点数量。
            /// </summary>
            /// <value>子树的结点数量。</value>
            public int Size { get; set; }
            /// <summary>
            /// 当前结点左右子树的深度和。
            /// </summary>
            public int DepthSum { get; set; }
            /// <summary>
            /// 构造一个二叉树结点。
            /// </summary>
            /// <param name="key">键。</param>
            /// <param name="value">值。</param>
            /// <param name="size">子树大小。</param>
            /// <param name="depth">结点的深度。</param>
            public Node(TKey key, TValue value, int size, int depth)
            {
                Key = key;
                Value = value;
                Size = size;
                DepthSum = depth;
                Left = null;
                Right = null;
            }
        }

        public int AverageCompares() => root.DepthSum / Size() + 1;

        /// <summary>
        /// 向二叉查找树中插入一个键值对。
        /// </summary>
        /// <param name="key">要插入的键。</param>
        /// <param name="value">要插入的值。</param>
        public void Put(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("calls Put() with a null key");
            if (value == null)
            {
                Delete(key);
                return;
            }
            root = Put(root, key, value, 0);
        }

        /// <summary>
        /// 向二叉查找树中插入一个键值对，返回插入后的根结点。
        /// </summary>
        /// <param name="x">要插入结点的二叉查找树的根结点。</param>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        /// <param name="depth">当前深度。</param>
        /// <returns>插入结点后的根结点。</returns>
        private Node Put(Node x, TKey key, TValue value, int depth)
        {
            if (x == null)
                return new Node(key, value, 1, depth);
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Put(x.Left, key, value, depth + 1);
            else if (cmp > 0)
                x.Right = Put(x.Right, key, value, depth + 1);
            else
                x.Value = value;
            x.Size = 1 + Size(x.Left) + Size(x.Right);
            x.DepthSum = depth;
            if (x.Left != null)
                x.DepthSum += x.Left.DepthSum;
            if (x.Right != null)
                x.DepthSum += x.Right.DepthSum;
            return x;
        }

        /// <summary>
        /// 获得 <paramref name="key"/> 对应的值，不存在则返回 <c>default(TValue)</c>。
        /// </summary>
        /// <param name="key">需要查找的键。</param>
        /// <returns>找到的值，不存在则返回 <c>default(TValue)</c>。</returns>
        public TValue Get(TKey key) => Get(root, key);

        /// <summary>
        /// 递归查找 <paramref name="key"/> 所对应的值。
        /// </summary>
        /// <param name="x">要查找的根结点。</param>
        /// <param name="key">要查找的键。</param>
        /// <returns>如果存在则返回对应的值，否则返回 <c>default(TValue)</c>。</returns>
        private TValue Get(Node x, TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("calls get() with a null key");
            if (x == null)
                return default;
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Get(x.Left, key);
            else if (cmp > 0)
                return Get(x.Right, key);
            else
                return x.Value;
        }

        /// <summary>
        /// 删除含有某个键的结点。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
        public void Delete(TKey key)
        {
            if (key == null)
                throw new InvalidOperationException("Symbol Table Underflow");
            root = Delete(root, key);
        }

        /// <summary>
        /// 从二叉查找树中删除键为 <paramref name="key"/> 的结点。
        /// </summary>
        /// <param name="x">要删除的结点的二叉查找树。</param>
        /// <param name="key">要删除的键。</param>
        /// <returns>删除结点后的二叉查找树。</returns>
        private Node Delete(Node x, TKey key)
        {
            if (x == null)
                return null;

            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Delete(x.Left, key);
            else if (cmp > 0)
                x.Right = Delete(x.Right, key);
            else
            {
                if (x.Right == null)
                    return x.Left;
                if (x.Left == null)
                    return x.Right;
                var t = x;
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }
            x.Size = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        /// <summary>
        /// 检查二叉查找树是否含有 <paramref name="key"/>。
        /// </summary>
        /// <param name="key">要查找的键值。</param>
        /// <returns>如果含有则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Contains is null!");
            return Get(key) != null;
        }

        /// <summary>
        /// 二叉查找树是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => Size(root) == 0;

        /// <summary>
        /// 获取二叉查找树的结点数量。
        /// </summary>
        /// <returns>二叉查找树的结点数量。</returns>
        public int Size() => Size(root);

        /// <summary>
        /// 获取某个结点为根的二叉树结点数量。
        /// </summary>
        /// <param name="x">根结点。</param>
        /// <returns>以 <paramref name="x"/> 为根的二叉树的结点数量。</returns>
        private int Size(Node x)
        {
            if (x == null)
                return 0;
            return x.Size;
        }

        /// <summary>
        /// 获取符号表中键在 <paramref name="lo"/> 和 <paramref name="hi"/> 之间的键的数目。
        /// </summary>
        /// <param name="lo">键的下限。</param>
        /// <param name="hi">键的上限。</param>
        /// <returns><paramref name="lo"/> 和 <paramref name="hi"/> 之间键的数目。</returns>
        public int Size(TKey lo, TKey hi)
        {
            if (lo == null)
                throw new ArgumentNullException("first argument to Size() is null");
            if (hi == null)
                throw new ArgumentNullException("second argument to Size() is null");

            if (lo.CompareTo(hi) > 0)
                return 0;
            if (Contains(hi))
                return Rank(hi) - Rank(lo) + 1;
            else
                return Rank(hi) - Rank(lo);
        }

        /// <summary>
        /// 获得符号表全部的键。
        /// </summary>
        /// <returns>符号表全部的键。</returns>
        public IEnumerable<TKey> Keys()
        {
            if (IsEmpty())
                return new List<TKey>();
            return Keys(Min(), Max());
        }

        /// <summary>
        /// 获取符号表中指定键之间的全部键。
        /// </summary>
        /// <param name="lo">键的下限。</param>
        /// <param name="hi">键的上限。</param>
        /// <returns>包含 <paramref name="lo"/> 和 <paramref name="hi"/> 及其之间的所有键。</returns>
        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            if (lo == null)
                throw new ArgumentNullException("first argument to keys() is null");
            if (hi == null)
                throw new ArgumentNullException("second argument to keys() is null");

            var queue = new Queue<TKey>();
            Keys(root, queue, lo, hi);
            return queue;
        }

        /// <summary>
        /// 获取二叉查找树中在 <paramref name="lo"/> 和 <paramref name="hi"/> 之间的所有键。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="queue">要填充的队列。</param>
        /// <param name="lo">键的下限。</param>
        /// <param name="hi">键的上限。</param>
        private void Keys(Node x, Queue<TKey> queue, TKey lo, TKey hi)
        {
            if (x == null)
                return;
            var cmplo = lo.CompareTo(x.Key);
            var cmphi = hi.CompareTo(x.Key);
            if (cmplo < 0)
                Keys(x.Left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0)
                queue.Enqueue(x.Key);
            if (cmphi > 0)
                Keys(x.Right, queue, lo, hi);
        }

        /// <summary>
        /// 查找二叉查找树中的最小的键。
        /// </summary>
        /// <returns>二叉查找树中最小的键。</returns>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
        public TKey Min()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Symbol Table Underflow");
            return Min(root).Key;
        }

        /// <summary>
        /// 在二叉查找树中查找包含最小键的结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>包含最小键的结点。</returns>
        private Node Min(Node x)
        {
            if (x.Left == null)
                return x;
            return Min(x.Left);
        }

        /// <summary>
        /// 查找二叉查找树中的最大的键。
        /// </summary>
        /// <returns>二叉查找树中最大的键。</returns>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
        public TKey Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Symbol Table Underflow");
            return Max(root).Key;
        }

        /// <summary>
        /// 在二叉查找树中查找包含最大键的结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>包含最大键的结点。</returns>
        private Node Max(Node x)
        {
            if (x.Right == null)
                return x;
            return Max(x.Right);
        }

        /// <summary>
        /// 获得符号表中小于等于 <paramref name="key"/> 的最大键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>小于等于 <paramref name="key"/> 的最大键。</returns>
        public TKey Floor(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to floor is null");
            if (IsEmpty())
                throw new InvalidOperationException("calls floor with empty symbol table");
            var x = Floor(root, key);
            if (x == null)
                return default;
            else
                return x.Key;
        }

        /// <summary>
        /// 获得符号表中小于等于 <paramref name="key"/> 的最大结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">键。</param>
        /// <returns>小于等于 <paramref name="key"/> 的最大结点。</returns>
        private Node Floor(Node x, TKey key)
        {
            if (x == null)
                return null;
            var cmp = key.CompareTo(x.Key);
            if (cmp == 0)
                return x;
            else if (cmp < 0)
                return Floor(x.Left, key);
            var t = Floor(x.Right, key);
            if (t != null)
                return t;
            else
                return x;
        }

        /// <summary>
        /// 获取符号表中大于等于 <paramref name="key"/> 的最小键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>大于等于 <paramref name="key"/> 的最小键。</returns>
        public TKey Ceiling(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to ceiling is null");
            if (IsEmpty())
                throw new InvalidOperationException("calls ceiling with empty symbol table");
            var x = Ceiling(root, key);
            if (x == null)
                return default;
            return x.Key;
        }

        /// <summary>
        /// 获取符号表中大于等于 <paramref name="key"/> 的最小结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">键。</param>
        /// <returns>符号表中大于等于 <paramref name="key"/> 的最小结点。</returns>
        private Node Ceiling(Node x, TKey key)
        {
            if (x == null)
                return null;
            var cmp = key.CompareTo(x.Key);
            if (cmp == 0)
                return x;
            if (cmp < 0)
            {
                var t = Ceiling(x.Left, key);
                if (t != null)
                    return t;
                return x;
            }
            return Ceiling(x.Right, key);
        }

        /// <summary>
        /// 返回 <paramref name="key"/> 在符号表中的排名。
        /// </summary>
        /// <param name="key">要排名的键。</param>
        /// <returns><paramref name="key"/> 的排名。</returns>
        public int Rank(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to rank() is null");
            return Rank(root, key);
        }

        /// <summary>
        /// 返回 <paramref name="key"/> 在二叉查找树中的排名。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">要查找排名的键。</param>
        /// <returns><paramref name="key"/> 的排名。</returns>
        private int Rank(Node x, TKey key)
        {
            if (x == null)
                return 0;
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Rank(x.Left, key);
            else if (cmp > 0)
                return 1 + Size(x.Left) + Rank(x.Right, key);
            else
                return Size(x.Left);
        }

        /// <summary>
        /// 挑拣出排名为 <paramref name="k"/> 的键。
        /// </summary>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>排名为 <paramref name="k"/> 的键。</returns>
        public TKey Select(int k)
        {
            if (k < 0 || k >= Size())
                throw new ArgumentException("argument to select() is invaild: " + k);
            var x = Select(root, k);
            return x.Key;
        }

        /// <summary>
        /// 挑拣出排名为 <paramref name="k"/> 的结点。
        /// </summary>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>排名为 <paramref name="k"/> 的结点。</returns>
        private Node Select(Node x, int k)
        {
            if (x == null)
                return null;
            var t = Size(x.Left);
            if (t > k)
                return Select(x.Left, k);
            else if (t < k)
                return Select(x.Right, k - t - 1);
            else
                return x;
        }

        /// <summary>
        /// 删除二叉查找树中最小的结点。
        /// </summary>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
        public void DeleteMin()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Symbol table underflow");
            root = DeleteMin(root);
        }

        /// <summary>
        /// 在以 <paramref name="x"/> 为根结点的二叉查找树中删除最小结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>删除后的二叉查找树。</returns>
        private Node DeleteMin(Node x)
        {
            if (x.Left == null)
                return x.Right;
            x.Left = DeleteMin(x.Left);
            x.Size = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        /// <summary>
        /// 删除二叉查找树中最大的结点。
        /// </summary>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出该异常。</exception>
        public void DeleteMax()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Symbol Table Underflow");
            root = DeleteMax(root);
        }

        /// <summary>
        /// 从指定二叉查找树中删除最大结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>删除后的二叉查找树。</returns>
        private Node DeleteMax(Node x)
        {
            if (x.Right == null)
                return x.Left;
            x.Right = DeleteMax(x.Right);
            x.Size = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        /// <summary>
        /// 将二叉树按照树形输出。
        /// </summary>
        /// <returns>二叉查找树输出的字符串。</returns>
        public override string ToString()
        {
            if (IsEmpty())
                return string.Empty;

            var maxDepth = Depth(root);
            int layer = 0, bottomLine = (int)Math.Pow(2, maxDepth) * 2;

            //BST
            var sb = new StringBuilder();
            var nowLayer = new Queue<Node>();
            var nextLayer = new Queue<Node>();
            nextLayer.Enqueue(root);

            while (layer != maxDepth)
            {
                var unitSize = bottomLine / (int)Math.Pow(2, layer);
                var temp = nowLayer;
                nowLayer = nextLayer;
                nextLayer = temp;

                while (nowLayer.Count != 0)
                {
                    var x = nowLayer.Dequeue();

                    if (x != null)
                    {
                        nextLayer.Enqueue(x.Left);
                        nextLayer.Enqueue(x.Right);
                    }
                    else
                    {
                        nextLayer.Enqueue(null);
                        nextLayer.Enqueue(null);
                    }

                    if (x != null && x.Left != null)
                    {
                        for (var i = 0; i < unitSize / 4; i++)
                            sb.Append(" ");
                        sb.Append("|");
                        for (var i = 1; i < unitSize / 4; i++)
                            sb.Append("-");
                    }
                    else
                    {
                        for (var i = 0; i < unitSize / 2; i++)
                            sb.Append(" ");
                    }

                    if (x == null)
                        sb.Append(" ");
                    else
                        sb.Append(x.Key);

                    if (x != null && x.Right != null)
                    {
                        for (var i = 1; i < unitSize / 4; i++)
                            sb.Append("-");
                        sb.Append("|");
                        for (var i = 1; i < unitSize / 4; i++)
                            sb.Append(" ");
                    }
                    else
                    {
                        for (var i = 1; i < unitSize / 2; i++)
                            sb.Append(" ");
                    }
                }
                sb.AppendLine();
                layer++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取二叉树的最大深度。
        /// </summary>
        /// <param name="x">二叉树的根结点。</param>
        /// <returns>二叉树的最大深度。</returns>
        private int Depth(Node x)
        {
            if (x == null)
                return 0;
            return 1 + Math.Max(Depth(x.Left), Depth(x.Right));
        }
    }
}