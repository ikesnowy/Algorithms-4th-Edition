using System;
using _2._2._14;

var q1 = new Queue<int>();
for (var i = 1; i < 10; i += 2)
{
    q1.Enqueue(i);
}

var q2 = new Queue<int>();
for (var i = 2; i <= 10; i += 2)
{
    q2.Enqueue(i);
}

var sorted = Merge(q1, q2);
var n = sorted.Size();
for (var i = 0; i < n; i++)
{
    Console.Write(sorted.Dequeue() + " ");
}

Console.WriteLine();

// 归并两个有序队列。输入队列将被清空。
static Queue<T> Merge<T>(Queue<T> a, Queue<T> b) where T : IComparable<T>
{
    var sortedQueue = new Queue<T>();
    while (!a.IsEmpty() && !b.IsEmpty())
    {
        if (a.Peek().CompareTo(b.Peek()) < 0)
            sortedQueue.Enqueue(a.Dequeue());
        else
            sortedQueue.Enqueue(b.Dequeue());
    }

    while (!a.IsEmpty())
        sortedQueue.Enqueue(a.Dequeue());
    while (!b.IsEmpty())
        sortedQueue.Enqueue(b.Dequeue());

    return sortedQueue;
}