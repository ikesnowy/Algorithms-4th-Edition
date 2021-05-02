using System;
using Generics;

var first = new Node<string>();
var second = new Node<string>();
var third = new Node<string>();

first.Item = "first";
second.Item = "second";
third.Item = "third";

first.Next = second;
second.Next = null;

var current = first;
while (current != null)
{
    Console.Write(current.Item + " ");
    current = current.Next;
}

InsertAfter(second, third);
Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.Item + " ");
    current = current.Next;
}

static void InsertAfter<TItem>(Node<TItem> a, Node<TItem> b)
{
    if (a == null || b == null)
        return;
    b.Next = a.Next;
    a.Next = b;
}