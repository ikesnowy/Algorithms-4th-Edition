using System;
using Sort;

var insertionSort = new InsertionSort();
var selectionSort = new SelectionSort();
var shellSort = new ShellSort();
var n = 10000;

// 高斯分布（正态分布）
var arrayInsertion = SortCompare.GetNormalDistributionArray(n);
var arraySelection = new double[n];
var arrayShell = new double[n];
arrayInsertion.CopyTo(arraySelection, 0);
arrayInsertion.CopyTo(arrayShell, 0);
Console.WriteLine(@"Normal Distribution:");
Console.WriteLine("Insertion: " + SortCompare.Time(insertionSort, arrayInsertion));
Console.WriteLine("Selection: " + SortCompare.Time(selectionSort, arraySelection));
Console.WriteLine("Shell: " + SortCompare.Time(shellSort, arrayShell));

// 泊松分布
arrayInsertion = SortCompare.GetPossionDistributionArray(n);
arrayInsertion.CopyTo(arraySelection, 0);
arrayInsertion.CopyTo(arrayShell, 0);
Console.WriteLine(@"Poission Distribution:");
Console.WriteLine("Insertion: " + SortCompare.Time(insertionSort, arrayInsertion));
Console.WriteLine("Selection: " + SortCompare.Time(selectionSort, arraySelection));
Console.WriteLine("Shell: " + SortCompare.Time(shellSort, arrayShell));

// 几何分布
arrayInsertion = SortCompare.GetGeometricDistributionArray(n, 0.3);
arrayInsertion.CopyTo(arraySelection, 0);
arrayInsertion.CopyTo(arrayShell, 0);
Console.WriteLine(@"Geometric Distribution:");
Console.WriteLine("Insertion: " + SortCompare.Time(insertionSort, arrayInsertion));
Console.WriteLine("Selection: " + SortCompare.Time(selectionSort, arraySelection));
Console.WriteLine("Shell: " + SortCompare.Time(shellSort, arrayShell));

// 离散分布
arrayInsertion = SortCompare.GetDiscretDistributionArray(n, new double[] { 0.1, 0.2, 0.3, 0.1, 0.1, 0.1, 0.1 });
arrayInsertion.CopyTo(arraySelection, 0);
arrayInsertion.CopyTo(arrayShell, 0);
Console.WriteLine(@"Discret Distribution:");
Console.WriteLine("Insertion: " + SortCompare.Time(insertionSort, arrayInsertion));
Console.WriteLine("Selection: " + SortCompare.Time(selectionSort, arraySelection));
Console.WriteLine("Shell: " + SortCompare.Time(shellSort, arrayShell));