using System;
using UnionFind;

var input = "9-0 3-4 5-8 7-2 2-1 5-7 0-3 4-2".Split(' ');
var weightedQuickUnion = new WeightedQuickUnionUf(10);

foreach (var s in input)
{
    weightedQuickUnion.ResetArrayCount();
    var numbers = s.Split('-');
    var p = int.Parse(numbers[0]);
    var q = int.Parse(numbers[1]);

    weightedQuickUnion.Union(p, q);
    var parent = weightedQuickUnion.GetParent();
    for (var i = 0; i < parent.Length; i++)
    {
        Console.Write(parent[i] + " ");
    }

    Console.WriteLine("数组访问：" + weightedQuickUnion.ArrayParentVisitCount);
}