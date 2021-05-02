using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SymbolTable
{
    /// <summary>
    /// 基于有序链表的有序符号表实现。
    /// </summary>
    /// <typeparam name="TKey">符号表键类型。</typeparam>
    /// <typeparam name="TValue">符号表值类型。</typeparam>
    public class OrderedSequentialSearchSt<TKey, TValue> : ISt<TKey, TValue>, IOrderedSt<TKey, TValue> 
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 符号表结点。
        /// </summary>
        private class Node
        {
            public TKey Key { get; set; }        // 键。
            public TValue Value { get; set; }    // 值。
            public Node Next { get; set; }      // 后继。
            public Node Prev { get; set; }      // 前驱。
        }

        private Node _first;      // 起始结点。
        private Node _tail;       // 末尾结点。
        private int _n;              // 键值对数量。

        /// <summary>
        /// 大于等于 key 的最小值。
        /// </summary>
        /// <returns>大于等于 key 的最小值，不存在则返回 <c>default(Key)</c>。</returns>
        public TKey Ceiling(TKey key)
        {
            var pointer = _first;
            while (pointer != null && Less(pointer.Key, key))
                pointer = pointer.Next;
            return pointer == null ? default(TKey) : pointer.Key;
        }

        /// <summary>
        /// 键 <paramref name="key"/> 在表中是否存在对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>如果存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(TKey key) => Floor(key).Equals(key);

        /// <summary>
        /// 从表中删去键 <paramref name="key"/> 对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        public void Delete(TKey key)
        {
            var pointer = _first;
            while (pointer != null && !pointer.Key.Equals(key))
                pointer = pointer.Next;
            if (pointer == null)
                return;
            Delete(pointer);
        }

        /// <summary>
        /// 从链表中删除结点 <paramref name="node"/>。
        /// </summary>
        /// <param name="node">待删除的结点。</param>
        private void Delete(Node node)
        {
            var prev = node.Prev;
            var next = node.Next;
            if (prev == null)
                _first = next;
            else
                prev.Next = next;

            if (next == null)
                _tail = prev;
            _n--;
        }

        /// <summary>
        /// 删除最大的键。
        /// </summary>
        public void DeleteMax()
        {
            if (_n == 0)
                throw new Exception("ST Underflow");
            Delete(_tail);
        }

        /// <summary>
        /// 删除最小的键。
        /// </summary>
        public void DeleteMin()
        {
            if (_n == 0)
                throw new Exception("ST Underflow");
            Delete(_first);
        }

        /// <summary>
        /// 小于等于 Key 的最大值。
        /// </summary>
        /// <returns>小于等于 <paramref name="key"/> 的最大值。</returns>
        public TKey Floor(TKey key)
        {
            var pointer = _tail;
            while (pointer != null && Greater(pointer.Key, key))
                pointer = pointer.Prev;
            return pointer == null ? default(TKey) : pointer.Key;
        }

        /// <summary>
        /// 获取键 <paramref name="key"/> 对应的值，不存在则返回 null。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns><typeparamref name="TKey"/> 对应的值。</returns>
        public TValue Get(TKey key)
        {
            var pointer = _first;
            while (pointer != null && Greater(key, pointer.Key))
                pointer = pointer.Next;

            if (pointer == null)
                return default(TValue);
            else if (pointer.Key.Equals(key))
                return pointer.Value;
            else
                return default(TValue);
        }

        /// <summary>
        /// 符号表是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => _n == 0;

        /// <summary>
        /// 获得符号表中所有键的集合。
        /// </summary>
        /// <returns>符号表中所有键的集合。</returns>
        public IEnumerable<TKey> Keys() => _n == 0 ? new List<TKey>() : Keys(_first.Key, _tail.Key);

        /// <summary>
        /// 获得符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns>符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。</returns>
        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            var list = new List<TKey>();
            var pointer = _first;
            while (pointer != null && Less(pointer.Key, lo))
                pointer = pointer.Next;
            while (pointer != null && Less(pointer.Key, hi))
            {
                list.Add(pointer.Key);
                pointer = pointer.Next;
            }

            Debug.Assert(pointer != null, nameof(pointer) + " != null");
            if (pointer.Key.Equals(hi))
                list.Add(pointer.Key);
            return list;
        }

        /// <summary>
        /// 最大的键。
        /// </summary>
        /// <returns>最大的键，不存在则返回 <c>default(Key)</c>。</returns>
        public TKey Max() => _tail == null ? default(TKey) : _tail.Key;

        /// <summary>
        /// 最小的键。
        /// </summary>
        /// <returns>最小的键，不存在则返回 <c>default(Key)</c>。</returns>
        public TKey Min() => _first == null ? default(TKey) : _first.Key;

        /// <summary>
        /// 向符号表插入键值对，重复值将被替换。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public void Put(TKey key, TValue value)
        {
            Delete(key);

            var temp = new Node
            {
                Key = key,
                Value = value,
                Prev = null,
                Next = null
            };

            Node left = null, right = _first;
            while (right != null && Less(right.Key, temp.Key))
            {
                left = right;
                right = right.Next;
            }

            Insert(left, right, temp);

            if (left == null)
                _first = temp;
            if (right == null)
                _tail = temp;
            _n++;
        }

        /// <summary>
        /// 小于 Key 的键的数量。
        /// </summary>
        /// <returns>小于 Key 的键的数量。</returns>
        public int Rank(TKey key)
        {
            var counter = 0;
            var pointer = _first;
            while (pointer != null && Less(pointer.Key, key))
            {
                pointer = pointer.Next;
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// 获得排名为 insert 的键（从 0 开始）。
        /// </summary>
        /// <param name="k">排名</param>
        /// <returns>获得排名为 insert 的键（从 0 开始）。</returns>
        public TKey Select(int k)
        {
            if (k >= _n)
                throw new Exception("insert must less than ST size!");

            var pointer = _first;
            for (var i = 0; i < k; i++)
                pointer = pointer.Next;
            return pointer.Key;
        }

        /// <summary>
        /// 获得符号表中键值对的数量。
        /// </summary>
        /// <returns>符号表中键值对的数量。</returns>
        public int Size() => _n;

        /// <summary>
        /// [<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns>[<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。</returns>
        public int Size(TKey lo, TKey hi)
        {
            var counter = 0;
            var pointer = _first;
            while (pointer != null && Less(pointer.Key, lo))
                pointer = pointer.Next;
            while (pointer != null && Less(pointer.Key, hi))
            {
                pointer = pointer.Next;
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// 键 <paramref name="a"/> 是否小于 <paramref name="b"/>。
        /// </summary>
        /// <param name="a">检查是否较小的键。</param>
        /// <param name="b">检查是否较大的键。</param>
        /// <returns>如果 <paramref name="a"/> 较小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Less(TKey a, TKey b) => a.CompareTo(b) < 0;

        /// <summary>
        /// 键 <paramref name="a"/> 是否大于 <paramref name="b"/>。
        /// </summary>
        /// <param name="a">检查是否较大的键。</param>
        /// <param name="b">检查是否较小的键。</param>
        /// <returns>如果 <paramref name="a"/> 较大则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Greater(TKey a, TKey b) => a.CompareTo(b) > 0;

        /// <summary>
        /// 将结点 <paramref name="insert"/> 插入到 <paramref name="left"/> 和 <paramref name="right"/> 之间。
        /// </summary>
        /// <param name="left">作为前驱的结点。</param>
        /// <param name="right">作为后继的结点。</param>
        /// <param name="insert">待插入的结点。</param>
        private void Insert(Node left, Node right, Node insert)
        {
            insert.Prev = left;
            insert.Next = right;
            if (left != null)
                left.Next = insert;

            if (right != null)
                right.Prev = insert;
        }
    }
}
