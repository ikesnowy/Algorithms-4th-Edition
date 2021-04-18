using System;
using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 前移编码的符号表（数组实现）。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public class MoveToFrontArrayST<TKey, TValue> : IST<TKey, TValue>
    {
        /// <summary>
        /// 键数组。
        /// </summary>
        /// <value>键数组。</value>
        private TKey[] keys;
        /// <summary>
        /// 值数组。
        /// </summary>
        /// <value>值数组。</value>
        private TValue[] values;
        /// <summary>
        /// 键值对数目。
        /// </summary>
        /// <value>键值对数目。</value>
        private int n;

        /// <summary>
        /// 建立基于数组实现的符号表。
        /// </summary>
        public MoveToFrontArrayST() : this(8) { }

        /// <summary>
        /// 建立基于数组实现的符号表。
        /// </summary>
        /// <param name="initCapacity">初始大小。</param>
        public MoveToFrontArrayST(int initCapacity)
        {
            keys = new TKey[initCapacity];
            values = new TValue[initCapacity];
        }

        /// <summary>
        /// 检查键 <typeparamref name="TKey"/> 是否存在。
        /// </summary>
        /// <param name="key">需要检查是否存在的键。</param>
        /// <returns>如果存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(TKey key) => Get(key).Equals(default(TKey));

        /// <summary>
        /// 删除键 <paramref name="key"/> 及对应的值。
        /// </summary>
        /// <param name="key">需要删除的键。</param>
        public void Delete(TKey key)
        {
            for (var i = 0; i < n; i++)
            {
                if (key.Equals(keys[i]))
                {
                    keys[i] = keys[n - 1];
                    values[i] = values[n - 1];
                    keys[n - 1] = default(TKey);
                    values[n - 1] = default(TValue);
                    n--;
                    if (n > 0 && n == keys.Length / 4)
                        Resize(keys.Length / 2);
                    return;
                }
            }
        }

        /// <summary>
        /// 获取键对应的值，若键不存在则返回 null，存在的键会被移到数组最前端。
        /// </summary>
        /// <param name="key">需要查找的键。</param>
        /// <returns>找到的值，不存在则返回 <c>default(Value)</c></returns>
        public TValue Get(TKey key)
        {
            int i;
            for (i = 0; i < n; i++)
                if (keys[i].Equals(key))
                    break;

            if (i == n)
                return default(TValue);

            var toFrontKey = keys[i];
            var toFrontValue = values[i];

            for (var j = i; j > 0; j--)
                keys[j] = keys[j - 1];
            for (var j = i; j > 0; j--)
                values[j] = values[j - 1];

            keys[0] = toFrontKey;
            values[0] = toFrontValue;

            return values[0];
        }

        /// <summary>
        /// 检查符号表是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => n == 0;

        /// <summary>
        /// 获得包含全部键的集合。
        /// </summary>
        /// <returns>全部键的集合。</returns>
        public IEnumerable<TKey> Keys()
        {
            var result = new TKey[n];
            Array.Copy(keys, result, n);
            return result;
        }

        /// <summary>
        /// 向符号表中插入新元素，若键存在将被替换。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public void Put(TKey key, TValue value)
        {
            Delete(key);

            if (n >= values.Length)
                Resize(n * 2);

            keys[n] = key;
            values[n] = value;
            n++;
        }

        /// <summary>
        /// 返回符号表中键值对的数量。
        /// </summary>
        /// <returns>键值对数量。</returns>
        public int Size() => n;

        /// <summary>
        /// 为符号表重新分配空间。
        /// </summary>
        /// <param name="capacity">新分配的空间大小。</param>
        private void Resize(int capacity)
        {
            var tempKey = new TKey[capacity];
            var tempValue = new TValue[capacity];

            for (var i = 0; i < n; i++)
                tempKey[i] = keys[i];
            for (var i = 0; i < n; i++)
                tempValue[i] = values[i];

            keys = tempKey;
            values = tempValue;
        }
    }
}
