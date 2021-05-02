using System;
using BinarySearchTree;

var bst = new Bst<int, int>();
bst.Put(4, 4);
bst.Put(6, 6);
bst.Put(10, 10);
Console.WriteLine(Bst<int, int>.IsBinaryTree(bst));