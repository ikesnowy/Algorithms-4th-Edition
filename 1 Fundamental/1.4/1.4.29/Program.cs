using System;
using _1._4._29;

var stackSteque = new StackSteque<string>();
var input = "to be or not to - be - - that - - - is".Split(' ');

foreach (var s in input)
{
    if (s == "-")
    {
        Console.WriteLine(stackSteque.Pop());
    }
    else
    {
        stackSteque.Push(s);
    }
}

while (!stackSteque.IsEmpty())
{
    stackSteque.Pop();
}

Console.WriteLine();

foreach (var s in input)
{
    if (s == "-")
    {
        Console.WriteLine(stackSteque.Pop());
    }
    else
    {
        stackSteque.Enqueue(s);
    }
}