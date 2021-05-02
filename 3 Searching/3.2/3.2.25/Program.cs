using System;
using System.Collections.Generic;
using BinarySearchTree;

var data = new[]
{
    new KeyValuePair<int, int>(6, 6), new KeyValuePair<int, int>(4, 4), new KeyValuePair<int, int>(8, 8),
    new KeyValuePair<int, int>(3, 3), new KeyValuePair<int, int>(1, 1), new KeyValuePair<int, int>(7, 7)
};
var bst = new BstBalanced<int, int>(data);
Console.WriteLine(bst);