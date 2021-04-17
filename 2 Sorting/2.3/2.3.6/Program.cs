using System;
using Quick;

namespace _2._3._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"N	准确值	估计值	比值");
            var sort = new QuickSortAnalyze();
            var N = 100;
            var trialTime = 500;
            for (var i = 0; i < 3; i++)
            {
                var sumOfCompare = 0;
                var a = new int[N];
                for (var j = 0; j < trialTime; j++)
                {
                    for (var k = 0; k < N; k++)
                    {
                        a[k] = k;
                    }
                    SortCompare.Shuffle(a);
                    sort.Sort(a);
                    sumOfCompare += sort.CompareCount;
                }
                var averageCompare = sumOfCompare / trialTime;
                var estimatedCompare = 2 * N * Math.Log(N);
                Console.WriteLine(N + "\t" + averageCompare + "\t" + (int)estimatedCompare + "\t" + averageCompare / estimatedCompare);
                N *= 10;
            }
        }
    }
}