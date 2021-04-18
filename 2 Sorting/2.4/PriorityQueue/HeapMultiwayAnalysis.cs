using System;

namespace PriorityQueue
{
    /// <summary>
    /// d 叉堆排序类，提供堆排序的静态方法，记录堆排序的比较次数。
    /// </summary>
    /// <typeparam name="T">需要排序的元素类型。</typeparam>
    public static class HeapMultiwayAnalysis
    {
        /// <summary>
        /// 堆排序的比较次数。
        /// </summary>
        private static long _compareTimes;

        /// <summary>
        /// 利用堆排序对数组进行排序，返回比较次数。
        /// </summary>
        /// <param name="pq">需要排序的数组。</param>
        /// <param name="d">堆的分叉数。</param>
        public static long Sort<T>(T[] pq, long d) where T : IComparable<T>
        {
            _compareTimes = 0;
            long n = pq.Length;
            // 建堆
            for (var k = (n - 2) / d + 1; k >= 1; k--)
            {
                Sink(pq, k, n, d);
            }
            // 排序
            while (n > 1)
            {
                Exch(pq, 1, n--);
                Sink(pq, 1, n, d);
            }
            return _compareTimes;
        }

        /// <summary>
        /// 令堆中的元素下沉。
        /// </summary>
        /// <param name="pq">需要执行操作的堆。</param>
        /// <param name="k">需要执行下沉的结点下标。</param>
        /// <param name="n">堆中元素的数目。</param>
        /// <param name="d">堆的分叉数。</param>
        private static void Sink<T>(T[] pq, long k, long n, long d) where T : IComparable<T>
        {
            while ((k - 1) * d + 2 <= n)
            {
                var j = d * (k - 1) + 2;
                try
                {
                    // 在 d 个子结点中找到最大的那个
                    for (long i = 1, q = j; i < d; i++)
                    {
                        if (q + i <= n && Less(pq, j, q + i))
                            j = q + i;
                    }
                    if (!Less(pq, k, j))
                        break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("j=" + j);
                    throw e;
                }

                Exch(pq, k, j);
                k = j;
            }
        }

        /// <summary>
        /// 比较堆中下标为 <paramref name="a"/> 的元素是否小于下标为 <paramref name="b"/> 的元素。
        /// </summary>
        /// <param name="pq">元素所在的数组。</param>
        /// <param name="a">需要比较是否较小的结点序号。</param>
        /// <param name="b">需要比较是否较大的结点序号。</param>
        /// <returns>如果下标为 <paramref name="a"/> 的元素较小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private static bool Less<T>(T[] pq, long a, long b) where T : IComparable<T>
        {
            _compareTimes++;
            try
            {
                return pq[a - 1].CompareTo(pq[b - 1]) < 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("a=" + a + "b=" + b);
                throw e;
            }
        }

        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="pq">要交换的元素所在堆。</param>
        /// <param name="a">要交换的结点序号。</param>
        /// <param name="b">要交换的结点序号。</param>
        private static void Exch<T>(T[] pq, long a, long b)
        {
            var temp = pq[a - 1];
            pq[a - 1] = pq[b - 1];
            pq[b - 1] = temp;
        }
    }
}
