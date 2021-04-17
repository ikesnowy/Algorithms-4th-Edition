using System;
using Generics;

var r = new Queue<string>();
r.Enqueue("first");
r.Enqueue("second");
r.Enqueue("third");

var q = new Queue<string>(r);

Console.WriteLine("r:" + r);
Console.WriteLine("q:" + q);

r.Enqueue("fourth");
q.Dequeue();

Console.WriteLine("r:" + r);
Console.WriteLine("q:" + q);