using System;

namespace PriorityQueue
{
    /// <summary>
    /// 前序堆排序类，提供堆排序的静态方法。
    /// </summary>
    public static class HeapPreorderAnalysis
    {
        private static long _compareTimes;

        /// <summary>
        /// 利用堆排序对数组进行排序。
        /// </summary>
        /// <param name="pq">需要排序的数组。</param>
        public static long Sort<T>(T[] pq) where T : IComparable<T>
        {
            _compareTimes = 0;
            var n = pq.Length;
            BuildTree(pq, 0, pq.Length);
            // 排序
            while (n > 1)
            {
                var tail = GetTail<T>(0, n);
                var temp = pq[tail];
                for (var i = tail + 1; i < n; i++)
                    pq[i - 1] = pq[i];
                n--;
                Exch(pq, 0, n);
                pq[0] = temp;
                Sink(pq, 0, n);
            }
            return _compareTimes;
        }

        /// <summary>
        /// 递归获得堆的最后一个元素。
        /// </summary>
        /// <typeparam name="T">堆中元素类型。</typeparam>
        /// <param name="p">当前位置。</param>
        /// <param name="n">堆的元素数目。</param>
        /// <returns>最后一个元素的下标。</returns>
        private static int GetTail<T>(int p, int n)
        {
            if (n <= 1)
                return p;
            var k = (int)(Math.Log10(n) / Math.Log10(2));   // 高度

            var left = (int)Math.Pow(2, k - 1) - 1;
            var right = left;
            if (n - left <= (int)Math.Pow(2, k))
            {
                // 叶子结点全在左侧
                left = n - right - 1;
                return GetTail<T>(p + 1, left);
            }
            else
            {
                left = (int)Math.Pow(2, k) - 1;
                right = n - left - 1;
                return GetTail<T>(p + 1 + left, right);
            }
        }

        /// <summary>
        /// 递归建堆。
        /// </summary>
        /// <typeparam name="T">堆中元素。</typeparam>
        /// <param name="pq">堆所在的数组。</param>
        /// <param name="p">堆的起始下标。</param>
        /// <param name="n">堆的元素数目。</param>
        private static void BuildTree<T>(T[] pq, int p, int n) where T : IComparable<T>
        {
            if (n <= 1)
                return;
            var k = (int)(Math.Log10(n) / Math.Log10(2));   // 高度

            var left = (int)Math.Pow(2, k - 1) - 1;
            var right = left;
            if (n - left <= (int)Math.Pow(2, k))
            {
                // 叶子结点全在左侧
                left = n - right - 1;
            }
            else
            {
                left = (int)Math.Pow(2, k) - 1;
                right = n - left - 1;
            }

            BuildTree(pq, p + 1, left);
            BuildTree(pq, p + 1 + left, right);
            Sink(pq, p, n);
        }

        /// <summary>
        /// 令堆中的元素下沉。
        /// </summary>
        /// <param name="pq">需要执行操作的堆。</param>
        /// <param name="p">需要执行下沉的结点下标。</param>
        /// <param name="n">堆中元素的数目。</param>
        private static void Sink<T>(T[] pq, int p, int n) where T : IComparable<T>
        {
            if (n <= 1)
                return;
            var k = (int)(Math.Log10(n) / Math.Log10(2));   // 高度

            var left = (int)Math.Pow(2, k - 1) - 1;
            var right = left;
            if (n - left <= (int)Math.Pow(2, k))
            {
                // 叶子结点全在左侧
                left = n - right - 1;
            }
            else
            {
                left = (int)Math.Pow(2, k) - 1;
                right = n - left - 1;
            }

            // 找出较大的子结点
            int j = p + 1, size = left;
            if (right != 0) // 有右结点
            {
                if (Less(pq, j, p + left + 1))
                {
                    j = p + left + 1;
                    size = right;
                }
            }

            // 与根结点比较
            if (!Less(pq, p, j))
                return;

            // 交换，继续下沉
            Exch(pq, p, j);
            Sink(pq, j, size);
        }

        /// <summary>
        /// 比较堆中下标为 <paramref name="a"/> 的元素是否小于下标为 <paramref name="b"/> 的元素。
        /// </summary>
        /// <param name="pq">元素所在的数组。</param>
        /// <param name="a">需要比较是否较小的结点序号。</param>
        /// <param name="b">需要比较是否较大的结点序号。</param>
        /// <returns></returns>
        private static bool Less<T>(T[] pq, int a, int b) where T : IComparable<T>
        {
            _compareTimes++;
            return pq[a].CompareTo(pq[b]) < 0;
        }


        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="pq">要交换的元素所在堆。</param>
        /// <param name="a">要交换的结点序号。</param>
        /// <param name="b">要交换的结点序号。</param>
        private static void Exch<T>(T[] pq, int a, int b)
        {
            var temp = pq[a];
            pq[a] = pq[b];
            pq[b] = temp;
        }
    }
}
