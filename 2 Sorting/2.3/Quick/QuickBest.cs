namespace Quick
{
    /// <summary>
    /// 构建快速排序最佳情况的类。
    /// </summary>
    public class QuickBest
    {
        /// <summary>
        /// 构造函数，这个类不应该被实例化。
        /// </summary>
        private QuickBest() { }

        /// <summary>
        /// 构造适用于快速排序的最佳数组。
        /// </summary>
        /// <param name="n">数组长度。</param>
        /// <returns>适用于快速排序的最佳情况数组。</returns>
        public static int[] Best(int n)
        {
            var a = new int[n];
            for (var i = 0; i < n; i++)
            {
                a[i] = i;
            }
            Best(a, 0, n - 1);
            return a;
        }

        /// <summary>
        /// 递归的构造数组。
        /// </summary>
        /// <param name="a">需要构造的数组。</param>
        /// <param name="lo">构造的起始下标。</param>
        /// <param name="hi">构造的终止下标。</param>
        private static void Best(int[] a, int lo, int hi)
        {
            if (hi <= lo)
                return;
            var mid = lo + (hi - lo) / 2;
            Best(a, lo, mid - 1);
            Best(a, mid + 1, hi);
            Exch(a, lo, mid);
        }

        /// <summary>
        /// 交换数组中的两个元素。
        /// </summary>
        /// <param name="a">包含要交换元素的数组。</param>
        /// <param name="x">需要交换的第一个元素下标。</param>
        /// <param name="y">需要交换的第二个元素下标。</param>
        private static void Exch(int[] a, int x, int y)
        {
            var t = a[x];
            a[x] = a[y];
            a[y] = t;
        }
    }
}
