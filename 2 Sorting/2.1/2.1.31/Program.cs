using System;
using Sort;

var n = 1000;

var insertion = new InsertionSort();
var selection = new SelectionSort();
var shell = new ShellSort();

double prevInsertion = 0;
double prevSelection = 0;
double prevShell = 0;

for (var i = 0; i < 10; i++)
{
    Console.WriteLine("N:" + n);
    var array = SortCompare.GetRandomArrayInt(n);
    var arrayBak = new int[n];
    array.CopyTo(arrayBak, 0);

    Console.WriteLine(@"	Insertion Sort");
    var now = SortCompare.Time(insertion, array);
    Console.WriteLine("\t\tActual Time(ms):" + now);
    if (i != 0)
    {
        Console.WriteLine("\t\tEstimate Time(ms):" + prevInsertion * 4);
        Console.WriteLine("\t\tRatio:" + now / prevInsertion);
    }

    prevInsertion = now;

    arrayBak.CopyTo(array, 0);

    Console.WriteLine(@"	Selection Sort");
    now = SortCompare.Time(selection, array);
    Console.WriteLine("\t\tActual Time(ms):" + now);
    if (i != 0)
    {
        Console.WriteLine("\t\tEstimate Time(ms):" + prevSelection * 4);
        Console.WriteLine("\t\tRatio:" + now / prevSelection);
    }

    prevSelection = now;

    arrayBak.CopyTo(array, 0);

    Console.WriteLine(@"	Shell Sort");
    now = SortCompare.Time(shell, array);
    Console.WriteLine("\t\tActual Time(ms):" + now);
    if (i != 0)
    {
        Console.WriteLine("\t\tEstimate Time(ms):" + prevShell * 2);
        Console.WriteLine("\t\tRatio:" + now / prevShell);
    }

    prevShell = now;

    n *= 2;
}