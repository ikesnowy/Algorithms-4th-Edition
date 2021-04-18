using System;
using PriorityQueue;

// 同上题，这里选择和官网保持一致使用最大堆
// 官方实现：https://algs4.cs.princeton.edu/24pq/IndexMaxPQ.java.html
// 2.4.33 中已经实现这些操作
var input = new[] { "it", "was", "the", "best", "of", "times", "it", "was", "the", "worst" };
var pq = new IndexMaxPq<string>(input.Length);
for (var i = 0; i < input.Length; i++)
{
    pq.Insert(input[i], i);
}

foreach (var i in pq)
{
    Console.WriteLine(i + ". " + input[i]);
}

Console.WriteLine();
var random = new Random();
for (var i = 0; i < input.Length; i++)
{
    if (random.NextDouble() < 0.5)
        pq.IncreaseKey(i, input[i] + input[i]);
    else
        pq.DecreaseKey(i, input[i].Substring(0, 1));
}

while (!pq.IsEmpty())
{
    var key = pq.MaxKey();
    var i = pq.DelMax();
    Console.WriteLine(i + "." + key);
}

Console.WriteLine();
for (var i = 0; i < input.Length; i++)
{
    pq.Insert(input[i], i);
}

var param = new int[input.Length];
for (var i = 0; i < input.Length; i++)
{
    param[i] = i;
}

Shuffle(param);
for (var i = 0; i < param.Length; i++)
{
    var key = pq.KeyOf(param[i]);
    pq.Delete(param[i]);
    Console.WriteLine(param[i] + "." + key);
}

// 打乱数组。
static void Shuffle(int[] a)
{
    var n = a.Length;
    var random = new Random();
    for (var i = 0; i < n; i++)
    {
        var r = i + random.Next(n - i); // 等于StdRandom.uniform(N-i)
        var temp = a[i];
        a[i] = a[r];
        a[r] = temp;
    }
}