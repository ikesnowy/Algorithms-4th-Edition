using System;
using Measurement;

var splits = new[] { '\n' };
var testCase = TestCase.Properties.Resources._16Kints.Split(splits, StringSplitOptions.RemoveEmptyEntries);
var testArray = new int[testCase.Length + 2];
// 样例第一个和最后一个相等
testArray[0] = 1;
testArray[testCase.Length + 1] = 1;
for (var i = 1; i <= testCase.Length; i++)
{
    testArray[i] = int.Parse(testCase[i - 1]);
}

var timer = new Stopwatch();
Console.WriteLine($@"Count:{CountEqual(testArray)}");
Console.WriteLine($@"Time:{timer.ElapsedTime()} seconds");
timer = new Stopwatch();
Console.WriteLine($@"Count:{CountEqualLog(testArray)}");
Console.WriteLine($@"Time:{timer.ElapsedTime()} seconds");

static int CountEqual(int[] a)
{
    var n = a.Length;
    var count = 0;
    for (var i = 0; i < n; i++)
    {
        for (var j = i + 1; j < n; j++)
        {
            if (a[i] == a[j])
                count++;
        }
    }

    return count;
}


static int CountEqualLog(int[] a)
{
    var n = a.Length;
    var count = 0;
    Array.Sort(a);
    var dup = 0; // dup = 重复元素数量-1
    for (var i = 1; i < n; i++)
    {
        while (a[i - 1] == a[i])
        {
            dup++;
            i++;
        }
        count += dup * (dup + 1) / 2;
        dup = 0;
    }
    return count;
}