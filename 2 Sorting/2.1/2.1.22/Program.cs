using System;
using _2._1._22;
using Sort;

var a = new Transaction[4];

// 样例输入  
// Turing 6/17/1990 644.08
// Tarjan 3/26/2002 4121.85
// Knuth 6/14/1999 288.34
// Dijkstra 8/22/2007 2678.40

for (var i = 0; i < a.Length; i++)
{
    var input = Console.ReadLine();
    a[i] = new Transaction(input);
}

var insertionSort = new InsertionSort();

Console.WriteLine(@"Unsorted");
for (var i = 0; i < a.Length; i++)
{
    Console.WriteLine(a[i]);
}

Console.WriteLine();

Console.WriteLine(@"Sort by date");
insertionSort.Sort(a, new Transaction.WhenOrder());
for (var i = 0; i < a.Length; i++)
    Console.WriteLine(a[i]);
Console.WriteLine();

Console.WriteLine(@"Sort by customer");
insertionSort.Sort(a, new Transaction.WhoOrder());
for (var i = 0; i < a.Length; i++)
    Console.WriteLine(a[i]);
Console.WriteLine();

Console.WriteLine(@"Sort by amount");
insertionSort.Sort(a, new Transaction.HowMuchOrder());
for (var i = 0; i < a.Length; i++)
    Console.WriteLine(a[i]);
Console.WriteLine();