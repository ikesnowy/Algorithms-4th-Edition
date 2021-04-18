using System;
using _1._5._20;

var uf = new WeightedQuickUnionUf();
char[] split = { '\r', '\n' };
var input = TestCase.Properties.Resources.tinyUF.Split(split, StringSplitOptions.RemoveEmptyEntries);
var size = int.Parse(input[0]);

for (var i = 0; i < size; i++)
{
    if (uf.NewSite() != i)
    {
        Console.WriteLine(@"标识符不一致！");
        return;
    }
}

for (var i = 1; i < input.Length; i++)
{
    var pair = input[i].Split(' ');
    var p = int.Parse(pair[0]);
    var q = int.Parse(pair[1]);

    uf.Union(p, q);
}

var parent = uf.GetParent();
foreach (var i in parent)
{
    Console.Write(i + @" ");
}

Console.WriteLine();