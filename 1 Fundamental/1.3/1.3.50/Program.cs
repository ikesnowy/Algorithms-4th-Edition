using System;
using _1._3._50;

var stack = new Stack<string>();
stack.Push("first");
stack.Push("second");
stack.Push("third");
stack.Push("fourth");

foreach (var s in stack)
{
    Console.Write(s + " ");
}

Console.WriteLine();
foreach (var s in stack)
{
    Console.Write(s + " ");
    stack.Pop(); // 抛出异常
}