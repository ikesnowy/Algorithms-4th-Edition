using System;
using Generics;

// x.next = t        x 的下一个是 t
// t.next = x.next   t 的下一个和 x 的下一个相同（也就是 t）
// 于是 t.next = t, 遍历会出现死循环。
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

second.Next = t;
t.Next = second.Next;

Console.WriteLine();

current = first;
while (current != null)
{
    Console.Write(current.Item + " ");
    current = current.Next;
}