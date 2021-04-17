using System;

// 使用 0~N-1 的随机数会导致每次交换的数字可能相同
// 例如：
// 原数组： 1 2 3 4
// 第一次： 2 1 3 4 random = 1，第 0 个和第 1 个交换
// 第二次： 1 2 3 4 random = 0，第 1 个和第 0 个交换
const int m = 10; // 数组大小
const int n = 100000; // 打乱次数
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
        // int r = i + random.Next(N - i);
        var r = random.Next(n); // 返回的是 0 ~ N-1 之间的随机整数
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