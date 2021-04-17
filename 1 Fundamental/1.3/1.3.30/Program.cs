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

first = Reverse(first);
Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}

// 使用书中的递归方式实现
static Node<TItem> Reverse<TItem>(Node<TItem> first)
{
    if (first == null)
        return null;
    if (first.next == null)
        return first;
    var second = first.next;
    var rest = Reverse(second);
    second.next = first;
    first.next = null;
    return rest;
}