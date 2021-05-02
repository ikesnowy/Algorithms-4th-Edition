using System;
using System.Diagnostics;
using BinarySearchTree;

var bst = BuildTree<Bst<int, int>>();
var bstCached = BuildTree<BstCached<int, int>>();

var watch = Stopwatch.StartNew();
for (var i = 0; i < 1000000; i++)
{
    bstCached.Put(20, i);
}

watch.Stop();
Console.WriteLine(@"bstCached: " + watch.ElapsedMilliseconds + @" ms");

watch.Restart();
for (var i = 0; i < 1000000; i++)
{
    bst.Put(20, i);
}

watch.Stop();
Console.WriteLine(@"bst:" + watch.ElapsedMilliseconds + @" ms");

T BuildTree<T>() where T : Bst<int, int>, new()
{
    var tree = new T();
    tree.Put(4, 4);
    tree.Put(3, 3);
    tree.Put(9, 9);
    tree.Put(2, 2);
    tree.Put(1, 1);
    tree.Put(12, 12);
    tree.Put(18, 18);
    tree.Put(15, 15);
    tree.Put(16, 16);
    tree.Put(11, 11);
    tree.Put(8, 8);
    tree.Put(14, 14);
    tree.Put(20, 20);
    return tree;
}