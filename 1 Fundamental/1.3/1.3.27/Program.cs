using System;
using Generics;

var first = new Node<int>();
var second = new Node<int>();
var third = new Node<int>();
var fourth = new Node<int>();

first.item = 1;
second.item = 2;
third.item = 3;
fourth.item = 4;

first.next = second;
second.next = third;
third.next = fourth;
fourth.next = null;

Console.WriteLine("Max:" + Max(first));

static int Max(Node<int> first)
{
    var max = 0;

    var current = first;
    while (current != null)
    {
        if (max < current.item)
        {
            max = current.item;
        }

        current = current.next;
    }

    return max;
}