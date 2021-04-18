using System;
using UnionFind;

var uf = new QuickUnionPathCompressionUf(10);

// 使用书中提到的最坏情况，0 连 1，1 连 2，2 连 3……
for (var i = 0; i < 4; i++)
{
    uf.Union(i, i + 1);
}

var id = uf.GetParent();
for (var i = 0; i < id.Length; i++)
{
    Console.Write(id[i]);
}

Console.WriteLine();