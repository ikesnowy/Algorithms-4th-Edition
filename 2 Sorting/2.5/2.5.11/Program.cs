using System;
using SortApplication;

// 插入排序
Console.WriteLine(@"Insertion Sort");
Test(new InsertionSort(), 7, 1);
// 选择排序
Console.WriteLine(@"Selection Sort");
Test(new SelectionSort(), 7, 1);
// 希尔排序
Console.WriteLine(@"Shell Sort");
Test(new ShellSort(), 7, 1);
// 归并排序
Console.WriteLine(@"Merge Sort");
Test(new MergeSort(), 7, 1);
// 快速排序
Console.WriteLine(@"Quick Sort");
var quick = new QuickSortAnalyze { NeedShuffle = false, NeedPath = false };
Test(quick, 7, 1);
// 堆排序
Console.WriteLine(@"Heap Sort");
var array = new Item<int>[7];
for (var i = 0; i < 7; i++)
    array[i] = new Item<int>(i, 1);
Heap.Sort(array);
for (var i = 0; i < 7; i++)
    Console.Write(array[i].Index + " ");
Console.WriteLine();

static void Test(BaseSort sort, int n, int constant)
{
    var array = new Item<int>[n];
    for (var i = 0; i < n; i++)
        array[i] = new Item<int>(i, constant);
    sort.Sort(array);
    for (var i = 0; i < n; i++)
        Console.Write(array[i].Index + " ");
    Console.WriteLine();
}

/// <summary>
/// 用来排序的元素，记录有自己的初始下标。
/// </summary>
/// <typeparam name="T"></typeparam>
class Item<T> : IComparable<Item<T>> where T : IComparable<T>
{
    public readonly int Index;
    public T Key;

    public Item(int index, T key)
    {
        Index = index;
        Key = key;
    }

    public int CompareTo(Item<T> other)
    {
        return Key.CompareTo(other.Key);
    }
}