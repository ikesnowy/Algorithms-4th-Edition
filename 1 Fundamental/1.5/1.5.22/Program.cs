using System;
using System.Diagnostics;
using UnionFind;

namespace _1._5._22
{
    class Program
    {
        static void Main(string[] args)
        {
            long lastTimeQuickFind = 0;
            long lastTimeQuickUnion = 0;
            long lastTimeWeightedQuickUnion = 0;

            long nowTime = 0;
            for (var n = 2000; n < 100000; n *= 2)
            {
                Console.WriteLine("N:" + n);
                var quickFindUF = new QuickFindUF(n);
                var quickUnionUF = new QuickUnionUF(n);
                var weightedQuickUnionUF = new WeightedQuickUnionUF(n);

                // quick-find
                Console.WriteLine(@"quick-find");
                nowTime = RunTest(quickFindUF);
                if (lastTimeQuickFind == 0)
                {
                    Console.WriteLine("用时：" + nowTime);
                    lastTimeQuickFind = nowTime;
                }
                else
                {
                    Console.WriteLine("用时：" + nowTime +
                        " 比值：" + (double)nowTime / lastTimeQuickFind);
                    lastTimeQuickFind = nowTime;
                }
                Console.WriteLine();

                // quick-union
                Console.WriteLine(@"quick-union");
                nowTime = RunTest(quickUnionUF);
                if (lastTimeQuickUnion == 0)
                {
                    Console.WriteLine("用时：" + nowTime);
                    lastTimeQuickUnion = nowTime;
                }
                else
                {
                    Console.WriteLine("用时：" + nowTime +
                        " 比值：" + (double)nowTime / lastTimeQuickUnion);
                    lastTimeQuickUnion = nowTime;
                }
                Console.WriteLine();

                // weighted-quick-union
                Console.WriteLine(@"weighted-quick-union");
                nowTime = RunTest(weightedQuickUnionUF);
                if (lastTimeWeightedQuickUnion == 0)
                {
                    Console.WriteLine("用时：" + nowTime);
                    lastTimeWeightedQuickUnion = nowTime;
                }
                else
                {
                    Console.WriteLine("用时：" + nowTime +
                        " 比值：" + (double)nowTime / lastTimeWeightedQuickUnion);
                    lastTimeWeightedQuickUnion = nowTime;
                }
                Console.WriteLine();

                Console.WriteLine();
            }

        }

        /// <summary>
        /// 进行若干次随机试验，输出平均 union 次数，返回平均耗时。
        /// </summary>
        /// <param name="uf">用于测试的并查集。</param>
        /// <returns>平均耗时。</returns>
        static long RunTest(UF uf)
        {
            var timer = new Stopwatch();
            var total = 0;
            var repeatTime = 10;
            timer.Start();
            for (var i = 0; i < repeatTime; i++)
            {
                total += ErdosRenyi.Count(uf);
            }
            timer.Stop();
            Console.WriteLine("平均次数：" + total / repeatTime);

            return timer.ElapsedMilliseconds / repeatTime;
        }
    }
}
