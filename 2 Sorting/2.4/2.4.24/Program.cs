using System;
using PriorityQueue;
// ReSharper disable RedundantJumpStatement

var pq = new MaxPQLinked<char>();
var pq2 = new MaxPQ<char>();
// 利用 2.4.6 的输入做测试
var input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
foreach (var c in input)
{
    if (c == ' ')
    {
        continue;
    }
    else if (c == '*')
    {
        Console.WriteLine(pq.DelMax() + " " + pq2.DelMax());
    }
    else
    {
        pq.Insert(c);
        pq2.Insert(c);
    }
}