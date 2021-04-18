using System;
using UnionFind;

var n = 10;
for (var i = 0; i < 5; i++)
{
    var uf = new Uf(n);
    Console.WriteLine(n + "\t" + ErdosRenyi.Count(uf));
    n *= 10;
}