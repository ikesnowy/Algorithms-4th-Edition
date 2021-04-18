using System;

namespace PriorityQueue
{
    /// <summary>
    /// 面向中位数的堆。
    /// </summary>
    public class MedianPQ<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 最大堆（保存前半段元素）。
        /// </summary>
        /// <value>最大堆（保存前半段元素）。</value>
        private readonly MaxPQ<Key> maxPQ;
        /// <summary>
        /// 最小堆（保存后半段元素）。
        /// </summary>
        /// <value>最小堆（保存后半段元素）。</value>
        private readonly MinPQ<Key> minPQ;
        /// <summary>
        /// 中位数。
        /// </summary>
        /// <value>中位数。</value>
        private Key median;
        /// <summary>
        /// 堆的大小。
        /// </summary>
        /// <value>堆的大小。</value>
        private int n;

        /// <summary>
        /// 默认构造函数，构造一个面向中位数的堆。
        /// </summary>
        public MedianPQ()
        {
            maxPQ = new MaxPQ<Key>();
            minPQ = new MinPQ<Key>();
            median = default(Key);
            n = 0;
        }

        /// <summary>
        /// 构造一个指定容量的面向中位数的堆。
        /// </summary>
        /// <param name="capacity">初始容量。</param>
        public MedianPQ(int capacity)
        {
            maxPQ = new MaxPQ<Key>((capacity - 1) / 2);
            minPQ = new MinPQ<Key>((capacity - 1) / 2);
            n = 0;
            median = default(Key);
        }

        /// <summary>
        /// 根据指定数组初始化面向中位数的堆。
        /// </summary>
        /// <param name="keys">初始数组。</param>
        public MedianPQ(Key[] keys)
        {
            minPQ = new MinPQ<Key>();
            maxPQ = new MaxPQ<Key>();

            if (keys.Length == 0)
            {
                n = 0;
                median = default(Key);
                return;
            }

            n = keys.Length;
            median = keys[0];
            for (var i = 1; i < keys.Length; i++)
            {
                if (median.CompareTo(keys[i]) < 0)
                    minPQ.Insert(keys[i]);
                else
                    maxPQ.Insert(keys[i]);
            }

            UpdateMedian();
        }

        /// <summary>
        /// 向面向中位数的堆中插入一个元素。
        /// </summary>
        /// <param name="key">需要插入的元素。</param>
        public void Insert(Key key)
        {
            if (n == 0)
            {
                n++;
                median = key;
                return;
            }

            if (key.CompareTo(median) < 0)
                maxPQ.Insert(key);
            else
                minPQ.Insert(key);

            n++;
            UpdateMedian();
        }

        /// <summary>
        /// 删除并返回中位数。
        /// </summary>
        /// <returns>中位数。</returns>
        /// <exception cref="ArgumentOutOfRangeException">当堆为空时抛出该异常。</exception>
        /// <remarks>如果希望获得中位数但不将其删除，请使用 <see cref="Median"/>。</remarks>
        public Key DelMedian()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException("MedianPQ underflow!");
            var median = this.median;

            if (n == 1)
            {
                n--;
                this.median = default(Key);
                return median;
            }

            // 从较大的一侧堆中取元素作为新的中位数。
            if (minPQ.Size() > maxPQ.Size())
                this.median = minPQ.DelMin();
            else
                this.median = maxPQ.DelMax();

            n--;
            return median;
        }

        /// <summary>
        /// 获得中位数。
        /// </summary>
        /// <returns>中位数。</returns>
        /// <remarks>如果希望删除并返回中位数，请使用 <see cref="DelMedian"/>。</remarks>
        public Key Median() => median;

        /// <summary>
        /// 判断堆是否为空。
        /// </summary>
        /// <returns>若堆为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => n == 0;

        /// <summary>
        /// 更新中位数的值。
        /// </summary>
        private void UpdateMedian()
        {
            // 根据两个堆的大小调整中位数
            while (maxPQ.Size() - minPQ.Size() > 1)
            {
                minPQ.Insert(median);
                median = maxPQ.DelMax();
            }
            while (minPQ.Size() - maxPQ.Size() > 1)
            {
                maxPQ.Insert(median);
                median = minPQ.DelMin();
            }
        }
    }
}
