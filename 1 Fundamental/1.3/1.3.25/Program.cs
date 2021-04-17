using System;
using Generics;

var first = new Node<string>();
var second = new Node<string>();
var third = new Node<string>();

first.item = "first";
second.item = "second";
third.item = "third";

first.next = second;
second.next = null;

var current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}

InsertAfter(second, third);
Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}

static void InsertAfter<TItem>(Node<TItem> a, Node<TItem> b)
{
    if (a == null || b == null)
        return;
    b.next = a.next;
    a.next = b;
}