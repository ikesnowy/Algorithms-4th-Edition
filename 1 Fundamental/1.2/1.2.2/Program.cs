using System;
using System.Collections.Generic;
using Geometry;
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

Console.WriteLine("Type the value of N:");
var n = int.Parse(Console.ReadLine());
var intervalList = new List<Interval1D>();

if (n < 2)
{
    Console.WriteLine("Make sure there are at least 2 Intervals");
    return;
}

// 读取并建立间隔数组
Console.WriteLine("Type the data, make sure there is a space between two numbers.\nExample: 0.5 1");
for (var i = 0; i < n; i++)
{
    var temp = Console.ReadLine();
    var lo = double.Parse(temp.Split(' ')[0]);
    var hi = double.Parse(temp.Split(' ')[1]);

    if (lo > hi)
    {
        var t = lo;
        lo = hi;
        hi = t;
    }

    intervalList.Add(new Interval1D(lo, hi));
}

// 判断是否相交并输出
for (var i = 0; i < n; i++)
{
    for (var j = i + 1; j < n; j++)
    {
        if (intervalList[i].Intersect(intervalList[j]))
        {
            Console.WriteLine($"{intervalList[i]} {intervalList[j]}");
        }
    }
}