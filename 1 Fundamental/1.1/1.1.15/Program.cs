using System;
using System.Linq;

var a = new int[10];
const int m = 10;
for (var i = 0; i < 10; i++)
{
    a[i] = i;
}

var result = Histogram(a, m);

Console.WriteLine($"a.length: {a.Length}");
Console.WriteLine($"sum of result array: {result.Sum()}");

static int[] Histogram(int[] a, int m)
{
    var result = new int[m];

    for (var i = 0; i < m; i++)
    {
        // 初始化
        result[i] = 0;

        // 遍历数组，计算数组中值为 i 的元素个数
        for (var j = 0; j < a.Length; j++)
        {
            if (a[j] == i) // 值为 i 的元素
            {
                result[i]++;
            }
        }
    }

    return result;
}