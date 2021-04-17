using System;
using System.Diagnostics;
using UnionFind;

namespace _1._5._25
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 40;
            var t = 4;

            // quick-find
            Console.WriteLine(@"Quick-Find");
            long last = 0;
            long now = 0;
            for (var i = 0; i < t; i++, n *= 2)
            {
                Console.WriteLine("N:" + n * n);
                var connections = RandomGrid.GetConnections(n);

                var quickFind = new QuickFindUF(n * n);
                now = RunTest(quickFind, connections);
                if (last == 0)
                {
                    Console.WriteLine("平均用时（毫秒）：" + now);
                    last = now;
                }
                else
                {
                    Console.WriteLine("平均用时（毫秒）：" + now + "\t比值：" + (double)now / last);
                    last = now;
                }
            }

            // quick-union
            Console.WriteLine(@"Quick-Union");
            n = 40;
            for (var i = 0; i < t; i++, n *= 2)
            {
                Console.WriteLine("N:" + n * n);
                var connections = RandomGrid.GetConnections(n);

                var quickFind = new QuickUnionUF(n * n);
                now = RunTest(quickFind, connections);
                if (last == 0)
                {
                    Console.WriteLine("平均用时（毫秒）：" + now);
                    last = now;
                }
                else
                {
                    Console.WriteLine("平均用时（毫秒）：" + now + "\t比值：" + (double)now / last);
                    last = now;
                }
            }

            // 加权 quick-union
            Console.WriteLine(@"Weighted Quick-Union");
            n = 40;
            for (var i = 0; i < t; i++, n *= 2)
            {
                Console.WriteLine("N:" + n * n);
                var connections = RandomGrid.GetConnections(n);

                var quickFind = new WeightedQuickUnionUF(n * n);
                now = RunTest(quickFind, connections);
                if (last == 0)
                {
                    Console.WriteLine("平均用时（毫秒）：" + now);
                    last = now;
                }
                else
                {
                    Console.WriteLine("平均用时（毫秒）：" + now + "\t比值：" + (double)now / last);
                    last = now;
                }
            }
        }

        /// <summary>
        /// 进行若干次随机试验，输出平均 union 次数，返回平均耗时。
        /// </summary>
        /// <param name="uf">用于测试的并查集。</param>
        /// <param name="connections">用于测试的输入。</param>
        /// <returns>平均耗时。</returns>
        static long RunTest(UF uf, Connection[] connections)
        {
            var timer = new Stopwatch();
            long repeatTime = 3;
            timer.Start();
            for (var i = 0; i < repeatTime; i++)
            {
                ErdosRenyi.Count(uf, connections);
            }
            timer.Stop();

            return timer.ElapsedMilliseconds / repeatTime;
        }
    }
}
