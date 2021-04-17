using System;
using UnionFind;

char[] split = { '\n', '\r' };
var inputReference = TestCase.Properties.Resources.tinyUF.Split(split, StringSplitOptions.RemoveEmptyEntries);
var inputWorst = TestCase.Properties.Resources.worstUF.Split(split, StringSplitOptions.RemoveEmptyEntries);

RunTest(inputReference);
Console.WriteLine(@"-------------------------------------");
RunTest(inputWorst);

static void RunTest(string[] input)
{
    var weightedQuickUnion = new WeightedQuickUnionUF(10);
    var parent = weightedQuickUnion.GetParent();
    var size = weightedQuickUnion.GetSize();

    for (var i = 1; i < input.Length; i++)
    {
        var unit = input[i].Split(' ');
        var p = int.Parse(unit[0]);
        var q = int.Parse(unit[1]);

        Console.WriteLine($@"{p} {q}");
        weightedQuickUnion.Union(p, q);

        Console.Write(@"index:	");
        for (var j = 0; j < 10; j++)
        {
            Console.Write(j + @" ");
        }

        Console.WriteLine();

        Console.Write(@"parent:	");
        foreach (var m in parent)
        {
            Console.Write(m + @" ");
        }

        Console.WriteLine();
        Console.Write(@"size:	");
        foreach (var m in size)
        {
            Console.Write(m + @" ");
        }

        Console.WriteLine();
        Console.WriteLine(@"parent visit count:" + weightedQuickUnion.ArrayParentVisitCount);
        Console.WriteLine(@"size visit count:" + weightedQuickUnion.ArraySizeVisitCount);
        Console.WriteLine();
        weightedQuickUnion.ResetArrayCount();
    }
}