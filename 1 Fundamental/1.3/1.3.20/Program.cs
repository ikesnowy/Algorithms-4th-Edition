using System;
using Generics;

var linkedList = new LinkedList<string>();
linkedList.Insert("first", 0);
linkedList.Insert("second", 1);
linkedList.Insert("third", 2);
linkedList.Insert("fourth", 3);

Console.WriteLine(linkedList.ToString());
linkedList.Delete(2);
Console.WriteLine(linkedList.ToString());