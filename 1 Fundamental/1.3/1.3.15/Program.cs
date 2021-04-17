using System;
using Generics;

var queue = new Queue<string>();
var input = "1 2 3 4 5 6 7 8 9 10".Split(' ');
var k = 4;

foreach (var s in input)
{
    queue.Enqueue(s);
}

var count = queue.Size() - k;
for (var i = 0; i < count; i++)
{
    queue.Dequeue();
}

Console.WriteLine(queue.Peek());