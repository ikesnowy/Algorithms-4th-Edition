using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
// ReSharper disable UnusedLocalFunctionReturnValue

var allNumbers = File.ReadAllLines("largeW.txt");
var n = allNumbers.Length;
var input = new int[n];
for (var i = 0; i < n; i++)
{
    input[i] = int.Parse(allNumbers[i]);
}

MinAndMax(input);
Console.WriteLine();
MidNumber(input);
Console.WriteLine();
NumberK(4, input);
Console.WriteLine();
SquareSum(input);
Console.WriteLine();
AboveAverage(input);
Console.WriteLine();
Ascending(input);
Console.WriteLine();
Shuffle(input);
Console.WriteLine();

static void MinAndMax(int[] input)
{
    // 只用到了两个变量
    var min = input[0];
    var max = input[0];

    // 只对输入值正向遍历一遍，不需要保存
    for (var i = 1; i < input.Length; i++)
    {
        if (input[i] > max)
        {
            max = input[i];
        }

        if (input[i] < min)
        {
            min = input[i];
        }
    }

    Console.WriteLine(@"Min and Max:");
    Console.WriteLine($@"Min: {min}
Max: {max}");
}

static int MidNumber(int[] input)
{
    // 需要对输入值进行去重 & 排序，故需要保存
    var distinctNumbers = new List<int>(input.Distinct());
    distinctNumbers.Sort();
    Console.WriteLine(@"MidNumber:");
    Console.WriteLine(distinctNumbers[distinctNumbers.Count / 2]);

    return distinctNumbers[distinctNumbers.Count / 2];
}

static int NumberK(int k, int[] input)
{
    var temp = new int[101];

    // 只正向遍历一遍，不需要保存
    for (var i = 0; i < input.Length; i++)
    {
        if (i < 100)
        {
            temp[i] = input[i];
        }
        else
        {
            temp[100] = input[i];
            Array.Sort(temp);
        }
    }

    Console.WriteLine(@"NumberK");
    Console.WriteLine($@"No.k: {temp[k - 1]}");

    return temp[k - 1];
}

static long SquareSum(int[] input)
{
    long sum = 0;
    // 只正向遍历一遍，不需要保存
    for (var i = 0; i < input.Length; i++)
    {
        sum += input[i] * input[i];
    }

    Console.WriteLine(@"Sum Of Square:");
    Console.WriteLine(sum);

    return sum;
}

static double Average(int[] input)
{
    long sum = 0;

    // 只遍历一遍，且不保存整个数组
    for (var i = 0; i < input.Length; i++)
    {
        sum += input[i];
    }

    var ave = sum / (double)input.Length;

    Console.WriteLine(@"Average:");
    Console.WriteLine(ave);

    return ave;
}

static double AboveAverage(int[] input)
{
    var ave = Average(input);
    Console.WriteLine();
    double count = 0;

    for (var i = 0; i < input.Length; i++)
    {
        if (input[i] > ave)
        {
            count++;
        }
    }

    Console.WriteLine(@"AboveAverage:");
    Console.WriteLine($@"{(count / input.Length) * 100}%");

    return count;
}

static void Ascending(int[] input)
{
    Array.Sort(input);

    Console.WriteLine(@"Ascending:");
    for (var i = 0; i < input.Length; i++)
    {
        Console.Write($" {input[i]}");
    }

    Console.Write("\n");
}

static void Shuffle(int[] input)
{
    var random = new Random();
    var all = new List<int>(input);
    var n = input.Length;

    Console.WriteLine(@"Shuffle:");
    for (var i = 0; i < n; i++)
    {
        var temp = random.Next(0, all.Count - 1);
        Console.Write($" {all[temp]}");
        all.RemoveAt(temp);
    }
}