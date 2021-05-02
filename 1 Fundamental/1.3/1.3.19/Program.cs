using System;
using Generics;

var first = new Node<string> { item = "first" };
var second = new Node<string> { item = "second" };
var third = new Node<string> { item = "third" };

first.next = second;
second.next = third;
third.next = null;

var current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}

DeleteLast(first);
Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}

Console.WriteLine();

static void DeleteLast(Node<string> first)
{
    var current = first;

    while (current.next.next != null)
    {
        current = current.next;
    }

    current.next = null;
}