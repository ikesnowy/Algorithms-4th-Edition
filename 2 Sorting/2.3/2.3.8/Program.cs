using System;
using Quick;

// 约为 NlogN 次
var sort = new QuickSortAnalyze();
var n = 100;
Console.WriteLine(@"N	Compare	NlogN");
for (var i = 0; i < 4; i++)
{
    var a = new int[n];
    for (var j = 0; j < a.Length; j++)
    {
        a[j] = 1;
    }

    sort.Sort(a);
    Console.WriteLine(n + "\t" + sort.CompareCount + "\t" + n * Math.Log(n) / Math.Log(2));
    n *= 10;
}