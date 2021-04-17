using System;
using Generics;

var link = new LinkedList<string>();
link.Insert("first", 0);
link.Insert("second", 1);
link.Insert("third", 2);
link.Insert("third", 3);
link.Insert("third", 4);

Console.WriteLine(link);
Remove(link, "third");
Console.WriteLine(link);

static void Remove(LinkedList<string> link, string key)
{
    for (var i = 0; i < link.Size(); i++)
    {
        if (link.Find(i) == key)
        {
            link.Delete(i);
            i--;
        }
    }
}