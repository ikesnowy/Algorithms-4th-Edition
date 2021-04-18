using System;

var T = 10; // 重复次数
var n = 1000; // 数组初始大小
var nMultipleBy10 = 4; // 数组大小 ×10 的次数
var mMultipleBy2 = 3; // 数据范围 ×2  的次数

var random = new Random();
for (var i = 0; i < nMultipleBy10; i++)
{
    Console.WriteLine("n=" + n);
    Console.WriteLine(@"	m	emprical	theoretical");
    var m = n / 2;
    for (var j = 0; j < mMultipleBy2; j++)
    {
        var distinctSum = 0;
        for (var k = 0; k < T; k++)
        {
            var data = new int[n];
            for (var l = 0; l < n; l++)
                data[l] = random.Next(m);
            distinctSum += Distinct(data);
        }

        var empirical = (double)distinctSum / T;
        var alpha = (double)n / m;
        var theoretical = m * (1 - Math.Exp(-alpha));
        Console.WriteLine("\t" + m + "\t" + empirical + "\t" + theoretical);
        m *= 2;
    }

    n *= 10;
}

// 计算数组中重复元素的个数。
static int Distinct<T>(T[] a) where T : IComparable<T>
{
    if (a.Length == 0)
        return 0;
    Array.Sort(a);
    var distinct = 1;
    for (var i = 1; i < a.Length; i++)
        if (a[i].CompareTo(a[i - 1]) != 0)
            distinct++;
    return distinct;
}