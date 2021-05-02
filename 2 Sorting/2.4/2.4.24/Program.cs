using System;
using PriorityQueue;
// ReSharper disable RedundantJumpStatement

var pq = new MaxPqLinked<char>();
var pq2 = new MaxPq<char>();
// 利用 2.4.6 的输入做测试
var input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
foreach (var c in input)
{
    if (c == ' ')
    {
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