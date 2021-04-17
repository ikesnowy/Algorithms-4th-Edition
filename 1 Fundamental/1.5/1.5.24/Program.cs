using System;
using UnionFind;
using System.Diagnostics;

var n = 10000;
for (var t = 0; t < 5; t++)
{
    var input = ErdosRenyi.Generate(n);
    var weightedQuickUnionUf = new WeightedQuickUnionUF(n);
    var weightedQuickUnionPathCompressionUf = new WeightedQuickUnionPathCompressionUF(n);

    Console.WriteLine("N:" + n);

    var weightedQuickUnionTime = RunTest(weightedQuickUnionUf, input);
    var weightedQuickUnionPathCompressionTime = RunTest(weightedQuickUnionPathCompressionUf, input);

    Console.WriteLine("加权 quick-find 耗时（毫秒）：" + weightedQuickUnionTime);
    Console.WriteLine("带路径压缩的加权 quick-union 耗时（毫秒）：" + weightedQuickUnionPathCompressionTime);
    Console.WriteLine("比值：" + (double)weightedQuickUnionTime / weightedQuickUnionPathCompressionTime);
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