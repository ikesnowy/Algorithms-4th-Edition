using System;
using Generics;

var first = new Node<string>();
var second = new Node<string>();
var third = new Node<string>();
var fourth = new Node<string>();

first.Item = "first";
second.Item = "second";
third.Item = "third";
fourth.Item = "fourth";

first.Next = second;
second.Next = third;
third.Next = fourth;
fourth.Next = null;

var current = first;
while (current != null)
{
    Console.Write(current.Item + " ");
    current = current.Next;
}

RemoveAfter(second);
Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.Item + " ");
    current = current.Next;
}

static void RemoveAfter<TItem>(Node<TItem> i)
{
    i.Next = null;
}