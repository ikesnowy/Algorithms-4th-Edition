using System;
using _1._5._11;
using UnionFind;

char[] split = { '\n', '\r' };
var input = TestCase.Properties.Resources.mediumUF.Split(split, StringSplitOptions.RemoveEmptyEntries);
var size = int.Parse(input[0]);

var quickFind = new QuickFindUF(size);
var weightedQuickFind = new WeightedQuickFindUF(size);
for (var i = 1; i < size; i++)
{
    var pair = input[i].Split(' ');
    var p = int.Parse(pair[0]);
    var q = int.Parse(pair[1]);
    quickFind.Union(p, q);
    weightedQuickFind.Union(p, q);
}

Console.WriteLine(@"quick-find: " + quickFind.ArrayVisitCount);
Console.WriteLine(@"weighted quick-find: " + weightedQuickFind.ArrayVisitCount);