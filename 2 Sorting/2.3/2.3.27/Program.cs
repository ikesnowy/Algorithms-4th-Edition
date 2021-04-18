using System;
using _2._3._27;
using Quick;

var insertion = new QuickSortInsertion();
var ignore = new QuickSortIgnore();
var arraySize = 20000; // 初始数组大小。
const int mSteps = 1; // M 值的递增次数。
const int trialTimes = 4; // 每次实验的重复次数。
const int trialLevel = 10; // 双倍递增的次数。

Console.WriteLine(@"M	n		ignore	insert	ratio");
for (var i = 0; i < mSteps; i++)
{
    var array = arraySize;
    for (var j = 0; j < trialLevel; j++)
    {
        double timeIgnore = 0;
        double timeInsertion = 0;
        for (var k = 0; k < trialTimes; k++)
        {
            var a = SortCompare.GetRandomArrayInt(array);
            var b = new int[a.Length];
            a.CopyTo(b, 0);
            timeInsertion += SortCompare.Time(insertion, b);
            timeIgnore += SortCompare.Time(ignore, a);

        }

        timeIgnore /= trialTimes;
        timeInsertion /= trialTimes;
        if (arraySize < 10000000)
            Console.WriteLine(
                ignore.M
                + "\t"
                + array
                + "\t\t"
                + timeIgnore
                + "\t"
                + timeInsertion
                + "\t"
                + timeIgnore / timeInsertion);
        else
            Console.WriteLine(
                ignore.M + "\t" + array + "\t" + timeIgnore + "\t" + timeInsertion + "\t" + timeIgnore / timeInsertion);
        array *= 2;
    }

    ignore.M++;
}