using System;
using Sort;

// 选择排序的耗时与输入值的内容无关，不受影响。
// 对于插入排序，以上几种情况都是重复值较多的情况，插入排序的速度会加快。
// 希尔排序本质上也是插入排序，因此也会更快一些。
var n = 10000;
var insertionSort = new InsertionSort();
var selectionSort = new SelectionSort();
var shellSort = new ShellSort();
var arraySelection = new int[n];
var arrayShell = new int[n];

// 对照，完全随机
var arrayInsertion = HalfZeroHalfOne(n);
arrayInsertion.CopyTo(arraySelection, 0);
arrayInsertion.CopyTo(arrayShell, 0);
Console.WriteLine(@"totally random");
Console.WriteLine("Insertion Sort:" + SortCompare.TimeRandomInput(insertionSort, n, 1));
Console.WriteLine("Selection Sort:" + SortCompare.TimeRandomInput(selectionSort, n, 1));
Console.WriteLine("Shell Sort:" + SortCompare.TimeRandomInput(shellSort, n, 1));
Console.WriteLine();

// 一半是 0 一半是 1
arrayInsertion = HalfZeroHalfOne(n);
arrayInsertion.CopyTo(arraySelection, 0);
arrayInsertion.CopyTo(arrayShell, 0);
Console.WriteLine(@"half 0 and half 1");
Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, arrayInsertion));
Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, arraySelection));
Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, arrayShell));
Console.WriteLine();

// 一半是 0， 1/4 是 1， 1/8 是 2……
arrayInsertion = HalfAndHalf(n);
arrayInsertion.CopyTo(arraySelection, 0);
arrayShell.CopyTo(arrayShell, 0);
Console.WriteLine(@"half and half and half ...");
Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, arrayInsertion));
Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, arraySelection));
Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, arrayShell));
Console.WriteLine();

// 一半是 0，一半是随机 int 值
arrayInsertion = HalfZeroHalfRandom(n);
arrayInsertion.CopyTo(arraySelection, 0);
arrayShell.CopyTo(arrayShell, 0);
Console.WriteLine(@"half 0 half random");
Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, arrayInsertion));
Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, arraySelection));
Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, arrayShell));

// 获取一半是 0 一半是 1 的随机 <see cref="int"/> 数组。
static int[] HalfZeroHalfOne(int n)
{
    var result = new int[n];
    var random = new Random();
    for (var i = 0; i < n; i++)
    {
        if (random.NextDouble() >= 0.5)
        {
            result[i] = 0;
        }
        else
        {
            result[i] = 1;
        }
    }

    return result;
}

// 生成 1/2 为 0， 1/4 为 1， 1/8 为 2 …… 的 <see cref="int"/> 数组。
static int[] HalfAndHalf(int n)
{
    var array = new int[n];
    HalfIt(0, 0, n / 2, array);
    Shuffle(array);
    return array;
}

// 递归生成 1/2 为 0， 1/4 为 1， 1/8 为 2 …… 的 <see cref="int"/> 数组。
static int[] HalfIt(int start, int number, int length, int[] array)
{
    if (length == 0)
        return array;

    for (var i = 0; i < length; i++)
    {
        array[start + i] = number;
    }

    return HalfIt(start + length, number + 1, length / 2, array);
}

// 生成一半是 0 一半是随机整数的 <see cref="int"/> 数组。
static int[] HalfZeroHalfRandom(int n)
{
    var array = new int[n];
    var random = new Random();
    for (var i = 0; i < n / 2; i++)
    {
        array[i] = 0;
    }

    for (var i = n / 2; i < n; i++)
    {
        array[i] = random.Next();
    }

    Shuffle(array);

    return array;
}

// 打乱数组。
static void Shuffle(int[] a)
{
    var n = a.Length;
    var random = new Random();
    for (var i = 0; i < n; i++)
    {
        var r = i + random.Next(n - i); // 等于StdRandom.uniform(N-i)
        var temp = a[i];
        a[i] = a[r];
        a[r] = temp;
    }
}