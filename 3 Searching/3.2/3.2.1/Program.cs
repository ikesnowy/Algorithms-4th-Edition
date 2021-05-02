using System;
using BinarySearchTree;

var bst = new Bst<string, string>();
var input = "E A S Y Q U E S T I O N".Split(' ', StringSplitOptions.RemoveEmptyEntries);
foreach (var key in input)
{
    bst.Put(key, key);
}

Console.WriteLine(bst);