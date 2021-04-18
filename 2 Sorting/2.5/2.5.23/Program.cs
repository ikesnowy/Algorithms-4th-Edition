using System;
using System.Diagnostics;
// ReSharper disable PossibleLossOfFraction
// ReSharper disable UnusedLocalFunctionReturnValue

// 使用 Floyd–Rivest 方法进行优化。
const int n = 1000000; // 数组大小
const int repeatTime = 50; // 重复次数
const int toFind = (int)(n * 0.8); // 需要寻找的 k 值

var a = new int[n];
for (var i = 0; i < n; i++)
    a[i] = i;
Shuffle(a);

var sw = new Stopwatch();
Console.WriteLine(@"Normal:");
for (var i = 0; i < repeatTime; i++)
{
    sw.Start();
    Select(a, toFind);
    sw.Stop();

    Shuffle(a);
}

Console.WriteLine(sw.ElapsedMilliseconds / repeatTime);

Console.WriteLine(@"Sampled:");
sw.Reset();
for (var i = 0; i < repeatTime; i++)
{
    sw.Start();
    SelectInternal(a, 0, a.Length - 1, toFind);
    sw.Stop();

    Shuffle(a);
}

Console.WriteLine(sw.ElapsedMilliseconds / repeatTime);

// 令 a[k] 变成第 k 小的元素。
static T Select<T>(T[] a, int k) where T : IComparable<T>
{
    if (k < 0 || k > a.Length)
        throw new IndexOutOfRangeException("SelectInternal elements out of bounds");
    int lo = 0, hi = a.Length - 1;
    while (hi > lo)
    {
        var i = Partition(a, lo, hi);
        if (i > k)
        {
            hi = i - 1;
        }
        else if (i < k)
        {
            lo = i + 1;
        }
        else
        {
            return a[i];
        }
    }

    return a[lo];
}

// Floyd–Rivest 方法优化，令 a[k] 变成第 k 小的元素。
static T SelectInternal<T>(T[] a, int lo, int hi, int k) where T : IComparable<T>
{
    if (k < 0 || k > a.Length)
    {
        throw new IndexOutOfRangeException("SelectInternal elements out of bounds");
    }
    while (hi > lo)
    {
        if (hi - lo > 600)
        {
            var n = hi - lo + 1;
            var i = k - lo + 1;
            var z = (int)Math.Log(n);
            var s = (int)(Math.Exp(2 * z / 3) / 2);
            var sd = (int)Math.Sqrt(z * s * (n - s) / n) * Math.Sign(i - n / 2) / 2;
            var newLo = Math.Max(lo, k - i * s / n + sd);
            var newHi = Math.Min(hi, k + (n - i) * s / n + sd);
            SelectInternal(a, newLo, newHi, k);
        }

        Exch(a, lo, k);
        var j = Partition(a, lo, hi);
        if (j > k)
        {
            hi = j - 1;
        }
        else if (j < k)
        {
            lo = j + 1;
        }
        else
        {
            return a[j];
        }
    }

    return a[lo];
}

// 对数组进行切分，返回枢轴位置。
static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
{
    int i = lo, j = hi + 1;
    var v = a[lo];
    while (true)
    {
        while (Less(a[++i], v))
            if (i == hi)
                break;
        while (Less(v, a[--j]))
            if (j == lo)
                break;
        if (i >= j)
            break;
        Exch(a, i, j);
    }

    Exch(a, lo, j);
    return j;
}

// 打乱数组。
static void Shuffle<T>(T[] a)
{
    var random = new Random();
    for (var i = 0; i < a.Length; i++)
    {
        var r = i + random.Next(a.Length - i);
        var temp = a[i];
        a[i] = a[r];
        a[r] = temp;
    }
}

// 比较第一个参数是否小于第二个参数。
static bool Less<T>(T v, T w) where T : IComparable<T>
{
    return v.CompareTo(w) < 0;
}

// 交换数组中下标为 i, j 的两个元素。
static void Exch<T>(T[] a, int i, int j)
{
    var t = a[i];
    a[i] = a[j];
    a[j] = t;
}