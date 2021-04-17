using System;
using Generics;

var q = new Queue<string>();
q.Enqueue("first");
q.Enqueue("second");
q.Enqueue("third");
q.Enqueue("fourth");
var stack = new Stack<string>();
while (!q.IsEmpty())
    stack.Push(q.Dequeue());
while (!stack.IsEmpty())
    q.Enqueue(stack.Pop());

Console.WriteLine(q.ToString());