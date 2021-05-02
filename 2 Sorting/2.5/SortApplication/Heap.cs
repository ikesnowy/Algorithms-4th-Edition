using System;

namespace SortApplication
{
    /// <summary>
    /// 堆排序类，提供堆排序的静态方法。
    /// </summary>
    public static class Heap
    {
        /// <summary>
        /// 利用堆排序对数组进行排序。
        /// </summary>
        /// <param name="pq">需要排序的数组。</param>
        public static void Sort<T>(T[] pq) where T : IComparable<T>
        {
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
                Sink(pq, 1, n);
            }
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
        /// 比较堆中下标为 <paramref name="a"/> 的元素是否小于下标为 <paramref name="b"/> 的元素。
        /// </summary>
        /// <param name="pq">元素所在的数组。</param>
        /// <param name="a">需要比较是否较小的结点序号。</param>
        /// <param name="b">需要比较是否较大的结点序号。</param>
        /// <returns>如果 <paramref name="a"/> 比较小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private static bool Less<T>(T[] pq, int a, int b) where T : IComparable<T> => pq[a - 1].CompareTo(pq[b - 1]) < 0;

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
