using System;

// 非递归官网实现见：https://algs4.cs.princeton.edu/23quicksort/QuickPedantic.java.html
int[] a = { 2, 4, 1, 3, 5, 7, 9, 6 };
var t = Select(a, 2, 0, a.Length - 1);
for (var i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();
Console.WriteLine(t);

// 使 a[k] 变为第 k 小的数，k 从 0 开始。
// a[0] ~ a[k-1] 都小于等于 a[k], a[k+1]~a[n-1] 都大于等于 a[k]
static T Select<T>(T[] a, int k, int lo, int hi) where T : IComparable<T>
{
    if (k > a.Length || k < 0)
        throw new ArgumentOutOfRangeException("select out of bound");
    if (lo >= hi)
        return a[lo];

    var i = Partition(a, lo, hi);
    if (i > k)
        return Select(a, k, lo, i - 1);
    else if (i < k)
        return Select(a, k, i + 1, hi);
    else
        return a[i];
}

// 对数组进行切分，返回切分的位置。
static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
{
    var i = lo;
    var j = hi + 1;
    var v = a[lo];
    while (true)
    {
        while (a[++i].CompareTo(v) < 0)
            if (i == hi)
                break;
        while (v.CompareTo(a[--j]) < 0)
            if (j == lo)
                break;
        if (i >= j)
            break;

        var t = a[i];
        a[i] = a[j];
        a[j] = t;
    }

    var temp = a[lo];
    a[lo] = a[j];
    a[j] = temp;

    return j;
}