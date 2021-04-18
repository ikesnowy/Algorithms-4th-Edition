using System;
using _2._3._15;

// 思路：先随机拿起一个螺丝（枢轴），与所有的螺母比较，找到合适的那一个
// 再用找到的螺母与其他螺丝比较，将他们分为较大和较小两部分。
var bolts = new Bolt<int>[10];
var nuts = new Nut<int>[10];
for (var i = 0; i < 10; i++)
{
    bolts[i] = new Bolt<int>(i);
    nuts[i] = new Nut<int>(i);
}

var sort = new BoltsAndNuts();
sort.Sort(bolts, nuts);
for (var i = 0; i < 10; i++)
{
    Console.Write(bolts[i].Value + " ");
}

Console.WriteLine();
for (var i = 0; i < 10; i++)
{
    Console.Write(nuts[i].Value + " ");
}

Console.WriteLine();