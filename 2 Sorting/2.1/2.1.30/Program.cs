using System;
using Sort;
using System.Diagnostics;
using ShellSort = _2._1._30.ShellSort;

// t = 2, 3, 4
// t 大于 10 之后，由于每次排序 h 缩减的太快，
// 时间会越来越近似于直接插入排序。
var array = SortCompare.GetRandomArrayInt(1000000);
var array2 = new int[array.Length];
array.CopyTo(array2, 0);
var timer = new Stopwatch();

var bestTimes = new long[3];
var bestTs = new long[3];
for (var i = 0; i < bestTimes.Length; i++)
{
    bestTimes[i] = long.MaxValue;
    bestTs[i] = int.MaxValue;
}

var shellSort = new ShellSort();

for (var t = 2; t <= 1000000; t++)
{
    Console.WriteLine(t);

    timer.Restart();
    shellSort.Sort(array, t);
    var nowTime = timer.ElapsedMilliseconds;
    timer.Stop();
    Console.WriteLine("Elapsed Time:" + nowTime);
    for (var i = 0; i < bestTimes.Length; i++)
    {
        Console.Write("t:" + bestTs[i]);
        Console.WriteLine("\tTime:" + bestTimes[i]);
    }

    if (bestTimes[2] > nowTime)
    {
        bestTimes[2] = nowTime;
        bestTs[2] = t;
        Array.Sort(bestTimes, bestTs);
    }

    array2.CopyTo(array, 0);
}

for (var i = 0; i < bestTimes.Length; i++)
{
    Console.Write("t:" + bestTs[i]);
    Console.Write("\tTime:" + bestTimes[i]);
}