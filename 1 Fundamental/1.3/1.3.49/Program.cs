using System;
using _1._3._49;

var input = "to be or not to - be - - that - - - is";
var s = input.Split(' ');
var queue = new StackQueue<string>();

foreach (var n in s)
{
    if (!n.Equals("-"))
        queue.Enqueue(n);
    else
        Console.WriteLine(queue.Dequeue());
}