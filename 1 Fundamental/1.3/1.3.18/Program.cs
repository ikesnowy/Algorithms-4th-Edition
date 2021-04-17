using System;
using Generics;

var x = new Node<string>();
x.item = "first";
var y = new Node<string>();
y.item = "second";
x.next = y;
var z = new Node<string>();
z.item = "third";
y.next = z;

Console.WriteLine("x: " + x.item);
Console.WriteLine("x.next: " + x.next.item);
x.next = x.next.next;
Console.WriteLine();
Console.WriteLine("x: " + x.item);
Console.WriteLine("x.next: " + x.next.item);