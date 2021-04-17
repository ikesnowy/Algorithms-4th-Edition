using System;
using System.IO;

// 读取 largeW.txt
var allNums = File.ReadAllLines("largeW.txt");
var n = allNums.Length;
var a = new int[n];
var b = new int[n];

// 数组 a 与数组 b 数字顺序相反
for (var i = 0; i < n; i++)
{
    a[i] = int.Parse(allNums[i]);
    b[n - i - 1] = a[i];
}

// 输出前5个数字
Console.WriteLine(@"Before Swap");
Console.Write("a:");
for (var i = 0; i < 5; i++)
{
    Console.Write($" {a[i]}");
}

Console.WriteLine();
Console.Write("b:");
for (var i = 0; i < 5; i++)
{
    Console.Write($" {b[i]}");
}

Console.WriteLine();

// 交换
var t = a;
a = b;
b = t;

// 再次输出
Console.WriteLine(@"After Swap");
Console.Write("a:");
for (var i = 0; i < 5; i++)
{
    Console.Write($" {a[i]}");
}

Console.WriteLine();
Console.Write("b:");
for (var i = 0; i < 5; i++)
{
    Console.Write($" {b[i]}");
}

Console.WriteLine();