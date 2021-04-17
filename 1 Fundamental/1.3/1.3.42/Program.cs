using System;
using Generics;

var s = new Stack<string>();
s.Push("third");
s.Push("second");
s.Push("first");

var t = new Stack<string>(s);

Console.WriteLine("s:" + s);
Console.WriteLine("t:" + t);

t.Pop();
s.Push("zero");

Console.WriteLine("s:" + s);
Console.WriteLine("t:" + t);