using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortApplication
{
    /// <summary>
    /// 最小堆。（数组实现）
    /// </summary>
    /// <typeparam name="TKey">最小堆中保存的元素类型。</typeparam>
    public class MinPq<TKey> : IMinPq<TKey>, IEnumerable<TKey> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 相等比较器。
        /// </summary>
        /// <value>相等比较器。</value>
        protected IEqualityComparer<TKey> EqualityComparer;
        /// <summary>
        /// 排序比较器。
        /// </summary>
        /// <value>排序比较器。</value>
        protected IComparer<TKey> Comparer;
        /// <summary>
        /// 保存元素的数组。
        /// </summary>
        /// <value>保存元素的数组。</value>
        protected TKey[] Pq;
        /// <summary>
        /// 堆中元素的数量。
        /// </summary>
        /// <value>堆中元素的数量。</value>
        protected int N;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MinPq() : this(1, null, null) { }

        /// <summary>
        /// 以指定大小构建最小堆。
        /// </summary>
        /// <param name="capacity">最小堆大小。</param>
        public MinPq(int capacity) : this(capacity, null, null) { }

        /// <summary>
        /// 根据指定比较器进行排序和相等判断。
        /// </summary>
        /// <param name="comparer">排序比较器。</param>
        public MinPq(IComparer<TKey> comparer) : this(1, comparer, null) { }

        /// <summary>
        /// 根据指定的比较器排序，并用指定比较器判断相等。
        /// </summary>
        /// <param name="comparer">排序比较器。</param>
        /// <param name="equality">相等比较器。</param>
        public MinPq(IComparer<TKey> comparer, IEqualityComparer<TKey> equality) : this(1, comparer, equality) { }

        /// <summary>
        /// 建立指定容量的最小堆。
        /// </summary>
        /// <param name="capacity">最小堆的容量。</param>
        /// <param name="comparer">排序比较器。</param>
        /// <param name="equality">相等比较器。</param>
        public MinPq(int capacity, IComparer<TKey> comparer, IEqualityComparer<TKey> equality)
        {
            EqualityComparer = equality;
            this.Comparer = comparer;
            Pq = new TKey[capacity + 1];
            N = 0;
        }

        /// <summary>
        /// 从已有元素建立一个最小堆。（O(n)）
        /// </summary>
        /// <param name="keys">已有元素。</param>
        public MinPq(TKey[] keys)
        {
            N = keys.Length;
            Pq = new TKey[keys.Length + 1];
            for (var i = 0; i < keys.Length; i++)
                Pq[i + 1] = keys[i];
            for (var k = N / 2; k >= 1; k--)
                Sink(k);
            Debug.Assert(IsMinHeap());
        }

        /// <summary>
        /// 检查是否存在指定元素。
        /// </summary>
        /// <param name="key">需要查找的元素。</param>
        /// <returns>存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(TKey key)
        {
            for (var i = 1; i <= N; i++)
                if (Equal(Pq[i], key))
                    return true;
            return false;
        }

        /// <summary>
        /// 删除并返回最小元素。
        /// </summary>
        /// <returns>最小元素。</returns>
        /// <exception cref="ArgumentOutOfRangeException">如果堆为空则抛出该异常。</exception>
        /// <remarks>如果希望获得最小值但不删除它，请使用 <see cref="Min"/>。</remarks>
        public TKey DelMin()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Priority Queue Underflow");

            var min = Pq[1];
            Exch(1, N--);
            Sink(1);
            Pq[N + 1] = default(TKey);
            if ((N > 0) && (N == Pq.Length / 4))
                Resize(Pq.Length / 2);

            // Debug.Assert(IsMinHeap());
            return min;
        }

        /// <summary>
        /// 删除指定元素。
        /// </summary>
        /// <param name="k">元素下标。</param>
        internal void Remove(int k)
        {
            if (k == N)
            {
                Pq[N--] = default(TKey);
                return;
            }
            else if (N <= 2)
            {
                Exch(1, k);
                Pq[N--] = default(TKey);
                return;
            }
            Exch(k, N--);
            Pq[N + 1] = default(TKey);
            Swim(k);
            Sink(k);
        }

        /// <summary>
        /// 向堆中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(TKey v)
        {
            if (N == Pq.Length - 1)
                Resize(2 * Pq.Length);

            Pq[++N] = v;
            Swim(N);
            // Debug.Assert(IsMinHeap());
        }

        /// <summary>
        /// 检查堆是否为空。
        /// </summary>
        /// <returns>如果堆为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => N == 0;

        /// <summary>
        /// 获得堆中最小元素。
        /// </summary>
        /// <returns>堆中最小元素。</returns>
        /// <remarks>如果希望获得并删除最小元素，请使用 <see cref="DelMin"/>。</remarks>
        public TKey Min() => Pq[1];

        /// <summary>
        /// 获得堆中元素的数量。
        /// </summary>
        /// <returns>堆中元素的数量。</returns>
        public int Size() => N;

        /// <summary>
        /// 获取堆的迭代器，元素以升序排列。
        /// </summary>
        /// <returns>最小堆的迭代器。</returns>
        public IEnumerator<TKey> GetEnumerator()
        {
            var copy = new MinPq<TKey>(N);
            for (var i = 1; i <= N; i++)
                copy.Insert(Pq[i]);

            while (!copy.IsEmpty())
                yield return copy.DelMin(); // 下次迭代的时候从这里继续执行。
        }

        /// <summary>
        /// 获取堆的迭代器，元素以升序排列。
        /// </summary>
        /// <returns>最小堆的迭代器。</returns>
        /// <remarks>该方法实际调用的是 <see cref="GetEnumerator"/> 方法。</remarks>
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
            while (k > 1 && Greater(k / 2, k))
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
            while (k * 2 <= N)
            {
                var j = 2 * k;
                if (j < N && Greater(j, j + 1))
                    j++;
                if (!Greater(k, j))
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
            for (var i = 1; i <= N; i++)
            {
                temp[i] = Pq[i];
            }
            Pq = temp;
        }

        /// <summary>
        /// 判断堆中某个元素是否大于另一元素。
        /// </summary>
        /// <param name="i">判断是否较大的元素。</param>
        /// <param name="j">判断是否较小的元素。</param>
        /// <returns>如果下标为 <paramref name="i"/> 的元素较大，则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Greater(int i, int j)
        {
            if (Comparer == null)
                return Pq[i].CompareTo(Pq[j]) > 0;
            else
                return Comparer.Compare(Pq[i], Pq[j]) > 0;
        }

        /// <summary>
        /// 判断两个元素是否相等。
        /// </summary>
        /// <param name="x">要判断相等的第一个元素。</param>
        /// <param name="y">要判断相等的第二个元素。</param>
        /// <returns>如果 <paramref name="x"/> 和 <paramref name="y"/> 相等则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Equal(TKey x, TKey y)
        {
            if (EqualityComparer == null)
                if (Comparer == null)
                    return x.CompareTo(y) == 0;
                else
                    return Comparer.Compare(x, y) == 0;
            else
                return EqualityComparer.Equals(x, y);
        }

        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="i">要交换的第一个元素下标。</param>
        /// <param name="j">要交换的第二个元素下标。</param>
        protected virtual void Exch(int i, int j)
        {
            var swap = Pq[i];
            Pq[i] = Pq[j];
            Pq[j] = swap;
        }

        /// <summary>
        /// 检查当前二叉树是不是一个最小堆。
        /// </summary>
        /// <returns>如果是则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool IsMinHeap() => IsMinHeap(1);

        /// <summary>
        /// 确定以 k 为根节点的二叉树是不是一个最小堆。
        /// </summary>
        /// <param name="k">需要检查的二叉树根节点。</param>
        /// <returns>如果是则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool IsMinHeap(int k)
        {
            if (k > N)
                return true;
            var left = 2 * k;
            var right = 2 * k + 1;
            if (left <= N && Greater(k, left))
                return false;
            if (right <= N && Greater(k, right))
                return false;

            return IsMinHeap(left) && IsMinHeap(right);
        }
    }
}
