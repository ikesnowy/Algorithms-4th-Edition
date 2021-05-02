using System;
using System.Diagnostics;
// ReSharper disable UnusedLocalFunctionReturnValue


// 简单解方程，注意顺序查找平均要查询一半的元素。
// 1000 * logN = N / 2
// N = 29718 左右
// 10000 * logN = N / 2
// N = 369939 左右

Console.WriteLine(@"n	sst(compare/time)	bst(compare/time)	ratio(compare/time)");
Test(29718, 29718);
Test(369939, 369939);
long binarySearchCompare;
long sequentialSearchCompare;

void Test(int n, int trial)
{
    binarySearchCompare = 0;
    sequentialSearchCompare = 0;
    Console.Write(n + "\t");

    var sw = new Stopwatch();
    var seedData = new int[n];
    for (var i = 0; i < n; i++)
        seedData[i] = i;
    Shuffle(seedData);

    var data = new TestNode[n];
    var dataSorted = new TestNode[n];
    var dataQuery = new TestNode[n];
    for (var i = 0; i < n; i++)
        data[i] = new TestNode { Value = seedData[i] };

    Array.Sort(seedData);
    for (var i = 0; i < n; i++)
        dataSorted[i] = new TestNode { Value = seedData[i] };

    Array.Copy(data, dataQuery, data.Length);
    Shuffle(dataQuery);

    // 测试 sst
    sw.Start();
    for (var i = 0; i < trial; i++)
    {
        SequentialSearch(data, dataQuery[i]);
    }

    sw.Stop();
    var sstTime = sw.ElapsedMilliseconds;
    Console.Write(sequentialSearchCompare + "/" + sstTime + "\t\t");

    // 测试 bst
    sw.Restart();
    for (var i = 0; i < trial; i++)
    {
        BinarySearch(dataSorted, dataQuery[i]);
    }

    sw.Stop();

    var bstTime = sw.ElapsedMilliseconds;
    Console.Write(binarySearchCompare + "/" + bstTime + "\t\t");

    // 比例
    Console.WriteLine((float)sequentialSearchCompare / binarySearchCompare + "/" + (float)sstTime / bstTime);
}

void Shuffle<T>(T[] array)
{
    for (var i = 0; i < array.Length; i++)
    {
        var p = i + new Random().Next(array.Length - i);
        var temp = array[p];
        array[p] = array[i];
        array[i] = temp;
    }
}

int SequentialSearch<T>(T[] a, T key) where T : IComparable<T>
{
    for (var i = 0; i < a.Length; i++)
    {
        var compare = a[i].CompareTo(key);
        sequentialSearchCompare++;
        if (compare == 0)
            return i;
    }

    return -1;
}

int BinarySearch<T>(T[] a, T key) where T : IComparable<T>
{
    int lo = 0, hi = a.Length - 1;
    while (lo <= hi)
    {
        var mid = (lo + hi) / 2;
        var compare = a[mid].CompareTo(key);
        binarySearchCompare++;
        if (compare > 0)
            hi = mid - 1;
        else if (compare < 0)
            lo = mid + 1;
        else
            return mid;
    }

    return -1;
}

class TestNode : IComparable<TestNode>
{
    public long Value { get; init; }

    public int CompareTo(TestNode other)
    {
        return Value.CompareTo(other.Value);
    }
}