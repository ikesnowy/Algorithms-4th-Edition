using System;
using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 符号表（数组实现）。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public class ArraySt<TKey, TValue> : ISt<TKey, TValue> 
    {
        /// <summary>
        /// 键数组。
        /// </summary>
        /// <value>键数组。</value>
        private TKey[] _keys;
        /// <summary>
        /// 值数组。
        /// </summary>
        /// <value>值数组。</value>
        private TValue[] _values;
        /// <summary>
        /// 键值对数目。
        /// </summary>
        /// <value>键值对数目。</value>
        private int _n;

        /// <summary>
        /// 建立基于数组实现的符号表。
        /// </summary>
        public ArraySt() : this(8) { }

        /// <summary>
        /// 建立基于数组实现的符号表。
        /// </summary>
        /// <param name="initCapacity">初始大小。</param>
        public ArraySt(int initCapacity)
        {
            _keys = new TKey[initCapacity];
            _values = new TValue[initCapacity];
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
            for (var i = 0; i < _n; i++)
            {
                if (key.Equals(_keys[i]))
                {
                    _keys[i] = _keys[_n - 1];
                    _values[i] = _values[_n - 1];
                    _keys[_n - 1] = default(TKey);
                    _values[_n - 1] = default(TValue);
                    _n--;
                    if (_n > 0 && _n == _keys.Length / 4)
                        Resize(_keys.Length / 2);
                    return;
                }
            }
        }

        /// <summary>
        /// 获取键对应的值，若键不存在则返回 null。
        /// </summary>
        /// <param name="key">需要查找的键。</param>
        /// <returns>找到的值，不存在则返回 <c>default(Value)</c></returns>
        public TValue Get(TKey key)
        {
            for (var i = 0; i < _n; i++)
                if (_keys[i].Equals(key))
                    return _values[i];
            return default(TValue);
        }

        /// <summary>
        /// 检查符号表是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => _n == 0;

        /// <summary>
        /// 获得包含全部键的集合。
        /// </summary>
        /// <returns>全部键的集合。</returns>
        public IEnumerable<TKey> Keys()
        {
            var result = new TKey[_n];
            Array.Copy(_keys, result, _n);
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

            if (_n >= _values.Length)
                Resize(_n * 2);

            _keys[_n] = key;
            _values[_n] = value;
            _n++;
        }

        /// <summary>
        /// 返回符号表中键值对的数量。
        /// </summary>
        /// <returns>键值对数量。</returns>
        public int Size() => _n;

        /// <summary>
        /// 为符号表重新分配空间。
        /// </summary>
        /// <param name="capacity">新分配的空间大小。</param>
        private void Resize(int capacity)
        {
            var tempKey = new TKey[capacity];
            var tempValue = new TValue[capacity];

            for (var i = 0; i < _n; i++)
                tempKey[i] = _keys[i];
            for (var i = 0; i < _n; i++)
                tempValue[i] = _values[i];

            _keys = tempKey;
            _values = tempValue;
        }
    }
}
