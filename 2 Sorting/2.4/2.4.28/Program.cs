using System;
using System.Diagnostics;
using _2._4._28;
using PriorityQueue;

// m 不变的情况下算法是 O(n) 的
// 因此预计时间是 n=10^5 的运行时间乘以 10^3 倍。
int n = 100000, m = 10000;
long prev = 0;
for (var i = 0; i < 6; i++)
{
    Console.Write("n= " + n + " m= " + m);
    var now = Test(m, n); // 获取当前 m,n 值的算法运行时间
    Console.Write("\t time=" + now);
    if (prev == 0)
    {
        prev = now;
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("\tratio=" + (double)now / prev);
        prev = now;
    }

    n *= 2;
}

// 进行一次测试。
static long Test(int m, int n)
{
    var pq = new MinPQ<EuclideanDistance3D>(m);
    var x = new int[n];
    var y = new int[n];
    var z = new int[n];
    var random = new Random();
    for (var i = 0; i < n; i++)
    {
        x[i] = random.Next();
        y[i] = random.Next();
        z[i] = random.Next();
    }

    var sw = new Stopwatch();
    sw.Start(); // 开始计时
    for (var i = 0; i < m; i++)
    {
        // 先插入 m 个记录
        pq.Insert(new EuclideanDistance3D(x[i], y[i], z[i]));
    }

    for (var i = m; i < n; i++)
    {
        // 插入剩余 n-m 个记录
        pq.DelMin();
        pq.Insert(new EuclideanDistance3D(x[i], y[i], z[i]));
    }

    while (pq.IsEmpty())
        pq.DelMin();
    sw.Stop(); // 停止计时
    return sw.ElapsedMilliseconds;
}