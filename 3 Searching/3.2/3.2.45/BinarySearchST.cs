using System;
using System.Collections.Generic;
using BinarySearchTree;

namespace _3._2._45
{
    /// <summary>
    /// 符号表，基于有序表并应用了二分查找优化。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public class BinarySearchSt<TKey, TValue> : ISt<TKey, TValue>, IOrderedSt<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 符号表的默认长度。
        /// </summary>
        /// <value>符号表的默认长度。</value>
        private static readonly int InitCapacity = 2;
        /// <summary>
        /// 保存符号表键的数组。
        /// </summary>
        /// <value>保存符号表键的数组。</value>
        private TKey[] _keys;
        /// <summary>
        /// 保存符号表值的数组。
        /// </summary>
        /// <value>保存符号表值的数组。</value>
        private TValue[] _values;
        /// <summary>
        /// 符号表中的键值对数量。
        /// </summary>
        /// <value>符号表中的键值对数量。</value>
        private int _n;

        /// <summary>
        /// 构造一个空的符号表。
        /// </summary>
        public BinarySearchSt() : this(InitCapacity) { }

        /// <summary>
        /// 构造一个指定容量的符号表。
        /// </summary>
        /// <param name="capacity">符号表初始容量。</param>
        public BinarySearchSt(int capacity)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
            _n = 0;
        }

        /// <summary>
        /// 大于等于 <paramref name="key"/> 的最小的键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>符号表中大于等于 <paramref name="key"/> 的最小的键。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出此异常。</exception>
        public TKey Ceiling(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Ceiling is null");
            var i = Rank(key);
            if (i == _n)
                return default(TKey);
            else
                return _keys[i];
        }

        /// <summary>
        /// 检查 <paramref name="key"/> 是否已在符号表中。
        /// </summary>
        /// <param name="key">要检查是否存在的键。</param>
        /// <returns>若 <paramref name="key"/> 存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key can't be null");
            return !Get(key).Equals(default(TValue));
        }

        /// <summary>
        /// 从符号表中删除键为 <paramref name="key"/> 的键值对。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出。</exception>
        public void Delete(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Delete() is null");
            if (IsEmpty())
                return;

            var i = Rank(key);

            if (i == _n && _keys[i].CompareTo(key) != 0)
                return;

            for (var j = i; j < _n - 1; j++)
            {
                _keys[j] = _keys[j + 1];
                _values[j] = _values[j + 1];
            }

            _n--;
            _keys[_n] = default(TKey);
            _values[_n] = default(TValue);

            if (_n > 0 && _n == _keys.Length / 4)
                Resize(_keys.Length / 2);

            // Debug.Assert(Check());
        }

        /// <summary>
        /// 删除键最大的键值对。
        /// </summary>
        public void DeleteMax() => Delete(Max());

        /// <summary>
        /// 删除键最小的键值对。
        /// </summary>
        public void DeleteMin() => Delete(Min());

        /// <summary>
        /// 符号表中小于等于 <paramref name="key"/> 的最大键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>小于等于 <paramref name="key"/> 的最大键。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出此异常。</exception>
        public TKey Floor(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Floor() is null");
            var i = Rank(key);
            if (i < _n && _keys[i].CompareTo(key) == 0)
                return _keys[i];
            if (i == 0)
                return default(TKey);
            else
                return _keys[i - 1];
        }

        /// <summary>
        /// 根据键获得对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns><paramref name="key"/> 对应的值。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出此异常。</exception>
        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Get() is null");
            if (IsEmpty())
                return default(TValue);
            var rank = Rank(key);
            if (rank < _n && _keys[rank].Equals(key))
                return _values[rank];
            return default(TValue);
        }

        /// <summary>
        /// 符号表是否为空。
        /// </summary>
        /// <returns>如果符号表为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => _n == 0;

        /// <summary>
        /// 获得全部键的集合。
        /// </summary>
        /// <returns>全部键的集合。</returns>
        public IEnumerable<TKey> Keys() => Keys(Min(), Max());

        /// <summary>
        /// 获得所有位于区间 [<paramref name="lo"/>, <paramref name="hi"/>] 内的键。
        /// </summary>
        /// <param name="lo">区间起点。</param>
        /// <param name="hi">区间终点。</param>
        /// <returns>区间 [<paramref name="lo"/>, <paramref name="hi"/>] 内的键。</returns>
        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            if (lo == null)
                throw new ArgumentNullException("first argument to Keys() is null");
            if (hi == null)
                throw new ArgumentNullException("Second argument to Keys() is null");

            var list = new List<TKey>();
            if (lo.CompareTo(hi) > 0)
                return list;
            for (var i = Rank(lo); i < Rank(hi); i++)
                list.Add(_keys[i]);
            if (Contains(hi))
                list.Add(_keys[Rank(hi)]);
            return list;
        }

        /// <summary>
        /// 获得符号表中最大的键。
        /// </summary>
        /// <returns>符号表中最大的键。</returns>
        /// <exception cref="InvalidOperationException">当符号表为空时抛出此异常。</exception>
        public TKey Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException("called Max() with empty table");
            return _keys[_n - 1];
        }

        /// <summary>
        /// 获得符号表中最小的键。
        /// </summary>
        /// <returns>符号表中最小的键。</returns>
        /// <exception cref="InvalidOperationException">当符号表为空时抛出此异常。</exception>
        public TKey Min()
        {
            if (IsEmpty())
                throw new InvalidOperationException("called Min() with empty table");
            return _keys[0];
        }

        /// <summary>
        /// 向符号表插入一个新的键值对，如果键已存在则覆盖。
        /// </summary>
        /// <param name="key">要插入的键。</param>
        /// <param name="value">要插入的值。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出。</exception>
        public void Put(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("first argument to Put() is null");
            if (value == null)
            {
                Delete(key);
                return;
            }

            var i = Rank(key);

            if (i < _n && _keys[i].CompareTo(key) == 0)
            {
                _values[i] = value;
                return;
            }

            if (_n == _keys.Length)
                Resize(_n * 2);

            for (var j = _n; j > i; j--)
            {
                _keys[j] = _keys[j - 1];
                _values[j] = _values[j - 1];
            }
            _keys[i] = key;
            _values[i] = value;
            _n++;

            // Debug.Assert(Check());
        }

        /// <summary>
        /// 小于 <paramref name="key"/> 的键的个数。
        /// </summary>
        /// <param name="key">需要比较的键。</param>
        /// <returns>小于 <paramref name="key"/> 的键的个数。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出。</exception>
        public int Rank(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Rank() is null");
            int lo = 0, hi = _n - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                var compare = _keys[mid].CompareTo(key);
                if (compare > 0)
                    hi = mid - 1;
                else if (compare < 0)
                    lo = mid + 1;
                else
                    return mid;
            }
            return lo;
        }

        /// <summary>
        /// 使得符号表中的第 <paramref name="k"/> 个键正好是第 <paramref name="k"/> 小的键。
        /// </summary>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>第 <paramref name="k"/> 小的键。</returns>
        public TKey Select(int k)
        {
            if (k < 0 || k >= _n)
                throw new ArgumentOutOfRangeException("called Select() with invaild k: " + k);
            return _keys[k];
        }

        /// <summary>
        /// 符号表中的键值对数量。
        /// </summary>
        /// <returns>符号表中的键值对数量。</returns>
        public int Size() => _n;

        /// <summary>
        /// 获得区间 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键的数量。
        /// </summary>
        /// <param name="lo">区间起点。</param>
        /// <param name="hi">区间末尾。</param>
        /// <returns>[<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数目。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="lo"/> 或 <paramref name="hi"/> 为 <c>null</c> 时抛出此异常。</exception>
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
        /// 为符号表重新分配空间。
        /// </summary>
        /// <param name="capacity">重新分配的大小。</param>
        /// <exception cref="ArgumentOutOfRangeException">当 <paramref name="capacity"/> < <see cref="_n"/> 时抛出该异常。</exception>
        private void Resize(int capacity)
        {
            if (capacity < _n)
                throw new ArgumentOutOfRangeException("分配容量不能小于表中元素数量。");
            var tempKeys = new TKey[capacity];
            var tempValues = new TValue[capacity];
            for (var i = 0; i < _n; i++)
            {
                tempKeys[i] = _keys[i];
                tempValues[i] = _values[i];
            }
            _keys = tempKeys;
            _values = tempValues;
        }

        /// <summary>
        /// 检查符号表结构是否有效。
        /// </summary>
        /// <returns>检查通过则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Check() => IsSorted() && RankCheck();

        /// <summary>
        /// 检查 <see cref="_keys"/> 数组是否有序。
        /// </summary>
        /// <returns>如果 <see cref="_keys"/> 有序则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool IsSorted()
        {
            for (var i = 1; i < Size(); i++)
                if (_keys[i].CompareTo(_keys[i - 1]) < 0)
                    return false;
            return true;
        }

        /// <summary>
        /// 检查 Rank(Select(i)) = i 是否成立。
        /// </summary>
        /// <returns>成立则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool RankCheck()
        {
            for (var i = 0; i < Size(); i++)
                if (i != Rank(Select(i)))
                    return false;
            for (var i = 0; i < Size(); i++)
                if (_keys[i].CompareTo(Select(Rank(_keys[i]))) != 0)
                    return false;
            return true;
        }
    }
}
