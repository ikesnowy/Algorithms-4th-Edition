using System;
using PriorityQueue;

namespace _2._4._16
{
    class Program
    {
        static void Main(string[] args)
        {
            // 最好情况
            // 比较简单，键值完全相同的数组即可。
            // 最坏情况
            // 参考论文：https://arxiv.org/abs/1504.01459
            // 下面的代码能够生成最好和最坏情况并输出序列和比较次数。

            var size = 32;
            var bestCase = new int[size];
            for (var i = 0; i < size; i++)
                bestCase[i] = 1;

            Console.WriteLine(@"Best Input");
            for (var i = 0; i < size; i++)
                Console.Write(bestCase[i] + " ");
            Console.WriteLine();
            Console.Write("Best Compare Times: ");
            Console.WriteLine(HeapAnalysis.Sort(bestCase));

            Console.WriteLine();

            var pq = new MaxPQWorstCase(size);
            var worstCase = pq.MakeWorst(size);
            Console.WriteLine(@"Worst Input");
            for (var i = 0; i < worstCase.Length; i++)
                Console.Write(worstCase[i] + " ");
            Console.WriteLine();
            Console.Write("Worst Compare Times: ");
            Console.WriteLine(HeapAnalysis.Sort(worstCase));
        }
    }
}