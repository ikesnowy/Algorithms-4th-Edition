using System;
using Generics;

var numOfPeople = 7;
var callForDeath = 2;

var queue = new Queue<int>();
for (var i = 0; i < numOfPeople; i++)
{
    queue.Enqueue(i);
}

while (!queue.IsEmpty())
{
    for (var i = 0; i < callForDeath - 1; i++)
    {
        queue.Enqueue(queue.Dequeue());
    }

    Console.Write(queue.Dequeue() + " ");
}

Console.WriteLine();