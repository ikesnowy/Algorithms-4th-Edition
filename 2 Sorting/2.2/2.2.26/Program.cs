using System;
using _2._2._26;
using Merge;

var auxInSort = new AuxInSortMergeSort();
var auxInMerge = new AuxInMergeMergeSort();
var data1 = SortCompare.GetRandomArrayInt(100000);
var data2 = new int[data1.Length];
data1.CopyTo(data2, 0);
Console.WriteLine("在Sort中创建aux[]\t" + SortCompare.Time(auxInSort, data1) + "ms");
Console.WriteLine("在Merge中创建aux[]\t" + SortCompare.Time(auxInMerge, data2) + "ms");