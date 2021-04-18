using System;
using _2._2._18;

var a = new LinkedList<int>();
var shuffle = new MergeShuffle();
a.Insert(1);
a.Insert(2);
a.Insert(3);
a.Insert(4);
a.Insert(5);
a.Insert(6);
for (var i = 0; i < 200; i++)
{
    shuffle.Shuffle(a);
    Console.WriteLine(a.ToString());
}