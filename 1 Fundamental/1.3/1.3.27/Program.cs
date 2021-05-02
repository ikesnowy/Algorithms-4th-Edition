using System;
using Generics;

var first = new Node<int>();
var second = new Node<int>();
var third = new Node<int>();
var fourth = new Node<int>();

first.Item = 1;
second.Item = 2;
third.Item = 3;
fourth.Item = 4;

first.Next = second;
second.Next = third;
third.Next = fourth;
fourth.Next = null;

Console.WriteLine("Max:" + Max(first));

static int Max(Node<int> first)
{
    var max = 0;

    var current = first;
    while (current != null)
    {
        if (max < current.Item)
        {
            max = current.Item;
        }

        current = current.Next;
    }

    return max;
}