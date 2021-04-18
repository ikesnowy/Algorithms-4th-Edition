using System;
using Merge;

var n = 1000;
var topBottomMergeSort = new MergeSort();
var bottomUpMergeSort = new MergeSortBu();
var trialTimes = 100;
for (var i = 0; i < 4; i++)
{
    Console.Write("数组大小：" + n + "\t");
    int time1 = 0, time2 = 0;
    for (var j = 0; j < trialTimes; j++)
    {
        var data1 = SortCompare.GetRandomArrayDouble(n);
        var data2 = new double[n];
        data1.CopyTo(data2, 0);
        time1 += (int)SortCompare.Time(topBottomMergeSort, data1);
        time2 += (int)SortCompare.Time(bottomUpMergeSort, data2);
    }

    Console.WriteLine("自顶向下：" + time1 / trialTimes + "ms\t自底向上：" + time2 / trialTimes + "ms");
    n *= 10;
}