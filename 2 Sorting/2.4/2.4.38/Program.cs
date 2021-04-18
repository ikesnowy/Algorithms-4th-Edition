using System;
using System.Linq;
using System.Diagnostics;
using PriorityQueue;

var random = new Random();
var n = 200000;
var repeatTimes = 5;
var doubleTimes = 4;
for (var i = 0; i < doubleTimes; i++)
{
    Console.WriteLine("number=" + n);
    // 升序数组
    long totalTime = 0;
    Console.Write(@"Ascending:	");
    for (var j = 0; j < repeatTimes; j++)
    {
        var pq = new MaxPq<int>(n);
        var data = GetAscending(n);
        var time = Test(pq, data);
        Console.Write(time + "\t");
        totalTime += time;
    }

    Console.WriteLine("Average:" + totalTime / repeatTimes);
    // 降序数组
    totalTime = 0;
    Console.Write(@"Descending:	");
    for (var j = 0; j < repeatTimes; j++)
    {
        var pq = new MaxPq<int>(n);
        var data = GetDescending(n);
        var time = Test(pq, data);
        Console.Write(time + "\t");
        totalTime += time;
    }

    Console.WriteLine("Average:" + totalTime / repeatTimes);
    // 全部元素相同
    totalTime = 0;
    Console.Write(@"All Same:	");
    for (var j = 0; j < repeatTimes; j++)
    {
        var pq = new MaxPq<int>(n);
        var data = GetSame(n, 17763);
        var time = Test(pq, data);
        Console.Write(time + "\t");
        totalTime += time;
    }

    Console.WriteLine("Average:" + totalTime / repeatTimes);
    // 只有两个值
    totalTime = 0;
    Console.Write(@"Binary Dist.:	");
    for (var j = 0; j < repeatTimes; j++)
    {
        var pq = new MaxPq<int>(n);
        var data = GetBinary(n, 15254, 17763);
        var time = Test(pq, data);
        Console.Write(time + "\t");
        totalTime += time;
    }

    Console.WriteLine("Average:" + totalTime / repeatTimes);
    n *= 2;
}

long Test(MaxPq<int> pq, int[] data)
{
    var sw = new Stopwatch();
    sw.Start();
    for (var i = 0; i < data.Length; i++)
    {
        pq.Insert(data[i]);
    }

    for (var i = 0; i < data.Length; i++)
    {
        pq.DelMax();
    }

    sw.Stop();
    return sw.ElapsedMilliseconds;
}

int[] GetAscending(int number)
{
    var ascending = new int[number];
    for (var i = 0; i < number; i++)
        ascending[i] = random.Next();
    Array.Sort(ascending);
    return ascending;
}

int[] GetDescending(int number)
{
    var descending = GetAscending(number);
    descending = descending.Reverse().ToArray();
    return descending;
}

int[] GetSame(int number, int v)
{
    var same = new int[number];
    for (var i = 0; i < number; i++)
    {
        same[i] = v;
    }

    return same;
}

int[] GetBinary(int number, int a, int b)
{
    var binary = new int[number];
    for (var i = 0; i < number; i++)
    {
        binary[i] = random.NextDouble() > 0.5 ? a : b;
    }

    return binary;
}