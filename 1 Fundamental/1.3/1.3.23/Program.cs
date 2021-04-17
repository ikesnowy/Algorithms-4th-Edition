using System;
using Generics;

// x.next = t        x 的下一个是 t
// t.next = x.next   t 的下一个和 x 的下一个相同（也就是 t）
// 于是 t.next = t, 遍历会出现死循环。
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

second.next = t;
t.next = second.next;

Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.item + " ");
    current = current.next;
}