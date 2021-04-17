using System;
using UnionFind;

var input = "9-0 3-4 5-8 7-2 2-1 5-7 0-3 4-2".Split(' ');
var quickUnion = new QuickUnionUF(10);

foreach (var s in input)
{
    quickUnion.ResetArrayCount();
    var numbers = s.Split('-');
    var p = int.Parse(numbers[0]);
    var q = int.Parse(numbers[1]);

    quickUnion.Union(p, q);
    var parent = quickUnion.GetParent();
    for (var i = 0; i < parent.Length; i++)
    {
        if (parent[i] == i)
        {
            Console.WriteLine("|---- " + i);
            Dfs(parent, i, 1);
        }
    }

    Console.WriteLine("数组访问：" + quickUnion.ArrayVisitCount);
}

static void Dfs(int[] parent, int root, int level)
{
    for (var i = 0; i < parent.Length; i++)
    {
        if (parent[i] == root && i != root)
        {
            for (var j = 0; j < level; j++)
            {
                Console.Write(@"    ");
            }

            Console.WriteLine("|---- " + i);
            Dfs(parent, i, level + 1);
        }
    }
}