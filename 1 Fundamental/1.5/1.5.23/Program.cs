using System;
using System.Diagnostics;
using UnionFind;

var n = 2000;
for (var t = 0; t < 5; t++)
{
    var input = ErdosRenyi.Generate(n);
    var quickFind = new QuickFindUF(n);
    var quickUnion = new QuickUnionUF(n);

    Console.WriteLine("N:" + n);

    var quickFindTime = RunTest(quickFind, input);
    var quickUnionTime = RunTest(quickUnion, input);

    Console.WriteLine("quick-find 耗时（毫秒）：" + quickFindTime);
    Console.WriteLine("quick-union 耗时（毫秒）：" + quickUnionTime);
    Console.WriteLine("比值：" + (double)quickFindTime / quickUnionTime);
    Console.WriteLine();

    n *= 2;
}

// 进行若干次随机试验，输出平均 union 次数，返回平均耗时。
static long RunTest(UF uf, Connection[] connections)
{
    var timer = new Stopwatch();
    var repeatTime = 5;
    timer.Start();
    for (var i = 0; i < repeatTime; i++)
    {
        ErdosRenyi.Count(uf, connections);
    }

    timer.Stop();

    return timer.ElapsedMilliseconds / repeatTime;
}