using System;
using SortApplication;

namespace _2._5._7
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            // 根据书中的命题 U（中文版 P221，英文版 P347），
            // 当 k = 0 时，比较次数 ~2N。
            // 也可以参考快速排序的分析
            // Cn 代表找出 n 个元素的最小值所需的比较次数
            // Cn = 1/n * (n+1) + 1/n * (n+1+C1) +...+ 1/n * (n+1+C(n-1))
            // Cn = n+1 + 1/n * (C1 + ... + C(n-1))
            // nCn = n(n+1) + ... + C(n-1)
            // (n-1)C(n-1) = n(n-1) + C0 + ... + C(n-2)
            // nCn - (n-1)C(n-1) = 2n + C(n-1)
            // nCn = 2n + nC(n-1)
            // Cn = 2 + C(n-1)
            // Cn = 2n-2, n > 1.

            var multiBy10 = 5;
            var repeatTime = 100;
            var n = 10000;
            Console.WriteLine(@"n	Average Compare");
            for (var i = 0; i < multiBy10; i++)
            {
                long totalCompare = 0;
                for (var j = 0; j < repeatTime; j++)
                {
                    var quick = new QuickSortAnalyze();
                    quick.Select(GetRandomArray(n), 0);
                    totalCompare += quick.CompareCount;
                }
                Console.WriteLine("10^" + (i + 4) + "\t" + totalCompare / repeatTime);
                n *= 10;
            }

        }

        static int[] GetRandomArray(int n)
        {
            var array = new int[n];
            for (var i = 0; i < n; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }
    }
}