using System;
using _1._3._33;

var a = new Deque<string>();
var b = new ResizingArrayDeque<string>();

a.PushLeft("first");
b.PushLeft("first");
a.PushRight("second");
b.PushRight("second");
Display(a, b);

a.PopLeft();
b.PopLeft();
Display(a, b);
a.PopRight();
b.PopRight();
Display(a, b);

static void Display(Deque<string> a, ResizingArrayDeque<string> b)
{
    foreach (var s in a)
    {
        Console.Write(s + " ");
    }

    Console.WriteLine();
    foreach (var s in b)
    {
        Console.Write(s + " ");
    }

    Console.WriteLine();
    Console.WriteLine();
}