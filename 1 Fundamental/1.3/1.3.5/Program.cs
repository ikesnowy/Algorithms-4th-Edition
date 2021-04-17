using System;
using Generics;

var n = 50;
var stack = new Stack<int>();
while (n > 0)
{
    stack.Push(n % 2);
    n = n / 2;
}

foreach (var d in stack)
{
    Console.WriteLine(d);
}

Console.WriteLine();