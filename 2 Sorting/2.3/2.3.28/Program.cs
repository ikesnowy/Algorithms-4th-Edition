using System;

namespace _2._3._28
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"M	N	Depth");
            Trial(10);
            Trial(20);
            Trial(50);
        }

        /// <summary>
        /// 进行一次测试。
        /// </summary>
        /// <param name="m">要使用的阈值</param>
        static void Trial(int m)
        {
            var sort = new QuickSortInsertion();
            var trialTime = 5;

            // 由于排序前有 Shuffle，因此直接输入有序数组。
            // M=10
            sort.M = m;
            var totalDepth = 0;
            for (var N = 1000; N < 10000000; N *= 10)
            {
                for (var i = 0; i < trialTime; i++)
                {
                    var a = new int[N];
                    for (var j = 0; j < N; j++)
                    {
                        a[j] = j;
                    }
                    sort.Sort(a);
                    totalDepth += sort.Depth;
                }
                Console.WriteLine(sort.M + "\t" + N + "\t" + totalDepth / trialTime);
            }
        }
    }
}
