using System;
using UnionFind;

var input = "9-0 3-4 5-8 7-2 2-1 5-7 0-3 4-2".Split(' ');
var quickFind = new QuickFindUF(10);

foreach (var s in input)
{
    quickFind.ResetArrayCount();

    var numbers = s.Split('-');
    var p = int.Parse(numbers[0]);
    var q = int.Parse(numbers[1]);

    var id = quickFind.GetParent();
    quickFind.Union(p, q);
    foreach (var root in id)
    {
        Console.Write(root + " ");
    }

    Console.WriteLine("数组访问：" + quickFind.ArrayVisitCount);
}