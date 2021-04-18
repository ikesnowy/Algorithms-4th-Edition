using System;
using Merge;

var mergeSort = new MergeSortNatural();

Console.WriteLine(@"总长度	有序	时间	比率");
var maxSorted = 256;
var repeatTime = 4;
double previousTime = 1;
for (var i = 0; i < 4; i++)
{
    var n = 16384;
    for (var j = 0; j < 6; j++)
    {
        double time = 0;
        for (var k = 0; k < repeatTime; k++)
        {
            var test = new int[n];
            var unsorted = SortCompare.GetRandomArrayInt(n - maxSorted);
            var sorted = SortCompare.GetRandomArrayInt(maxSorted);
            Array.Sort(sorted);
            for (var l = 0; l < n - maxSorted; l++)
            {
                test[l] = unsorted[l];
            }

            for (var l = 0; l < maxSorted; l++)
            {
                test[l + n - maxSorted] = sorted[l];
            }

            time += SortCompare.Time(mergeSort, test);
        }

        if (j == 0)
            Console.WriteLine(n + "\t" + maxSorted + "\t" + time / repeatTime + "\t---");
        else
            Console.WriteLine(
                n + "\t" + maxSorted + "\t" + time / repeatTime + "\t" + (time / repeatTime) / previousTime);

        previousTime = time / repeatTime;
        n *= 2;
    }

    maxSorted *= 4;
}