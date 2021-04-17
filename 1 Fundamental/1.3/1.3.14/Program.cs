using System;
using _1._3._14;

var queue = new ResizingArrayQueueOfStrings<string>();
var input = "to be or not to - be - - that - - - is".Split(' ');

foreach (var s in input)
{
    if (!s.Equals("-"))
        queue.Enqueue(s);
    else if (!queue.IsEmpty())
        Console.Write(queue.Dequeue() + ' ');
}

Console.WriteLine("(" + queue.Size() + " left on queue)");