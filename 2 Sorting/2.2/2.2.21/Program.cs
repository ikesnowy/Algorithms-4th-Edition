using System;
using Merge;

var name1 = new[] { "Noah", "Liam", "Jacob", "Mason" };
var name2 = new[] { "Sophia", "Emma", "Mason", "Ava" };
var name3 = new[] { "Mason", "Marcus", "Alexander", "Ava" };

var mergeSort = new MergeSort();
mergeSort.Sort(name1);
mergeSort.Sort(name2);
mergeSort.Sort(name3);

for (var i = 0; i < name1.Length; i++)
{
    if (BinarySearch(name1[i], name2, 0, name1.Length) != -1
        && BinarySearch(name1[i], name3, 0, name1.Length) != -1)
    {
        Console.WriteLine(name1[i]);
        break;
    }
}

// 二分查找，返回目标元素的下标，没有结果则返回 -1。
static int BinarySearch<T>(T key, T[] array, int lo, int hi) where T : IComparable<T>
{
    while (lo <= hi)
    {
        var mid = lo + (hi - lo) / 2;
        if (array[mid].Equals(key))
            return mid;
        else if (array[mid].CompareTo(key) < 0)
            lo = mid + 1;
        else
            hi = mid - 1;
    }

    return -1;
}