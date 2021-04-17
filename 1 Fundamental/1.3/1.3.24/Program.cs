using System;
using Generics;

var first = new Node<string>();
var second = new Node<string>();
var third = new Node<string>();
var fourth = new Node<string>();

first.item = "first";
second.item = "second";
third.item = "third";
fourth.item = "fourth";

first.next = second;
second.next = third;
third.next = fourth;
fourth.next = null;

var current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}

RemoveAfter(second);
Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}

static void RemoveAfter<TItem>(Node<TItem> i)
{
    i.next = null;
}