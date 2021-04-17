using System;
using Quick;

namespace _2._3._24
{
    class Program
    {
        static void Main(string[] args)
        {
            var quickNormal = new QuickSort();
            var sampleSort = new SampleSort();
            var arraySize = 1600000;                        // 初始数组大小。
            const int kSteps = 10;                          // 取样 k 值的递增次数。
            const int trialTimes = 1;                       // 每次实验的重复次数。
            const int trialLevel = 2;                       // 双倍递增的次数。

            Console.WriteLine(@"k	n		sample	normal	ratio");
            for (var i = 0; i < kSteps; i++)
            {
                var array = arraySize;
                for (var j = 0; j < trialLevel; j++)
                {
                    double timeSample = 0;
                    double timeNormal = 0;
                    for (var k = 0; k < trialTimes; k++)
                    {
                        var a = SortCompare.GetRandomArrayInt(array);
                        var b = new int[a.Length];
                        a.CopyTo(b, 0);
                        timeNormal += SortCompare.Time(quickNormal, b);
                        timeSample += SortCompare.Time(sampleSort, a);

                    }
                    timeSample /= trialTimes;
                    timeNormal /= trialTimes;
                    if (arraySize < 10000000)
                        Console.WriteLine(sampleSort.K + "\t" + array + "\t\t" + timeSample + "\t" + timeNormal + "\t" + timeSample / timeNormal);
                    else
                        Console.WriteLine(sampleSort.K + "\t" + array + "\t" + timeSample + "\t" + timeNormal + "\t" + timeSample / timeNormal);
                    array *= 2;
                }
                sampleSort.K++;
            }

        }
    }
}