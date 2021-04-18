using System;
using Merge;

var mergeSort = new MergeSort();
var mergeSortX = new MergeSortX();
var mergeSortUnstable = new MergeSortUnstable();
var n = 1000000;
var cutoff = 2;
var trialTime = 4;
Console.WriteLine(@"归并排序改进前与改进后的比较：");
Console.WriteLine(@"数组	耗时1	耗时2	阈值	比率");
for (var i = 0; i < 20; i++)
{
    double mergeSortTime = 0;
    double mergeSortXTime = 0;
    mergeSortX.SetCutOff(cutoff);
    for (var j = 0; j < trialTime; j++)
    {
        var a = SortCompare.GetRandomArrayInt(n);
        var b = new int[a.Length];
        a.CopyTo(b, 0);
        mergeSortTime += SortCompare.Time(mergeSort, a);
        mergeSortXTime += SortCompare.Time(mergeSortX, b);
    }

    mergeSortTime /= trialTime;
    mergeSortXTime /= trialTime;
    Console.WriteLine(
        n + "\t" + mergeSortTime + "\t" + mergeSortXTime + "\t" + cutoff + "\t" + mergeSortTime / mergeSortXTime);
    cutoff++;
}

n = 100000;
Console.WriteLine(@"稳定归并排序与不稳定版本的比较：");
Console.WriteLine(@"数组	耗时1	耗时2	比率");
for (var i = 0; i < 6; i++)
{
    double mergeSortTime = 0;
    double mergeSortUnstableTime = 0;
    for (var j = 0; j < trialTime; j++)
    {
        var a = SortCompare.GetRandomArrayInt(n);
        var b = new int[a.Length];
        a.CopyTo(b, 0);
        mergeSortTime += SortCompare.Time(mergeSort, a);
        mergeSortUnstableTime += SortCompare.Time(mergeSortUnstable, b);
    }

    mergeSortTime /= trialTime;
    mergeSortUnstableTime /= trialTime;
    Console.WriteLine(
        n + "\t" + mergeSortTime + "\t" + mergeSortUnstableTime + "\t" + mergeSortTime / mergeSortUnstableTime);
    n *= 2;
}