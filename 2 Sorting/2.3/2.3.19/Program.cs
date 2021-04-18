using System;
using _2._3._19;
using Quick;

var quickNormal = new QuickSort();
var quickMedian3 = new QuickSortMedian3();
var quickMedian5 = new QuickSortMedian5();
var arraySize = 200000; // 初始数组大小。
const int trialTimes = 4; // 每次实验的重复次数。
const int trialLevel = 6; // 双倍递增的次数。

Console.WriteLine(@"n	median5	median3	normal	median5/normal		median5/median3");
for (var i = 0; i < trialLevel; i++)
{
    double timeMedian3 = 0;
    double timeMedian5 = 0;
    double timeNormal = 0;
    for (var j = 0; j < trialTimes; j++)
    {
        var a = SortCompare.GetRandomArrayInt(arraySize);
        var b = new int[a.Length];
        var c = new int[a.Length];
        a.CopyTo(b, 0);
        a.CopyTo(c, 0);
        timeNormal += SortCompare.Time(quickNormal, a);
        timeMedian3 += SortCompare.Time(quickMedian3, b);
        timeMedian5 += SortCompare.Time(quickMedian5, c);
    }

    timeMedian5 /= trialTimes;
    timeMedian3 /= trialTimes;
    timeNormal /= trialTimes;
    Console.WriteLine(
        arraySize
        + "\t"
        + timeMedian5
        + "\t"
        + timeMedian3
        + "\t"
        + timeNormal
        + "\t"
        + timeMedian5 / timeNormal
        + "\t"
        + timeMedian5 / timeMedian3);
    arraySize *= 2;
}