using System;
using _1._3._48;

var deStack = new DeStack<string>();
const string input = "to be or not to - be - - that - - - is";
var s = input.Split(' ');

foreach (var n in s)
{
    if (!n.Equals("-"))
        deStack.PushRight(n);
    else if (!deStack.IsRightEmpty())
        Console.WriteLine(deStack.PopRight());
}

foreach (var n in s)
{
    if (!n.Equals("-"))
        deStack.PushLeft(n);
    else if (!deStack.IsLeftEmpty())
        Console.WriteLine(deStack.PopLeft());
}