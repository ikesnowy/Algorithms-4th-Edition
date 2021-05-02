using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PriorityQueue
{
    /// <summary>
    /// 包含最小元素引用的最大堆。（数组实现）
    /// </summary>
    /// <typeparam name="TKey">最大堆中保存的元素类型。</typeparam>
    public class MaxPqWithMin<TKey> : IMaxPq<TKey>, IEnumerable<TKey> where TKey : class, IComparable<TKey>
    {
        /// <summary>
        /// 保存元素的数组。
        /// </summary>
        /// <value>保存元素的数组。</value>
        private TKey[] _pq;              
        /// <summary>
        /// 堆中的元素数量。
        /// </summary>
        /// <value>堆中的元素数量。</value>
        private int _n;
        /// <summary>
        /// 堆中的最小元素。
        /// </summary>
        /// <value>堆中的最小元素。</value>
        private TKey _min;                

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MaxPqWithMin() : this(1) { }

        /// <summary>
        /// 建立指定容量的最大堆。
        /// </summary>
        /// <param name="capacity">最大堆的容量。</param>
        public MaxPqWithMin(int capacity)
        {
            _pq = new TKey[capacity + 1];
            _n = 0;
            _min = null;
        }

        /// <summary>
        /// 从已有元素建立一个最大堆。（O(n)）
        /// </summary>
        /// <param name="keys">已有元素。</param>
        public MaxPqWithMin(TKey[] keys)
        {
            _n = keys.Length;
            _pq = new TKey[keys.Length + 1];
            _min = null;

            if (_n == 0)
                return;

            // 复制元素的同时更新最小值。
            _min = keys[0];
            for (var i = 0; i < keys.Length; i++)
            {
                _pq[i + 1] = keys[i];
                if (_pq[i + 1].CompareTo(_min) < 0)
                    _min = _pq[i + 1];
            }

            for (var k = _n / 2; k >= 1; k--)
                Sink(k);
            Debug.Assert(IsMaxHeap());
        }

        /// <summary>
        /// 删除并返回最大元素。
        /// </summary>
        /// <returns>堆中的最大元素。</returns>
        /// <exception cref="ArgumentException">当堆为空时抛出该异常。</exception>
        /// <remarks>如果希望获得最大元素但不删除它，请使用 <see cref="Max"/>。</remarks>
        public TKey DelMax()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Priority Queue Underflow");

            var max = _pq[1];
            Exch(1, _n--);
            _pq[_n + 1] = _pq[1];
            Sink(1);
            _pq[_n + 1] = null;
            if ((_n > 0) && (_n == _pq.Length / 4))
                Resize(_pq.Length / 2);

            // 如果堆变为空。
            if (IsEmpty())
                _min = null;

            Debug.Assert(IsMaxHeap());
            return max;
        }

        /// <summary>
        /// 向堆中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(TKey v)
        {
            if (_n == _pq.Length - 1)
                Resize(2 * _pq.Length);

            // 更新最小值。
            if (_min == null)
                _min = v;
            else if (v.CompareTo(_min) < 0)
                _min = v;

            _pq[++_n] = v;
            Swim(_n);
            Debug.Assert(IsMaxHeap());
        }

        /// <summary>
        /// 检查堆是否为空。
        /// </summary>
        /// <returns>若堆为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => _n == 0;

        /// <summary>
        /// 获得堆中最大元素。
        /// </summary>
        /// <returns>堆中的最大元素。</returns>
        /// <remarks>如果希望删除并返回最大元素，请使用 <see cref="DelMax"/>。</remarks>
        public TKey Max() => _pq[1];

        /// <summary>
        /// 获得堆中的最小元素。
        /// </summary>
        /// <returns>堆中的最小元素。</returns>
        public TKey Min() => _min;

        /// <summary>
        /// 获得堆中元素的数量。
        /// </summary>
        /// <returns>堆中的元素数量。</returns>
        public int Size() => _n;

        /// <summary>
        /// 获取堆的迭代器，元素以降序排列。
        /// </summary>
        /// <returns>最大堆的迭代器。</returns>
        public IEnumerator<TKey> GetEnumerator()
        {
            var copy = new MaxPqWithMin<TKey>(_n);
            for (var i = 1; i <= _n; i++)
                copy.Insert(_pq[i]);

            while (!copy.IsEmpty())
                yield return copy.DelMax(); // 下次迭代的时候从这里继续执行。
        }

        /// <summary>
        /// 获取堆的迭代器，元素以降序排列。
        /// </summary>
        /// <returns>堆的迭代器。</returns>
        /// <remarks>实际上调用的是 <see cref="GetEnumerator"/>。</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 使元素上浮。
        /// </summary>
        /// <param name="k">需要上浮的元素。</param>
        private void Swim(int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Exch(k, k / 2);
                k /= 2;
            }
        }

        /// <summary>
        /// 使元素下沉。
        /// </summary>
        /// <param name="k">需要下沉的元素。</param>
        private void Sink(int k)
        {
            while (k * 2 <= _n)
            {
                var j = 2 * k;
                if (Less(j, j + 1))
                    j++;
                if (!Less(k, j))
                    break;
                Exch(k, j);
                k = j;
            }
        }

        /// <summary>
        /// 重新调整堆的大小。
        /// </summary>
        /// <param name="capacity">调整后的堆大小。</param>
        private void Resize(int capacity)
        {
            var temp = new TKey[capacity];
            for (var i = 1; i <= _n; i++)
            {
                temp[i] = _pq[i];
            }
            _pq = temp;
        }

        /// <summary>
        /// 判断堆中某个元素是否小于另一元素。
        /// </summary>
        /// <param name="i">判断是否较小的元素。</param>
        /// <param name="j">判断是否较大的元素。</param>
        /// <returns>若下标为 <paramref name="i"/> 的元素更小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Less(int i, int j)
            => _pq[i].CompareTo(_pq[j]) < 0;

        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="i">要交换的第一个元素下标。</param>
        /// <param name="j">要交换的第二个元素下标。</param>
        private void Exch(int i, int j)
        {
            var swap = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = swap;
        }

        /// <summary>
        /// 检查当前二叉树是不是一个最大堆。
        /// </summary>
        /// <returns>如果是则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool IsMaxHeap() => IsMaxHeap(1);

        /// <summary>
        /// 确定以 k 为根节点的二叉树是不是一个最大堆。
        /// </summary>
        /// <param name="k">需要检查的二叉树根节点。</param>
        /// <returns>如果是则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool IsMaxHeap(int k)
        {
            if (k > _n)
                return true;
            var left = 2 * k;
            var right = 2 * k + 1;
            if (left <= _n && Less(k, left))
                return false;
            if (right <= _n && Less(k, right))
                return false;

            return IsMaxHeap(left) && IsMaxHeap(right);
        }
    }
}
