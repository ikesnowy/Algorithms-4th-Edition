using System;
using _3._2._7;

var recursiveAvgCompare = new BstRecursive<int, int>();
var constantAvgCompare = new BstConstant<int, int>();

int[] testCase = { 5, 6, 2, 3, 9, 1, 0, 7 };

foreach (var key in testCase)
{
    recursiveAvgCompare.Put(key, key);
    constantAvgCompare.Put(key, key);
}

Console.WriteLine(@"Recursive AvgCompare Method");
Console.WriteLine(recursiveAvgCompare);
Console.WriteLine(@"Avg Compare: " + recursiveAvgCompare.AverageCompares());

Console.WriteLine(@"Constant AvgCompare Method");
Console.WriteLine(constantAvgCompare);
Console.WriteLine(@"Avg Compare: " + constantAvgCompare.AverageCompares());