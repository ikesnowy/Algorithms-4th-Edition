using System;
// ReSharper disable ForStatementConditionIsTrue

// HN 指的是调和级数
var random = new Random();
var N = 10000;
var a = new bool[N];
var randomSize = 0;
int times;
for (times = 0; times < 20; times++)
{
    for (var i = 0; i < N; i++)
    {
        a[i] = false;
    }

    for (var i = 0; true; i++)
    {
        var now = random.Next(N);
        a[now] = true;
        if (IsAllGenerated(a))
        {
            randomSize += i;
            Console.WriteLine($@"生成{i}次后所有可能均出现过了");
            break;
        }
    }
}

Console.WriteLine($@"NHN={N * HarmonicSum(N)}，平均生成{randomSize / times}个数字后所有可能都出现");

// 计算 N 阶调和级数的和。
static double HarmonicSum(int n)
{
    double sum = 0;
    for (var i = 1; i <= n; i++)
    {
        sum += 1.0 / i;
    }

    return sum;
}

// 检查所有数字是否都生成过了。
static bool IsAllGenerated(bool[] a)
{
    foreach (var i in a)
    {
        if (!i)
            return false;
    }

    return true;
}