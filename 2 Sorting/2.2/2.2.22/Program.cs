using System;
using Merge;

namespace _2._2._22
{
    class Program
    {
        static void Main(string[] args)
        {
            var mergeSortThreeWay = new MergeSortThreeWay();
            var n = 131072;
            var trialTime = 5;
            double previousTime = 1;
            Console.WriteLine(@"数组	耗时	比率");
            for (var i = 0; i < 6; i++)
            {
                var time = SortCompare.TimeRandomInput(mergeSortThreeWay, n, trialTime);
                time /= trialTime;
                if (i == 0)
                    Console.WriteLine(n + "\t" + time + "\t----");
                else
                    Console.WriteLine(n + "\t" + time + "\t" + time / previousTime);
                previousTime = time;
                n *= 2;
            }
        }
    }
}