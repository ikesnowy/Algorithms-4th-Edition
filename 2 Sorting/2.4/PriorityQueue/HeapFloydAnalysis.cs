using System;

namespace PriorityQueue
{
    /// <summary>
    /// 堆排序类，提供 Floyd 优化的堆排序的静态方法，同时记录比较次数。
    /// </summary>
    public static class HeapFloydAnalysis
    {
        private static long _compareCount;

        /// <summary>
        /// 利用堆排序对数组进行排序。返回比较次数。
        /// </summary>
        /// <param name="pq">需要排序的数组。</param>
        public static long Sort<T>(T[] pq) where T : IComparable<T>
        {
            _compareCount = 0;
            var n = pq.Length;
            // 建堆
            for (var k = n / 2; k >= 1; k--)
            {
                Sink(pq, k, n);
            }
            // 排序
            while (n > 1)
            {
                Exch(pq, 1, n--);
                SinkThenSwim(pq, 1, n);
            }
            return _compareCount;
        }

        /// <summary>
        /// 令堆中的元素下沉。
        /// </summary>
        /// <param name="pq">需要执行操作的堆。</param>
        /// <param name="k">需要执行下沉的结点下标。</param>
        /// <param name="n">堆中元素的数目。</param>
        private static void Sink<T>(T[] pq, int k, int n) where T : IComparable<T>
        {
            while (2 * k <= n)
            {
                var j = 2 * k;
                if (j < n && Less(pq, j, j + 1))
                    j++;
                if (!Less(pq, k, j))
                    break;
                Exch(pq, k, j);
                k = j;
            }
        }

        /// <summary>
        /// 先下沉后上浮。
        /// </summary>
        /// <typeparam name="T">堆中的元素类型。</typeparam>
        /// <param name="pq">包含堆元素的数组。</param>
        /// <param name="k">要下沉的元素。</param>
        /// <param name="n">元素数量。</param>
        private static void SinkThenSwim<T>(T[] pq, int k, int n) where T : IComparable<T>
        {
            while (2 * k <= n)
            {
                var j = 2 * k;
                if (j < n && Less(pq, j, j + 1))
                    j++;
                Exch(pq, k, j);
                k = j;
            }
            Swim(pq, k);
        }

        /// <summary>
        /// 使元素上浮。
        /// </summary>
        /// <param name="pq">优先队列。</param>
        /// <param name="k">需要上浮的元素。</param>
        private static void Swim<T>(T[] pq, int k) where T : IComparable<T>
        {
            while (k > 1 && Less(pq, k / 2, k))
            {
                Exch(pq, k, k / 2);
                k /= 2;
            }
        }

        /// <summary>
        /// 比较堆中下标为 <paramref name="a"/> 的元素是否小于下标为 <paramref name="b"/> 的元素。
        /// </summary>
        /// <param name="pq">元素所在的数组。</param>
        /// <param name="a">需要比较是否较小的结点序号。</param>
        /// <param name="b">需要比较是否较大的结点序号。</param>
        /// <returns>如果下标为 <paramref name="a"/> 的元素较小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private static bool Less<T>(T[] pq, int a, int b) where T : IComparable<T>
        {
            _compareCount++;
            return pq[a - 1].CompareTo(pq[b - 1]) < 0;
        }

        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="pq">要交换的元素所在堆。</param>
        /// <param name="a">要交换的结点序号。</param>
        /// <param name="b">要交换的结点序号。</param>
        private static void Exch<T>(T[] pq, int a, int b)
        {
            var temp = pq[a - 1];
            pq[a - 1] = pq[b - 1];
            pq[b - 1] = temp;
        }
    }
}
