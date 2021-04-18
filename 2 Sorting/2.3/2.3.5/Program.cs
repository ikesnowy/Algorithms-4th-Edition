using System;
using Quick;

var sort2Distinct = new Sort2Distinct();
var a = new[] { 2, 1, 2, 2, 1, 2, 1, 2, 1, 1 };
sort2Distinct.Sort(a);
for (var i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();