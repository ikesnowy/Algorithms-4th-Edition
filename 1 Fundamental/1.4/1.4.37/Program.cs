using System;
using _1._4._37;
// ReSharper disable ForStatementConditionIsTrue

Console.WriteLine(@"测试量	非泛型耗时（毫秒）	泛型耗时（毫秒）	差值");
for (var n = 250; true; n += n)
{
    var time = DoubleTest.TimeTrial(n);
    var timeGeneric = DoubleTest.TimeTrialGeneric(n);
    Console.WriteLine($@"{n}	{time}	{timeGeneric}	{Math.Abs(time - timeGeneric)}");
}