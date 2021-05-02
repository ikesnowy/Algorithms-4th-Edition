using System;
using System.Diagnostics;
using SymbolTable;

// 绝大部分单词都位于符号表的中部，因此二分查找所需的时间较少。
var n = 8000;
var multiplyBy2 = 5;
var repeatTimes = 5;
double lastTime = -1;
Console.WriteLine(@"n	time	ratio");
for (var i = 0; i < multiplyBy2; i++)
{
    Console.Write(n + "\t");
    long timeSum = 0;
    for (var j = 0; j < repeatTimes; j++)
    {
        var st = new BinarySearchSt<string, int>();
        var sw = Stopwatch.StartNew();
        FrequencyCounter.MostFrequentlyWord("tale.txt", n, 0, st);
        sw.Stop();
        timeSum += sw.ElapsedMilliseconds;
    }

    timeSum /= repeatTimes;
    Console.Write(timeSum + "\t");
    if (lastTime < 0)
        Console.WriteLine(@"--");
    else
        Console.WriteLine(timeSum / lastTime);
    lastTime = timeSum;
    n *= 2;
}