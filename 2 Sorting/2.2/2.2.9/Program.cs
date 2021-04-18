using System;
using Merge;

var merge = new MergeSort();
var data = SortCompare.GetRandomArrayInt(200);
merge.Sort(data);
for (var i = 0; i < data.Length; i++)
{
    Console.Write(data[i] + " ");
}