using System;
using Generics;

var link = new LinkedList<string>();
link.Insert("first", 0);
link.Insert("second", 1);
link.Insert("third", 2);

Console.WriteLine(Find(link, "second"));
Console.WriteLine(Find(link, "fourth"));

static bool Find<TItem>(LinkedList<TItem> link, TItem key)
{
    foreach (var i in link)
    {
        if (i.Equals(key))
        {
            return true;
        }
    }

    return false;
}