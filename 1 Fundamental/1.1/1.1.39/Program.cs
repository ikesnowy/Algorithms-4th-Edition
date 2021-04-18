using System;
// ReSharper disable UnusedParameter.Local

// 需要 6 秒左右的运算时间
var r = new Random();
var baseNum = 10;
var powNum = 3;
var T = 10;
var m = 4;

var matrix = new double[m, 2];

for (var i = 0; i < m; i++)
{
    var n = (int)Math.Pow(baseNum, powNum + i);
    double sum = 0;
    for (var j = 0; j < T; j++)
    {
        sum += Test(n, r.Next());
    }

    matrix[i, 0] = n;
    matrix[i, 1] = sum / T;
}

PrintMatrix(matrix);

static int Test(int n, int seed)
{
    var random = new Random(seed);
    var a = new int[n];
    var b = new int[n];
    var count = 0;

    for (var i = 0; i < n; i++)
    {
        a[i] = random.Next(100000, 1000000);
        b[i] = random.Next(100000, 1000000);
    }

    for (var i = 0; i < n; i++)
    {
        if (Rank(a[i], b) != -1)
            count++;
    }

    return count;
}

// 重载方法，用于启动二分查找
static int Rank(int key, int[] a)
{
    return RankInternal(key, a, 0, a.Length - 1, 1);
}

// 二分查找
static int RankInternal(int key, int[] a, int lo, int hi, int number)
{
    if (lo > hi)
    {
        return -1;
    }

    var mid = lo + (hi - lo) / 2;

    if (key < a[mid])
    {
        return RankInternal(key, a, lo, mid - 1, number + 1);
    }
    else if (key > a[mid])
    {
        return RankInternal(key, a, mid + 1, hi, number + 1);
    }
    else
    {
        return mid;
    }
}

static void PrintMatrix(double[,] a)
{
    for (var i = 0; i < a.GetLength(0); i++)
    {
        for (var j = 0; j < a.GetLength(1); j++)
        {
            Console.Write($@"	{a[i, j]}");
        }

        Console.Write(@"
");
    }
}