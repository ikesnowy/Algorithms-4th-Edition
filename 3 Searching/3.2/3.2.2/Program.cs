using System;
using BinarySearchTree;

string[] worstInput =
{
    "A X C S E R H", "X A S C R E H", "A C E H R S X", "X S R H E C A", "X A S R H E C", "A X S R H E C"
};

foreach (var worst in worstInput)
{
    var keys = worst.Split(' ');
    var bst = new Bst<string, string>();
    foreach (var key in keys)
    {
        bst.Put(key, key);
    }

    Console.WriteLine(bst);
}