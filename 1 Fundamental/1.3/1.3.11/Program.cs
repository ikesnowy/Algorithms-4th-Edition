using System;
using Generics;
// ReSharper disable RedundantJumpStatement

var stack = new Stack<int>();

var input = "7 16 * 5 + 16 * 3 + 16 * 1 +".Split(' ');

foreach (var n in input)
{
    if (n == " ")
    {
        continue;
    }
    else if (n == "+")
    {
        stack.Push(stack.Pop() + stack.Pop());
    }
    else if (n == "-")
    {
        var temp = stack.Pop();
        stack.Push(stack.Pop() - temp);
    }
    else if (n == "*")
    {
        stack.Push(stack.Pop() * stack.Pop());
    }
    else if (n == "/")
    {
        var temp = stack.Pop();
        stack.Push(stack.Pop() / temp);
    }
    else
    {
        stack.Push(int.Parse(n));
    }
}

Console.WriteLine(stack.Pop());