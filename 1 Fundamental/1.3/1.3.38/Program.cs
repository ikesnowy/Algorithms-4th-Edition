using System;
using _1._3._38;

var a = new ArrayBasedGeneralizeQueue<string>();
var b = new LinkedListBasedGeneralizeQueue<string>();

a.Insert("first");
b.Insert("first");
a.Insert("second");
b.Insert("second");
a.Insert("third");
b.Insert("third");

Console.WriteLine(a.Delete(2));
Console.WriteLine(b.Delete(2));
Console.WriteLine(a.Delete(3));
Console.WriteLine(b.Delete(3));