using System;
using System.Diagnostics;
using PriorityQueue;

var doubleTime = 5;
var repeatTime = 5;
var n = 100000;

for (var i = 0; i < doubleTime; i++)
{
    long totalTime = 0;
    Console.WriteLine("n=" + n);
    for (var j = 0; j < repeatTime; j++)
    {
        var pq = new MaxPQ<int>(n);
        var time = Test(pq, n);
        Console.Write(time + "\t");
        totalTime += time;
    }

    Console.WriteLine("平均用时：" + totalTime / repeatTime + "毫秒");
    n *= 2;
}

long Test(MaxPQ<int> pq, int n)
{
    var random = new Random();
    // 生成数据
    var initData = new int[n];
    var appendData = new int[n / 2];
    for (var i = 0; i < n; i++)
        initData[i] = random.Next();
    for (var i = 0; i < n / 2; i++)
        appendData[i] = random.Next();

    // 开始测试
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    // 插入 n 个元素
    for (var i = 0; i < n; i++)
        pq.Insert(initData[i]);
    // 删去一半
    for (var i = 0; i < n / 2; i++)
        pq.DelMax();
    // 插入一半
    for (var i = 0; i < n / 2; i++)
        pq.Insert(appendData[i]);
    // 删除全部
    for (var i = 0; i < n; i++)
        pq.DelMax();

    stopwatch.Stop();
    return stopwatch.ElapsedMilliseconds;
}