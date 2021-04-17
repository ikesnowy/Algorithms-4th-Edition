using System;
using _1._3._31;

var linklist = new DoubleLinkList<string>();
linklist.InsertRear("fourth");
linklist.InsertFront("first");
linklist.InsertAfter("second", 0);
linklist.InsertBefore("third", 2);

Console.WriteLine(linklist);

linklist.DeleteFront();
Console.WriteLine(linklist);
linklist.DeleteRear();
Console.WriteLine(linklist);
linklist.Delete(1);
Console.WriteLine(linklist);

Console.WriteLine(linklist.At(0)); 