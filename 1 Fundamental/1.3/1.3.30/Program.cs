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

first = Reverse(first);
Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.Item + " ");
    current = current.Next;
}

// 使用书中的递归方式实现
static Node<TItem> Reverse<TItem>(Node<TItem> first)
{
    if (first == null)
        return null;
    if (first.Next == null)
        return first;
    var second = first.Next;
    var rest = Reverse(second);
    second.Next = first;
    first.Next = null;
    return rest;
}