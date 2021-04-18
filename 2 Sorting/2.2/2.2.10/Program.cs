using System;
using _2._2._10;

var a = new[] { 2, 4, 6, 8, 10, 1, 3, 5, 7 };
var merge = new MergeSort();
merge.Sort(a);
for (var i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();