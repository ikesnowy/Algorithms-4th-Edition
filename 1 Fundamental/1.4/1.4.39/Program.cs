using System;
using _1._4._39;
// ReSharper disable ForStatementConditionIsTrue

Console.WriteLine(@"数据量	重复次数	平均耗时");
for (var n = 125; true; n += n)
{
    for (var i = 10; i <= 1000; i *= 10)
    {
        var time = DoubleTest.TimeTrial(n, i);
        Console.WriteLine($@"{n}	{i}	{time}");
    }

    Console.WriteLine();
}