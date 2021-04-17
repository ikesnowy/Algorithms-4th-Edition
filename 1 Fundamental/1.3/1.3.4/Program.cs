using System;
using Generics;

var input = "[()]{}{[()()]()}";
Console.WriteLine(IsBalanced(input));
var input2 = "[(])";
Console.WriteLine(IsBalanced(input2));

static bool IsBalanced(string input)
{
    var stack = new Stack<char>();

    foreach (var i in input)
    {
        if (i == '(' || i == '[' || i == '{')
            stack.Push(i);
        else
        {
            if (stack.Peek() == '(' && i == ')')
                stack.Pop();
            else if (stack.Peek() == '{' && i == '}')
                stack.Pop();
            else if (stack.Peek() == '[' && i == ']')
                stack.Pop();
            else
                return false;
        }
    }

    return stack.IsEmpty();
}