using System;
using UnionFind;

var n = 10;
for (var i = 0; i < 5; i++)
{
    var uf = new UF(n);
    Console.WriteLine(n + "\t" + ErdosRenyi.Count(uf));
    n *= 10;
}