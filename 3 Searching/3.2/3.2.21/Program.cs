using System;
using System.Collections.Generic;
using BinarySearchTree;
// ReSharper disable LocalizableElement

var testTimes = 1000000;
var bst = new BstRandomKey<int, int>();
bst.Put(8, 8);
bst.Put(4, 4);
bst.Put(7, 7);
bst.Put(10, 10);
bst.Put(9, 9);
Console.WriteLine(bst);

var keyCounter = new Dictionary<int, int>();
foreach (var key in bst.Keys())
{
    keyCounter.Add(key, 0);
}

for (var i = 0; i < testTimes; i++)
{
    keyCounter[bst.RandomKey()]++;
}

foreach (var i in keyCounter)
{
    Console.WriteLine(i.Key + "\t" + i.Value + "\t" + (double)i.Value / testTimes);
}