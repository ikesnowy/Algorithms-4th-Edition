using System;
using _1._3._32;

// 见 Steque.cs
var steque = new Steque<string>();
steque.Push("first");
steque.Push("second");
steque.Push("third");
steque.Enqueue("fourth");
Console.WriteLine(steque.ToString());
steque.Pop();
steque.Pop();
steque.Pop();
steque.Pop();
Console.WriteLine(steque.ToString());
steque.Enqueue("first");
steque.Push("zero");
Console.WriteLine(steque.ToString());