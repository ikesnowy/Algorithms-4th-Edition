using System;
using Quick;

Console.WriteLine(@"N	准确值	估计值	比值");
var sort = new QuickSortAnalyze();
var n = 100;
var trialTime = 500;
for (var i = 0; i < 3; i++)
{
    var sumOfCompare = 0;
    var a = new int[n];
    for (var j = 0; j < trialTime; j++)
    {
        for (var k = 0; k < n; k++)
        {
            a[k] = k;
        }

        SortCompare.Shuffle(a);
        sort.Sort(a);
        sumOfCompare += sort.CompareCount;
    }

    var averageCompare = sumOfCompare / trialTime;
    var estimatedCompare = 2 * n * Math.Log(n);
    Console.WriteLine(
        n + "\t" + averageCompare + "\t" + (int)estimatedCompare + "\t" + averageCompare / estimatedCompare);
    n *= 10;
}