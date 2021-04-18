using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PriorityQueue
{
    /// <summary>
    /// 最大堆。（数组实现）
    /// </summary>
    /// <typeparam name="Key">最大堆中保存的元素类型。</typeparam>
    public class MaxPq<TKey> : IMaxPq<TKey>, IEnumerable<TKey> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 保存元素的数组。
        /// </summary>
        /// <value>保存元素的数组。</value>
        protected TKey[] pq;               
        /// <summary>
        /// 堆中的元素数量。
        /// </summary>
        /// <value>堆中的元素数量。</value>
        protected int n;                  

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MaxPq() : this(1) { }

        /// <summary>
        /// 建立指定容量的最大堆。
        /// </summary>
        /// <param name="capacity">最大堆的容量。</param>
        public MaxPq(int capacity)
        {
            pq = new TKey[capacity + 1];
            n = 0;
        }

        /// <summary>
        /// 从已有元素建立一个最大堆。（O(n)）
        /// </summary>
        /// <param name="keys">已有元素。</param>
        public MaxPq(TKey[] keys)
        {
            n = keys.Length;
            pq = new TKey[keys.Length + 1];
            for (var i = 0; i < keys.Length; i++)
                pq[i + 1] = keys[i];
            for (var k = n / 2; k >= 1; k--)
                Sink(k);
            Debug.Assert(IsMaxHeap());
        }

        /// <summary>
        /// 删除并返回最大元素。
        /// </summary>
        /// <returns>最大的元素。</returns>
        /// <exception cref="ArgumentOutOfRangeException">当堆为空时抛出该异常。</exception>
        /// <remarks>如果希望获得但不删除最大元素，请使用 <see cref="Max"/>。</remarks>
        public TKey DelMax()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException("Priority Queue Underflow");

            var max = pq[1];
            Exch(1, n--);
            Sink(1);
            pq[n + 1] = default(TKey);
            if ((n > 0) && (n == pq.Length / 4))
                Resize(pq.Length / 2);

            // Debug.Assert(IsMaxHeap());
            return max;
        }

        /// <summary>
        /// 向堆中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(TKey v)
        {
            if (n == pq.Length - 1)
                Resize(2 * pq.Length);

            pq[++n] = v;
            Swim(n);
            // Debug.Assert(IsMaxHeap());
        }

        /// <summary>
        /// 删除一个结点。
        /// </summary>
        /// <param name="k">结点下标。</param>
        internal void Remove(int k)
        {
            if (k == n)
            {
                pq[n--] = default(TKey);
                return;
            }
            else if (n <= 2)
            {
                Exch(1, k);
                pq[n--] = default(TKey);
                return;
            }
            Exch(k, n--);
            pq[n + 1] = default(TKey);
            Swim(k);
            Sink(k);
        }

        /// <summary>
        /// 检查堆是否为空。
        /// </summary>
        /// <returns>当堆为空时返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => n == 0;

        /// <summary>
        /// 获得堆中最大元素。
        /// </summary>
        /// <returns>堆中最大元素。</returns>
        /// <remarks>如果希望删除并返回最大元素，请使用 <see cref="DelMax"/>。</remarks>
        public TKey Max() => pq[1];

        /// <summary>
        /// 获得堆中元素的数量。
        /// </summary>
        /// <returns>堆中元素数量。</returns>
        public int Size() => n;

        /// <summary>
        /// 输出最大堆中的元素，元素之间用空格分隔。
        /// </summary>
        /// <returns>形如 A B C D 的字符串。</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 1; i < pq.Length; i++)
                sb.Append(pq[i] + " ");
            return sb.ToString();
        }

        /// <summary>
        /// 获取堆的迭代器，元素以降序排列。
        /// </summary>
        /// <returns>最大堆的迭代器。</returns>
        public IEnumerator<TKey> GetEnumerator()
        {
            var copy = new MaxPq<TKey>(n);
            for (var i = 1; i <= n; i++)
                copy.Insert(pq[i]);

            while (!copy.IsEmpty())
                yield return copy.DelMax(); // 下次迭代的时候从这里继续执行。
        }

        /// <summary>
        /// 获取堆的迭代器，元素以降序排列。
        /// </summary>
        /// <returns>最大堆的迭代器。</returns>
        /// <remarks>实际调用的是 <see cref="GetEnumerator"/> 方法。</remarks>
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
            while (k * 2 <= n)
            {
                var j = 2 * k;
                if (j < n && Less(j, j + 1))
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
            for (var i = 1; i <= n; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }

        /// <summary>
        /// 判断堆中某个元素是否小于另一元素。
        /// </summary>
        /// <param name="i">判断是否较小的元素。</param>
        /// <param name="j">判断是否较大的元素。</param>
        /// <returns>若下标为 <paramref name="i"/> 的元素较小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Less(int i, int j)
            => pq[i].CompareTo(pq[j]) < 0; 

        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="i">要交换的第一个元素下标。</param>
        /// <param name="j">要交换的第二个元素下标。</param>
        protected virtual void Exch(int i, int j)
        {
            var swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
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
            if (k > n)
                return true;
            var left = 2 * k;
            var right = 2 * k + 1;
            if (left <= n && Less(k, left))
                return false;
            if (right <= n && Less(k, right))
                return false;

            return IsMaxHeap(left) && IsMaxHeap(right);
        }
    }
}
