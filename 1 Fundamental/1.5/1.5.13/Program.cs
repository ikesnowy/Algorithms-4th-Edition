using System;
using UnionFind;

var uf = new WeightedQuickUnionPathCompressionUf(10);

// 见中文版 P146 或英文版 P229 中加权 quick-union 的最坏输入。
uf.Union(0, 1);
uf.Union(2, 3);
uf.Union(4, 5);
uf.Union(6, 7);
uf.Union(0, 2);
uf.Union(4, 6);
uf.Union(0, 4);

var id = uf.GetParent();
for (var i = 0; i < id.Length; i++)
{
    Console.Write(id[i]);
}

Console.WriteLine();