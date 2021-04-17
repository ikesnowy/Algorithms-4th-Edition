using System;

const int m = 10; // 数组大小
const int n = 1000; // 打乱次数
var a = new int[10];

var result = new int[m, m];

for (var i = 0; i < n; i++)
{
    // 初始化
    for (var j = 0; j < a.Length; j++)
    {
        a[j] = j;
    }

    // 打乱
    Shuffle(a, i);

    // 记录
    for (var j = 0; j < m; j++)
    {
        result[a[j], j]++;
    }
}

PrintMatrix(result);

static void Shuffle(int[] a, int seed)
{
    var n = a.Length;
    var random = new Random(seed);
    for (var i = 0; i < n; i++)
    {
        var r = i + random.Next(n - i); // 等于StdRandom.uniform(N-i)
        var temp = a[i];
        a[i] = a[r];
        a[r] = temp;
    }
}

static void PrintMatrix(int[,] a)
{
    for (var i = 0; i < a.GetLength(0); i++)
    {
        for (var j = 0; j < a.GetLength(1); j++)
        {
            Console.Write($"\t{a[i, j]}");
        }

        Console.Write("\n");
    }
}