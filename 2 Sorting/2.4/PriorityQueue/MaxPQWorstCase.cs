using System;

namespace PriorityQueue
{
    /// <summary>
    /// 生成最大堆的最坏情况。参考论文：https://arxiv.org/abs/1504.01459
    /// </summary>
    public class MaxPQWorstCase
    {
        /// <summary>
        /// 保存元素的数组。
        /// </summary>
        /// <value>保存元素的数组。</value>
        private readonly int[] pq;              
        /// <summary>
        /// 堆中的元素数量。
        /// </summary>
        /// <value>堆中的元素数量。</value>
        private int n;                 

        /// <summary>
        /// 建立指定容量的最大堆。
        /// </summary>
        /// <param name="capacity">最大堆的容量。</param>
        public MaxPQWorstCase(int capacity)
        {
            pq = new int[capacity + 1];
            n = 0;
        }

        /// <summary>
        /// 制造堆排序的最坏情况。
        /// </summary>
        /// <param name="n">需要构造的数组大小。</param>
        /// <returns>最坏情况的输入数组。</returns>
        public int[] MakeWorst(int n)
        {
            var strategy = Win(n);
            for (var i = 0; i < strategy.Length; i++)
            {
                UnRemoveMax(strategy[i]);
            }

            for (var i = 1; i <= this.n / 2; i++)
                UnFixHeap(i);

            var worstCase = new int[n];
            for (var i = 1; i <= n; i++)
                worstCase[i - 1] = pq[i];
            return worstCase;
        }

        private bool Less(int i, int j) => pq[i].CompareTo(pq[j]) < 0;
      
        private int PullDown(int i, int j)
        {
            var toReturn = pq[j];
            for (var m = j; m / 2 >= i; m /= 2)
            {
                pq[m] = pq[m / 2];
            }
            return toReturn;
        }

        private void UnFixHeap(int i)
        {
            var j = (int)(i * Math.Pow(2, Math.Floor(Math.Log10(n / i) / Math.Log10(2))));
            pq[i] = PullDown(i, j);
        }

        private void UnRemoveMax(int i)
        {
            var p = (n + 1) / 2;
            if (Less(p, i))
                return;
            n++;
            pq[n] = PullDown(1, i);
            pq[1] = n;
        }

        private int[] Par(int l)
        {
            var n = (int)Math.Pow(2, l) - 1;
            int[] s7 = { 0, 1, 2, 3, 4, 4, 5 };
            var strategy = new int[n];
            for (var i = 0; i < Math.Min(n, 7); i++)
            {
                strategy[i] = s7[i];
            }

            if (n <= 7)
                return strategy;

            for (var lev = 3; lev < l; lev++)
            {
                var i = (int)Math.Pow(2, lev) - 1;
                strategy[i] = i;
                strategy[i + 1] = i - 1;
                strategy[i + 2] = i + 1;
                strategy[i + 3] = i + 2;
                strategy[i + 4] = i + 4;
                strategy[i + 5] = i + 3;
                for (var k = i + 6; k <= 2 * i; k++)
                {
                    strategy[k] = k - 1;
                }
            }
            return strategy;
        }

        private int[] Win(int n)
        {
            var strategy = new int[n];
            var s = Par((int)Math.Floor(Math.Log10(n) / Math.Log10(2)) + 1);
            for (var i = 1; i <= n - 1; i++)
            {
                strategy[i] = s[i];
            }
            var I = (int)Math.Pow(2, Math.Floor(Math.Log10(n + 1) / Math.Log10(2))) - 1;
            if ((n == I) || (n <= 7))
                return strategy;
            strategy[I] = I;
            if (n == I + 1)
                return strategy;
            strategy[I + 1] = (I + 1) / 2;
            if (n == I + 2)
                return strategy;
            for (var i = I + 2; i <= n - 1; i++)
            {
                if (i == 2 * I - 2)
                    strategy[i] = i;
                else
                    strategy[i] = i - 1;
            }
            return strategy;
        }
    }
}
