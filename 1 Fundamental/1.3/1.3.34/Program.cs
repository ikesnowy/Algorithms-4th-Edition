using System;
using _1._3._34;

var bag = new RandomBag<int>();
bag.Add(0);
bag.Add(1);
bag.Add(2);
bag.Add(3);
bag.Add(4);
bag.Add(5);

var times = new double[6];
var count = 100000;

for (var i = 0; i < count; i++)
{
    var current = 0;
    foreach (var n in bag)
    {
        times[current] += n;
        current++;
    }
}

for (var i = 0; i < 6; i++)
{
    times[i] /= count;
}

foreach (var d in times)
{
    Console.Write(d + " ");
}

Console.WriteLine();