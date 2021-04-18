using System;
using Sort;
using InsertionSort = _2._1._24.InsertionSort;

// 耗时 1019ms（@Surface Pro 3 i7 512G）
Console.WriteLine(SortCompare.TimeRandomInput(new InsertionSort(), 10000, 3) / 3.0);
// 耗时 925ms（@Surface Pro 3 i7 512G）
Console.WriteLine(SortCompare.TimeRandomInput(new Sort.InsertionSort(), 10000, 3) / 3.0);