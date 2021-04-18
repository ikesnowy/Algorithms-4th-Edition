namespace _2._1._19
{
    class ShellSortWorstCase
    {
        /// <summary>
        /// 获得最坏情况的数组。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>希尔排序最坏情况的数组。</returns>
        public static int[] GetWorst(int n)
        {
            var l = 0;
            var a = new int?[n + 1];

            for (var i = 0; i < a.Length; i++)
            {
                a[i] = null;
            }
            var p = 40;
            var pAddition = p;
            for (var i = 0; l < 100; i++)
            {
                for (var j = 1; j <= n; j++)
                {
                    if (a[j] == null && IsVisible(j, p))
                    {
                        l++;
                        a[j] = l;
                    }
                }
                p += pAddition;
            }

            var b = new int[n];
            for (var i = 0; i < n; i++)
            {
                b[i] = (int)a[i + 1];
            }

            return b;
        }

        /// <summary>
        /// 确认 j - i 是不是在排序样板（Sorting Template）上。
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool IsVisible(int i, int j)
        {
            var k = 0;
            while (k <= 100)
            {
                if (j - i >= k * 40 && j - i <= k * 41)
                    return true;
                k++;
            }
            return false;
        }
    }
}
