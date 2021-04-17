using System;
using System.Diagnostics;

// long 类型不够大，换成 UINT64 类型
// 用于保存计算结果的数组，UInt64? 代表可以赋值为普通 UInt64 类型的值以及 null 值
var fibnacciResults = new UInt64?[100];

/*
 * 测试环境
 * 
 * Surface Pro3 i7
 * i7 4650U + 8G
 * 
 */
var timer = Stopwatch.StartNew();
for (var n = 0; n < 100; n++)
{
    // 书本中的代码，非常慢，1小时后 n = 50
    // Console.WriteLine($"{n} {F(n)}");

    // 利用已知结果加速
    // 全部计算完毕耗时 84ms
    Console.WriteLine($"{n} {BetterF(n)}");
}

Console.WriteLine($"{timer.ElapsedMilliseconds} ms");

// 书中提供的代码
// ReSharper disable once UnusedLocalFunction
ulong F(int n)
{
    if (n == 0)
        return 0;
    if (n == 1)
        return 1;

    return F(n - 1) + F(n - 2);
}

// 更好的实现，将已经计算的结果保存，不必重复计算
ulong? BetterF(int n)
{
    if (n == 0)
        return 0;
    if (n == 1)
        return 1;

    if (fibnacciResults[n] != null) // 如果已经计算过则直接读取已知值
    {
        return fibnacciResults[n];
    }

    fibnacciResults[n] = BetterF(n - 1) + BetterF(n - 2);
    return fibnacciResults[n];
}