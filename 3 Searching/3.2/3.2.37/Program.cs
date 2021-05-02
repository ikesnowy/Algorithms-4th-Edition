using System;
using BinarySearchTree;

var bst = new Bst<int, int>();
bst.Put(4, 4);
bst.Put(3, 3);
bst.Put(9, 9);
bst.Put(2, 2);
bst.Put(1, 1);
bst.Put(11, 11);
bst.Put(12, 12);
bst.Put(8, 8);

Console.WriteLine(bst);
Console.WriteLine();
Console.WriteLine(@"PrintLevel(4): ");
bst.PrintLevel(4);
Console.WriteLine();
Console.WriteLine(@"PrintLevel(9): ");
bst.PrintLevel(9);