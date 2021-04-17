using System;
using Quick;

namespace _2._3._8
{
    class Program
    {
        static void Main(string[] args)
        {
            // 约为 NlogN 次
            var sort = new QuickSortAnalyze();
            var N = 100;
            Console.WriteLine(@"N	Compare	NlogN");
            for (var i = 0; i < 4; i++)
            {
                var a = new int[N];
                for (var j = 0; j < a.Length; j++)
                {
                    a[j] = 1;
                }
                sort.Sort(a);
                Console.WriteLine(N + "\t" + sort.CompareCount + "\t" + N * Math.Log(N) / Math.Log(2));
                N *= 10;
            }

        }
    }
}