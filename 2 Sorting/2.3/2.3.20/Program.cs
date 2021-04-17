using System;
using Quick;

namespace _2._3._20
{
    class Program
    {
        static void Main(string[] args)
        {
            var quickNormal = new QuickSort();
            var quickNonRecursive = new QuickSortNonRecursive();
            var arraySize = 200000;                         // 初始数组大小。
            const int trialTimes = 4;                       // 每次实验的重复次数。
            const int trialLevel = 5;                       // 双倍递增的次数。

            Console.WriteLine(@"n	non-recursive	normal	ratio");
            for (var i = 0; i < trialLevel; i++)
            {
                double timeRecursive = 0;
                double timeNormal = 0;
                for (var j = 0; j < trialTimes; j++)
                {
                    var a = SortCompare.GetRandomArrayInt(arraySize);
                    var b = new int[a.Length];
                    a.CopyTo(b, 0);
                    timeNormal += SortCompare.Time(quickNormal, b);
                    timeRecursive += SortCompare.Time(quickNonRecursive, a);

                }
                timeRecursive /= trialTimes;
                timeNormal /= trialTimes;
                Console.WriteLine(arraySize + "\t" + timeRecursive + "\t\t" + timeNormal + "\t" + timeRecursive / timeNormal);
                arraySize *= 2;
            }
        }
    }
}
