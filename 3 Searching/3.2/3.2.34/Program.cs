using System;
using BinarySearchTree;

var bst = new ThreadedSt<int, int>();
bst.Put(10, 10);
bst.Put(4, 4);
bst.Put(12, 12);
bst.Put(9, 9);
bst.Delete(9);
bst.Put(3, 3);
bst.Put(8, 8);

var key = bst.Min();
while (key != 0)
{
    Console.Write(key + @" ");
    key = bst.Next(key);
}

Console.WriteLine();
key = bst.Max();
while (key != 0)
{
    Console.Write(key + @" ");
    key = bst.Prev(key);
}