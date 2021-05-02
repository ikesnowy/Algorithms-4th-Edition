using System;
using Generics;

// 将 t 插入到 x 之后
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

var t = new Node<string>();
t.Item = "t";

t.Next = second.Next;
second.Next = t;

Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.Item + " ");
    current = current.Next;
}