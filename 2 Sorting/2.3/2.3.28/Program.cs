using System;
using _2._3._28;

Console.WriteLine(@"M	N	Depth");
Trial(10);
Trial(20);
Trial(50);

// 进行一次测试。
static void Trial(int m)
{
    var sort = new QuickSortInsertion();
    var trialTime = 5;

    // 由于排序前有 Shuffle，因此直接输入有序数组。
    // M=10
    sort.M = m;
    var totalDepth = 0;
    for (var n = 1000; n < 10000000; n *= 10)
    {
        for (var i = 0; i < trialTime; i++)
        {
            var a = new int[n];
            for (var j = 0; j < n; j++)
            {
                a[j] = j;
            }

            sort.Sort(a);
            totalDepth += sort.Depth;
        }

        Console.WriteLine(sort.M + "\t" + n + "\t" + totalDepth / trialTime);
    }
}