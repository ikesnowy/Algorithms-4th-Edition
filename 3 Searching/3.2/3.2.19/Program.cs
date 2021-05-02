using System;
using System.Linq;
using BinarySearchTree;

var bst = new Bst<string, string>();
var input = "E A S Y Q U E S T I O N".Split(' ', StringSplitOptions.RemoveEmptyEntries);
foreach (var key in input)
{
    bst.Put(key, key);
}

while (!bst.IsEmpty())
{
    Console.WriteLine(bst);
    bst.Delete(bst.ToKeyArray().First());
}