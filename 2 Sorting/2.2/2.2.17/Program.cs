using System;
using _2._2._17;

var a = new LinkedList<int>();
a.Insert(1);
a.Insert(2);
a.Insert(3);
a.Insert(4);
a.Insert(5);
a.Insert(6);
a.Insert(7);
a.Insert(8);
a.Insert(9);
a.Insert(10);

var mergeSort = new MergeSortNatural();
mergeSort.Sort(a);
foreach (var i in a)
{
    Console.Write(i + " ");
}

Console.WriteLine();