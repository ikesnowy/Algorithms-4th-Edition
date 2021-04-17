using System;
using UnionFind;

var result = RandomGrid.Generate(5);
foreach (var i in result)
{
    Console.WriteLine($@"({i.P}, {i.Q})");
}