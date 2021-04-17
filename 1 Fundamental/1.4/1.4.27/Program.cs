using System;
using _1._4._27;

var queue = new StackQueue<string>();
var input = "to be or not to - be - - that - - - is".Split(' ');

foreach (var s in input)
{
    if (s == "-")
    {
        Console.WriteLine(queue.Dequeue());
    }
    else
    {
        queue.Enqueue(s);
    }
}