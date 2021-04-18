using System;
using System.Diagnostics;
using _2._5._33;
using SortApplication;

var stopwatch = new Stopwatch();
var shellSort = new ShellSort();
var mergeSort = new MergeSort();
var quickSort = new QuickSort();

var n = 1000;
var nMultipleBy10 = 4;
for (var i = 0; i < nMultipleBy10; i++)
{
    Console.WriteLine("n=" + n);
    var trans = TransactionGenerator.Generate(n);

    var testCase = new Transaction[n];

    trans.CopyTo(testCase, 0);
    stopwatch.Restart();
    shellSort.Sort(testCase);
    stopwatch.Stop();
    Console.WriteLine("Shell Sort: " + stopwatch.ElapsedMilliseconds + " ms");

    trans.CopyTo(testCase, 0);
    stopwatch.Restart();
    mergeSort.Sort(testCase);
    stopwatch.Stop();
    Console.WriteLine("Merge Sort: " + stopwatch.ElapsedMilliseconds + " ms");

    trans.CopyTo(testCase, 0);
    stopwatch.Restart();
    quickSort.Sort(testCase);
    stopwatch.Stop();
    Console.WriteLine("Quick Sort: " + stopwatch.ElapsedMilliseconds + " ms");

    trans.CopyTo(testCase, 0);
    stopwatch.Restart();
    Heap.Sort(testCase);
    stopwatch.Stop();
    Console.WriteLine("Heap Sort: " + stopwatch.ElapsedMilliseconds + " ms");

    n *= 10;
}