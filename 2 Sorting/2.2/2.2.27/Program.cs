using System;
using _2._2._27;
using Merge;

var arraySize = 1000000;
var sort = new NotifiedMergeSort(arraySize);
for (var i = 0; i < 100; i++)
{
    var data = SortCompare.GetRandomArrayInt(arraySize);
    sort.Sort(data);
}

Console.WriteLine(@"n	rest	times");
for (var i = 0; i < sort.NArraySize.Length; i++)
{
    if (sort.NArraySize[i] != 0)
        Console.WriteLine(i + "\t" + sort.NArraySize[i] / sort.NArraySizeTime[i] + "\t" + sort.NArraySizeTime[i]);
}
// 大致上是一个对数函数