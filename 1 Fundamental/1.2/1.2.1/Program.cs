using System;
using System.Collections.Generic;
using Geometry;
// ReSharper disable AssignNullToNotNullAttribute

Console.WriteLine("Type the value of N:");
var n = int.Parse(Console.ReadLine());
var pointList = new List<Point2D>();
var random = new Random();

if (n <= 2)
{
    Console.WriteLine("Make sure there are 2 points at least");
    return;
}

// random.NextDouble() 返回一个 0~1 之间的 double 值
for (var i = 0; i < n; i++)
{
    var x = random.NextDouble();
    var y = random.NextDouble();
    pointList.Add(new Point2D(x, y));
}

var min = pointList[0].DistanceTo(pointList[1]);
for (var i = 0; i < n; i++)
{
    for (var j = i + 1; j < n; j++)
    {
        var temp = pointList[i].DistanceTo(pointList[j]);
        Console.WriteLine($"Checking Distance({i}, {j}): {temp}");
        if (temp < min)
        {
            min = temp;
        }
    }
}

Console.WriteLine($"\nThe minimal distance is {min}");