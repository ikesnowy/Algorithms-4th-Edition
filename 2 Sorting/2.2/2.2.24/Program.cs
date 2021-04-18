using System;
using Merge;
using MergeSortX = _2._2._24.MergeSortX;

var mergeSortX = new MergeSortX();
var n = 10000;
var trialTimes = 10;
Console.WriteLine(@"数组	平均命中次数");
for (var i = 0; i < 4; i++)
{
    var avgHit = 0;
    for (var j = 0; j < trialTimes; j++)
    {
        mergeSortX.ResetHitTime();
        var a = SortCompare.GetRandomArrayInt(n);
        mergeSortX.Sort(a);
        avgHit += mergeSortX.GetHitTime();
    }

    Console.WriteLine(n + "\t" + avgHit / trialTimes);
    n *= 10;
}