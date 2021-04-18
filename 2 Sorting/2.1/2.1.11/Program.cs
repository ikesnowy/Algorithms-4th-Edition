using System;
using _2._1._11;

var shellSort = new ShellSort();
var array = new int[10];
for (var i = 0; i < array.Length; i++)
{
    array[i] = 10 - i;
}

shellSort.Sort(array);
for (var i = 0; i < array.Length; i++)
{
    Console.Write(array[i] + " ");
}

Console.WriteLine();
