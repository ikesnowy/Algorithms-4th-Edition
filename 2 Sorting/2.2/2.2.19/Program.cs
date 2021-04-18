using System;
using _2._2._19;

var a = new[] { 1, 3, 5, 7, 2, 0 };
var mergeSort = new MergeSort();
mergeSort.Sort(a);
Console.WriteLine(mergeSort.Counter);