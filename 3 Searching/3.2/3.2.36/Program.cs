using System;
using BinarySearchTree;

var bst = new BstNonRecursive<int, int>();
bst.Put(10, 10);
bst.Put(4, 4);
bst.Put(12, 12);
bst.Put(9, 9);
bst.Put(3, 3);
bst.Put(8, 8);

foreach (var key in bst.Keys(5, 11))
{
    Console.Write(key + @", ");
}