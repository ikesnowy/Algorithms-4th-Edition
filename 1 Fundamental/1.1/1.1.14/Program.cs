using System;
// ReSharper disable RedundantAssignment

const int n = 9;
Console.WriteLine($"{Lg(n)}");

// 利用循环逼近 n，得到 log2(n) 的值
static int Lg(int n)
{
    const int baseNumber = 2;
    var pow = 1;
    var sum = 2;

    for (pow = 1; sum < n; pow++)
    {
        sum *= baseNumber;
    }

    return pow - 1;
}