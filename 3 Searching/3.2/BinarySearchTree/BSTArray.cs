using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable CognitiveComplexity

namespace BinarySearchTree
{
    /// <summary>
    /// 以数组为基础的二叉搜索树。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public class BstArray<TKey, TValue> : ISt<TKey, TValue>, IOrderedSt<TKey, TValue> where TKey : IComparable<TKey>
    {
        private readonly Node[] _nodes;
        private readonly int[] _left;
        private readonly int[] _right;
        private int _size;
        private int _root;

        /// <summary>
        /// 二叉搜索树的结点。
        /// </summary>
        private class Node
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        /// <summary>
        /// 建立一个以数组为基础的二叉搜索树。
        /// </summary>
        /// <param name="maxSize">二叉搜索树中的结点数。</param>
        public BstArray(int maxSize)
        {
            _nodes = new Node[maxSize];
            _left = new int[maxSize];
            _right = new int[maxSize];
            for (var i = 0; i < maxSize; i++)
            {
                _left[i] = -1;
                _right[i] = -1;
            }
            _size = 0;
            _root = 0;
        }

        /// <summary>
        /// 向符号表插入键值对。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public void Put(TKey key, TValue value)
        {
            if (_size == _nodes.Length)
            {
                throw new InvalidOperationException("BST is full");
            }

            if (IsEmpty())
            {
                _nodes[_size] = new Node{Key = key, Value = value};
                _size++;
                return;
            }

            Put(key, value, null, _root);
        }

        /// <summary>
        /// 向二叉树插入键值对。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        /// <param name="treeSide">子树数组。</param>
        /// <param name="parent">父结点下标。</param>
        private void Put(TKey key, TValue value, int[] treeSide, int parent)
        {
            int now;
            if (treeSide == null)               // init
            {
                now = parent;
            }
            else if (treeSide[parent] == -1)    // finish
            {
                _nodes[_size] = new Node { Key = key, Value = value };
                treeSide[parent] = _size;
                _size++;
                return;
            }
            else
            {
                now = treeSide[parent];
            }

            var cmp = _nodes[now].Key.CompareTo(key);
            if (cmp > 0)
            {
                Put(key, value, _left, now);
            }
            else if (cmp < 0)
            {
                Put(key, value, _right, now);
            }
            else
            {
                _nodes[now].Value = value;
            }
        }

        /// <summary>
        /// 获取键 <paramref name="key"/> 对应的值，不存在则返回 <c>default(Value)</c>。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>键 <paramref name="key"/> 对应的值，不存在则返回 <c>default(Value)</c>。</returns>
        public TValue Get(TKey key)
        {
            var indices = Get(key, _root);
            if (indices == -1)
            {
                return default;
            }

            return _nodes[indices].Value;
        }

        /// <summary>
        /// 获取 <paramref name="key"/> 对应的下标，不存在则返回 -1。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="start">起始搜索下标。</param>
        /// <returns>找到则返回对应下标，否则返回 -1。</returns>
        private int Get(TKey key, int start)
        {
            var now = start;
            while (now != -1)
            {
                var cmp = _nodes[now].Key.CompareTo(key);
                if (cmp > 0)
                {
                    now = _left[now];
                }
                else if (cmp < 0)
                {
                    now = _right[now];
                }
                else
                {
                    return now;
                }
            }

            return -1;
        }

        /// <summary>
        /// 从表中删去键 <paramref name="key"/> 及其对应的值。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        public void Delete(TKey key)
        {
            var toDelete = Get(key, _root);
            if (toDelete == -1)
            {
                throw new InvalidOperationException("No Such Key in BST");
            }

            _root = Delete(key, _root);
            RemoveNode(toDelete);
        }

        /// <summary>
        /// 从根结点为 <paramref name="root"/> 的二叉搜索树中删除键为 <paramref name="key"/> 的结点。
        /// 返回删除结点后树的根结点下标。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        /// <param name="root">根结点。</param>
        /// <returns>删除结点后树的根结点下标。</returns>
        private int Delete(TKey key, int root)
        {
            if (root == -1 || _nodes[root] == null)
            {
                return -1;
            }

            var cmp = _nodes[root].Key.CompareTo(key);
            if (cmp > 0)
            {
                _left[root] = Delete(key, _left[root]);
            }
            else if (cmp < 0)
            {
                _right[root] = Delete(key, _right[root]);
            }
            else
            {
                if (_left[root] == -1)
                {
                    return _right[root];
                }

                if (_right[root] == -1)
                {
                    return _left[root];
                }

                var toReplace = Min(_right[root]);
                _right[toReplace] = DeleteMin(_right[root]);
                _left[toReplace] = _left[root];
                root = toReplace;
            }

            return root;
        }

        /// <summary>
        /// 键 <paramref name="key"/> 在表中是否存在对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>如果存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(TKey key)
        {
            return Get(key, _root) > -1;
        }

        /// <summary>
        /// 符号表是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty()
        {
            return _size == 0;
        }

        /// <summary>
        /// 获得符号表中键值对的数量。
        /// </summary>
        /// <returns>符号表中键值对的数量。</returns>
        public int Size()
        {
            return _size;
        }

        /// <summary>
        /// [<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns>[<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。</returns>
        public int Size(TKey lo, TKey hi)
        {
            return Keys(lo, hi).Count();
        }

        /// <summary>
        /// 计算以 <paramref name="root"/> 为根结点的二叉树的大小。
        /// </summary>
        /// <param name="root">二叉树的根结点下标。</param>
        /// <returns>二叉树中的结点个数。</returns>
        private int Size(int root)
        {
            if (root == -1)
            {
                return 0;
            }

            return 1 + Size(_left[root]) + Size(_right[root]);
        }

        /// <summary>
        /// 获得符号表中所有键的集合。
        /// </summary>
        /// <returns>符号表中所有键的集合。</returns>
        public IEnumerable<TKey> Keys()
        {
            if (IsEmpty())
            {
                return new List<TKey>();
            }
            return Keys(Min(), Max());
        }

        /// <summary>
        /// 获得符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns>符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。</returns>
        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            if (lo == null)
                throw new ArgumentNullException(nameof(lo), @"first argument to keys() is null");
            if (hi == null)
                throw new ArgumentNullException(nameof(hi), @"second argument to keys() is null");

            var queue = new Queue<TKey>();
            Keys(_root, queue, lo, hi);
            return queue;
        }

        /// <summary>
        /// 获取二叉查找树中在 <paramref name="lo"/> 和 <paramref name="hi"/> 之间的所有键。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="queue">要填充的队列。</param>
        /// <param name="lo">键的下限。</param>
        /// <param name="hi">键的上限。</param>
        private void Keys(int x, Queue<TKey> queue, TKey lo, TKey hi)
        {
            if (x == -1)
            {
                return;
            }

            var cmpLo = lo.CompareTo(_nodes[x].Key);
            var cmpHi = hi.CompareTo(_nodes[x].Key);
            if (cmpLo < 0)
            {
                Keys(_left[x], queue, lo, hi);
            }

            if (cmpLo <= 0 && cmpHi >= 0)
            {
                queue.Enqueue(_nodes[x].Key);
            }

            if (cmpHi > 0)
            {
                Keys(_right[x], queue, lo, hi);
            }
        }

        /// <summary>
        /// 最小的键。
        /// </summary>
        /// <returns>最小的键。</returns>
        public TKey Min()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("BST is Empty!");
            }

            return _nodes[Min(_root)].Key;
        }

        /// <summary>
        /// 在二叉查找树中查找包含最小键的结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>包含最小键的结点。</returns>
        private int Min(int x)
        {
            if (_left[x] == -1)
            {
                return x;
            }

            return Min(_left[x]);
        }

        /// <summary>
        /// 最大的键。
        /// </summary>
        /// <returns>最大的键。</returns>
        public TKey Max()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("BST is Empty!");
            }

            return _nodes[Max(_root)].Key;
        }

        /// <summary>
        /// 在二叉查找树中查找包含最大键的结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>包含最大键的结点。</returns>
        private int Max(int x)
        {
            if (_right[x] == -1)
            {
                return x;
            }

            return Max(_right[x]);
        }

        /// <summary>
        /// 小于等于 <paramref name="key"/> 的最大值。
        /// </summary>
        /// <returns>小于等于 <paramref name="key"/> 的最大值。</returns>
        public TKey Floor(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), @"argument to floor is null");
            }

            if (IsEmpty())
            {
                throw new InvalidOperationException("calls floor with empty symbol table");
            }
            var x = Floor(_root, key);
            if (x == -1)
            {
                return default;
            }
            else
            {
                return _nodes[x].Key;
            }
        }

        /// <summary>
        /// 获得符号表中小于等于 <paramref name="key"/> 的最大结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">键。</param>
        /// <returns>小于等于 <paramref name="key"/> 的最大结点。</returns>
        private int Floor(int x, TKey key)
        {
            if (x == -1)
            {
                return -1;
            }
            var cmp = key.CompareTo(_nodes[x].Key);
            if (cmp == 0)
            {
                return x;
            }
            else if (cmp < 0)
            {
                return Floor(_left[x], key);
            }
            var t = Floor(_right[x], key);
            if (t != -1)
            {
                return t;
            }

            return x;
        }

        /// <summary>
        /// 大于等于 <paramref name="key"/> 的最小值。
        /// </summary>
        /// <returns>大于等于 <paramref name="key"/> 的最小值。</returns>
        public TKey Ceiling(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), @"argument to ceiling is null");
            }

            if (IsEmpty())
            {
                throw new InvalidOperationException("calls ceiling with empty symbol table");
            }
            var x = Ceiling(_root, key);
            if (x == -1)
            {
                return default;
            }
            return _nodes[x].Key;
        }

        /// <summary>
        /// 获取符号表中大于等于 <paramref name="key"/> 的最小结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">键。</param>
        /// <returns>符号表中大于等于 <paramref name="key"/> 的最小结点。</returns>
        private int Ceiling(int x, TKey key)
        {
            if (x == -1)
            {
                return -1;
            }
            var cmp = key.CompareTo(_nodes[x].Key);
            if (cmp == 0)
            {
                return x;
            }
            if (cmp < 0)
            {
                var t = Ceiling(_left[x], key);
                if (t != -1)
                {
                    return t;
                }
                return x;
            }
            return Ceiling(_right[x], key);
        }

        /// <summary>
        /// 小于 <paramref name="key"/> 的键的数量。
        /// </summary>
        /// <returns>小于 <paramref name="key"/> 的键的数量。</returns>
        public int Rank(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), @"argument to rank() is null");
            }
            return Rank(_root, key);
        }

        /// <summary>
        /// 返回 <paramref name="key"/> 在二叉查找树中的排名。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">要查找排名的键。</param>
        /// <returns><paramref name="key"/> 的排名。</returns>
        private int Rank(int x, TKey key)
        {
            if (x == -1)
            {
                return 0;
            }
            var cmp = key.CompareTo(_nodes[x].Key);
            if (cmp < 0)
            {
                return Rank(_left[x], key);
            }
            else if (cmp > 0)
            {
                return 1 + Size(_left[x]) + Rank(_right[x], key);
            }
            else
            {
                return Size(_left[x]);
            }
        }

        /// <summary>
        /// 获得排名为 k 的键。
        /// </summary>
        /// <param name="k">需要获得的键的排名。</param>
        /// <returns>排名为 k 的键。</returns>
        public TKey Select(int k)
        {
            if (k < 0 || k >= Size())
            {
                throw new ArgumentException("argument to select() is invaild: " + k);
            }
            var x = Select(_root, k);
            return _nodes[x].Key;
        }

        /// <summary>
        /// 挑拣出排名为 <paramref name="k"/> 的结点。
        /// </summary>
        /// <param name="x">树的根结点。</param>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>排名为 <paramref name="k"/> 的结点。</returns>
        private int Select(int x, int k)
        {
            if (x == -1)
            {
                return -1;
            }
            var t = Size(_left[x]);
            if (t > k)
            {
                return Select(_left[x], k);
            }
            else if (t < k)
            {
                return Select(_right[x], k - t - 1);
            }
            else
            {
                return x;
            }
        }

        /// <summary>
        /// 删除最小的键。
        /// </summary>
        public void DeleteMin()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Symbol table underflow");
            }

            var minIndex = Min(_root);
            _root = DeleteMin(_root);
            RemoveNode(minIndex);
        }

        /// <summary>
        /// 在以 <paramref name="x"/> 为根结点的二叉查找树中删除最小结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>删除后的二叉查找树。</returns>
        private int DeleteMin(int x)
        {
            if (_left[x] == -1)
            {
                return _right[x];
            }

            _left[x] = DeleteMin(_left[x]);
            return x;
        }

        /// <summary>
        /// 删除最大的键。
        /// </summary>
        public void DeleteMax()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Symbol table underflow");
            }

            var maxIndex = Max(_root);
            _root = DeleteMax(_root);
            RemoveNode(maxIndex);
        }

        /// <summary>
        /// 从指定二叉查找树中删除最大结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>删除后的二叉查找树。</returns>
        private int DeleteMax(int x)
        {
            if (_right[x] == -1)
                return _left[x];
            _right[x] = DeleteMax(_right[x]);
            
            return x;
        }

        /// <summary>
        /// 删除下标为 <paramref name="index"/> 的结点。
        /// </summary>
        /// <param name="index">要删除的结点下标。</param>
        private void RemoveNode(int index)
        {
            _size--;
            // Remove Node
            for (var i = index; i < _size; i++)
            {
                _nodes[i] = _nodes[i + 1];
                _left[i] = _left[i + 1];
                _right[i] = _right[i + 1];
            }
            // Adjust Index
            if (_root >= index)
            {
                _root--;
            }
            for (var i = 0; i < _size; i++)
            {
                if (_left[i] >= index)
                {
                    _left[i]--;
                }

                if (_right[i] >= index)
                {
                    _right[i]--;
                }
            }
        }
    }
}