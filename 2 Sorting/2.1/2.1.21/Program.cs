using System;
using _2._1._21;
using Sort;

var a = new Transaction[4];
a[0] = new Transaction("Turing 6/17/1990 644.08");
a[1] = new Transaction("Tarjan 3/26/2002 4121.85");
a[2] = new Transaction("Knuth 6/14/1999 288.34");
a[3] = new Transaction("Dijkstra 8/22/2007 2678.40");

Console.WriteLine(@"Unsorted");
for (var i = 0; i < a.Length; i++)
{
    Console.WriteLine(a[i]);
}

Console.WriteLine();

Console.WriteLine(@"Sort by amount");
var insertionSort = new InsertionSort();
insertionSort.Sort(a, new Transaction.HowMuchOrder());
for (var i = 0; i < a.Length; i++)
    Console.WriteLine(a[i]);
Console.WriteLine();