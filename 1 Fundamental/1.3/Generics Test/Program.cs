using System;
using Generics;

var bag = new Bag<string>();
bag.Add("lalala");
bag.Add("lalala");
bag.Add("lalala");

Console.WriteLine(bag.Size());
foreach (var n in bag)
{
    Console.WriteLine(n);
}

Console.WriteLine();

var stack = new Stack<string>();
var input = "to be or not to - be - - that - - - is";
var s = input.Split(' ');

foreach (var n in s)
{
    if (!n.Equals("-"))
        stack.Push(n);
    else if (!stack.IsEmpty())
        Console.WriteLine(stack.Pop());
}

Console.WriteLine($@"({stack.Size()}) left on stack");
Console.WriteLine(stack);
Console.WriteLine();

var queue = new Queue<string>();

foreach (var n in s)
{
    if (!n.Equals("-"))
        queue.Enqueue(n);
    else if (!queue.IsEmpty())
        Console.WriteLine(queue.Dequeue());
}

Console.WriteLine($@"({queue.Size()}) left on queue");
Console.WriteLine(queue);

var link = new LinkedList<string>();
link.Insert("first");
link.Insert("second");
link.Insert("third");
link.Insert("fourth");

Console.WriteLine(link.ToString());
Console.WriteLine(link.Find(2));
Console.WriteLine(link.Delete(2));
Console.WriteLine(link.ToString());
link.Insert("second", 2);
Console.WriteLine(link.ToString());