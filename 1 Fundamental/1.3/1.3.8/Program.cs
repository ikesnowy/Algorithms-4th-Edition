using System;
using _1._3._8;

var stack = new DoublingStackOfStrings();

var input = "it was - the best - of times - - - it was - the - -".Split(' ');

foreach (var n in input)
{
    if (n == "-")
        stack.Pop();
    else
        stack.Push(n);
}

foreach (var s in stack)
{
    Console.Write(s + ' ');
}

Console.WriteLine($"\nStack Size: {stack.Size()}");