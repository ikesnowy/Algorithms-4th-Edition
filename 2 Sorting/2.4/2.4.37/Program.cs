using System;
using System.Timers;
using PriorityQueue;

var doubleTime = 6;
var repeatTime = 6;
var n = 1000000;
var isRunning = true;
for (var i = 0; i < doubleTime; i++)
{
    var totalDelCount = 0;
    Console.WriteLine("n=" + n);
    for (var j = 0; j < repeatTime; j++)
    {
        var pq = new MaxPq<int>(n);
        var delCount = Test(n, pq);
        totalDelCount += delCount;
        Console.Write(delCount + "\t");
    }

    Console.WriteLine("平均最大删除次数：" + totalDelCount / repeatTime);
    n *= 2;
}


int Test(int n, MaxPq<int> pq)
{
    var random = new Random();
    var timer = new Timer(1000);
    timer.Elapsed += StopRunning;
    for (var i = 0; i < n; i++)
    {
        pq.Insert(random.Next());
    }

    var delCount = 0;
    StartRunning();
    timer.Start();
    while (isRunning && !pq.IsEmpty())
    {
        pq.DelMax();
        delCount++;
    }

    timer.Stop();
    return delCount;
}

void StartRunning() => isRunning = true;
void StopRunning(object source, ElapsedEventArgs e) => isRunning = false;