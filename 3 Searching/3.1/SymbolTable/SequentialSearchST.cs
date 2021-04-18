using System;
using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 基于无序链表的符号表。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public class SequentialSearchST<TKey, TValue> : IST<TKey, TValue>
    {
        /// <summary>
        /// 符号表中的元素个数。
        /// </summary>
        /// <value>符号表中的元素个数。</value>
        private int n;
        /// <summary>
        /// 链表头结点。
        /// </summary>
        /// <value>链表头结点。</value>
        private Node first;

        /// <summary>
        /// 链表结点。
        /// </summary>
        private class Node
        {
            public TKey Key;
            public TValue Value;
            public Node Next;

            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        /// <summary>
        /// 检查键 <paramref name="key"/> 是否已被包含在符号表中。
        /// </summary>
        /// <param name="key">需要检查的键。</param>
        /// <returns>如果 <paramref name="key"/> 已被包含在符号表中则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出此异常。</exception>
        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to contains() can't be null!");
            for (var pointer = first; pointer != null; pointer = pointer.Next)
                if (pointer.Key.Equals(key))
                    return true;
            return false;
        }

        /// <summary>
        /// 从表中删去键 <paramref name="key"/> 及其对应的值。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        public void Delete(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key can't be null");
            Node before = null, target = first;
            while (target != null && !target.Key.Equals(key))
            {
                before = target;
                target = target.Next;
            }
            if (target != null)
                Delete(before, target);
        }

        /// <summary>
        /// 从链表中删除指定的结点。
        /// </summary>
        /// <param name="before"><paramref name="target"/> 的前驱。</param>
        /// <param name="target">准备删除的结点。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="target"/> 为 <c>null</c> 时抛出此异常。</exception>
        private void Delete(Node before, Node target)
        {
            if (target == null)
                throw new ArgumentNullException("target can't be null");

            if (before == null)
                first = target.Next;
            else
                before.Next = target.Next;
            n--;
        }

        /// <summary>
        /// 获取键 <paramref name="key"/> 对应的值，不存在则返回 <c>default(Value)</c>。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>键 <paramref name="key"/> 对应的值，不存在则返回 <c>default(Value)</c>。</returns>
        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key can't be null");
            for (var pointer = first; pointer != null; pointer = pointer.Next)
                if (pointer.Key.Equals(key))
                    return pointer.Value;
            return default(TValue);
        }

        /// <summary>
        /// 符号表是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => n == 0;

        /// <summary>
        /// 获得所有的键。
        /// </summary>
        /// <returns>包含所有键的集合。</returns>
        public IEnumerable<TKey> Keys()
        {
            var keys = new TKey[n];
            var pointer = first;
            for (var i = 0; i < n; i++)
            {
                keys[i] = pointer.Key;
                pointer = pointer.Next;
            }
            return keys;
        }

        /// <summary>
        /// 插入一个新的键值对。
        /// </summary>
        /// <param name="key">新的键。</param>
        /// <param name="value">新的值。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出此异常。</exception>
        public void Put(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("key can't be null!");
            if (value == null)
            {
                Delete(key);
                return;
            }
            for (var pointer = first; pointer != null; pointer = pointer.Next)
            {
                if (pointer.Key.Equals(key))
                {
                    pointer.Value = value;
                    return;
                }
            }

            first = new Node(key, value, first);
            n++;
        }

        /// <summary>
        /// 获取符号表中的键值对数量。
        /// </summary>
        /// <returns>当前符号表中的键值对数量。</returns>
        public int Size() => n;
    }
}
