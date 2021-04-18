using System;
using Merge;

var mergeSortX = new MergeSortX();
var a = new[] { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
mergeSortX.Sort(a);
for (var i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();