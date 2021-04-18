using System;
using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 符号表，基于有序表，利用插值法实现搜索。
    /// </summary>
    public class InterpolationSearchSt : ISt<double, int>, IOrderedSt<double, int>
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
        private double[] _keys;
        /// <summary>
        /// 保存符号表值的数组。
        /// </summary>
        /// <value>保存符号表值的数组。</value>
        private int[] _values;
        /// <summary>
        /// 符号表中的键值对数量。
        /// </summary>
        /// <value>符号表中的键值对数量。</value>
        private int _n;

        /// <summary>
        /// 构造一个空的符号表。
        /// </summary>
        public InterpolationSearchSt() : this(InitCapacity) { }

        /// <summary>
        /// 构造一个指定容量的符号表。
        /// </summary>
        /// <param name="capacity">符号表初始容量。</param>
        public InterpolationSearchSt(int capacity)
        {
            _keys = new double[capacity];
            _values = new int[capacity];
            _n = 0;
        }

        /// <summary>
        /// 大于等于 <paramref name="key"/> 的最小的键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>符号表中大于等于 <paramref name="key"/> 的最小的键。</returns>
        public double Ceiling(double key)
        {
            var i = Rank(key);
            if (i == _n)
                return default(double);
            else
                return _keys[i];
        }

        /// <summary>
        /// 检查 <paramref name="key"/> 是否已在符号表中。
        /// </summary>
        /// <param name="key">要检查是否存在的键。</param>
        /// <returns>若 <paramref name="key"/> 存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(double key)
        {
            return !Get(key).Equals(default(double));
        }

        /// <summary>
        /// 从符号表中删除键为 <paramref name="key"/> 的键值对。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        public void Delete(double key)
        {
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
            _keys[_n] = default(double);
            _values[_n] = default(int);

            if (_n > 0 && _n == _keys.Length / 4)
                Resize(_n / 2);
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
        public double Floor(double key)
        {
            var i = Rank(key);
            if (i < _n && _keys[i].CompareTo(key) == 0)
                return _keys[i];
            if (i == 0)
                return default(double);
            else
                return _keys[i - 1];
        }

        /// <summary>
        /// 根据键获得对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns><paramref name="key"/> 对应的值。</returns>
        public int Get(double key)
        {
            if (IsEmpty())
                return default(int);
            var rank = Rank(key);
            if (rank < _n && _keys[rank].Equals(key))
                return _values[rank];
            return default(int);
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
        public IEnumerable<double> Keys() => Keys(Min(), Max());

        /// <summary>
        /// 获得所有位于区间 [<paramref name="lo"/>, <paramref name="hi"/>] 内的键。
        /// </summary>
        /// <param name="lo">区间起点。</param>
        /// <param name="hi">区间终点。</param>
        /// <returns>区间 [<paramref name="lo"/>, <paramref name="hi"/>] 内的键。</returns>
        public IEnumerable<double> Keys(double lo, double hi)
        {
            var list = new List<double>();
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
        public double Max()
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
        public double Min()
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
        public void Put(double key, int value)
        {
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
        }

        /// <summary>
        /// 小于 <paramref name="key"/> 的键的个数。
        /// </summary>
        /// <param name="key">需要比较的键。</param>
        /// <returns>小于 <paramref name="key"/> 的键的个数。</returns>
        public int Rank(double key)
        {
            int lo = 0, hi = _n - 1;
            while (lo <= hi)
            {
                var percent = (key - _keys[lo]) / (_keys[hi] - _keys[lo]);
                var index = lo + (int)Math.Floor((hi - lo) * percent);
                if (percent < 0)
                    index = lo;
                if (percent > 1)
                    index = hi;

                var compare = _keys[index].CompareTo(key);
                if (compare > 0)
                    hi = index - 1;
                else if (compare < 0)
                    lo = index + 1;
                else
                    return index;
            }
            return lo;
        }

        /// <summary>
        /// 使得符号表中的第 <paramref name="k"/> 个键正好是第 <paramref name="k"/> 小的键。
        /// </summary>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>第 <paramref name="k"/> 小的键。</returns>
        /// <exception cref="ArgumentOutOfRangeException">当 <paramref name="k"/> 超出数组范围时抛出此异常。</exception>
        public double Select(int k)
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
        public int Size(double lo, double hi)
        {
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
            var tempKeys = new double[capacity];
            var tempValues = new int[capacity];
            for (var i = 0; i < _n; i++)
            {
                tempKeys[i] = _keys[i];
                tempValues[i] = _values[i];
            }
            _keys = tempKeys;
            _values = tempValues;
        }
    }
}
