using System;
using Quick;

namespace _2._3._18
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var quickNormal = new QuickSort();
            var quickMedian = new QuickSortMedian3();
            var arraySize = 200000;                         // 初始数组大小。
            const int trialTimes = 4;                       // 每次实验的重复次数。
            const int trialLevel = 5;                       // 双倍递增的次数。

            Console.WriteLine(@"n	median	normal	ratio");
            for (var i = 0; i < trialLevel; i++)
            {
                double timeMedian = 0;
                double timeNormal = 0;
                for (var j = 0; j < trialTimes; j++)
                {
                    var a = SortCompare.GetRandomArrayInt(arraySize);
                    var b = new int[a.Length];
                    a.CopyTo(b, 0);
                    timeNormal += SortCompare.Time(quickNormal, b);
                    timeMedian += SortCompare.Time(quickMedian, a);

                }
                timeMedian /= trialTimes;
                timeNormal /= trialTimes;
                Console.WriteLine(arraySize + "\t" + timeMedian + "\t" + timeNormal + "\t" + timeMedian / timeNormal);
                arraySize *= 2;
            }
        }
    }
}
