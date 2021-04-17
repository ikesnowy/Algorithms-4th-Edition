using System;
using Generics;

// 将 t 插入到 x 之后
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

var t = new Node<string>();
t.item = "t";

t.next = second.next;
second.next = t;

Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}