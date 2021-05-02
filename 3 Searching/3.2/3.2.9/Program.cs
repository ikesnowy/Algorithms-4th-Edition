using System;
using System.Collections.Generic;
using System.Linq;
using BinarySearchTree;

for (var n = 2; n <= 6; n++)
{
    Console.WriteLine($@"n={n}");
    var list = new List<int>();
    for (var i = 0; i < n; i++)
    {
        list.Add(i);
    }

    var trees = new List<Bst<int, int>>();
    var cases = GetPermutation(list);
    foreach (var test in cases)
    {
        var tree = new Bst<int, int>();
        foreach (var num in test)
        {
            tree.Put(num, num);
        }

        // 是否存在相同结构的二叉树。
        if (trees.Any(t => Bst<int, int>.IsStructureEqual(tree, t)))
            continue;

        Console.WriteLine(tree);
        trees.Add(tree);
    }
}

List<int[]> GetPermutation(List<int> s)
{
    var permutation = new List<int[]>();
    var temp = new List<int>();
    Permutation(s, temp, permutation);
    return permutation;
}

void Permutation(List<int> pool, List<int> path, List<int[]> result)
{
    if (pool.Count == 0)
    {
        result.Add(path.ToArray());
        return;
    }

    for (var i = 0; i < pool.Count; i++)
    {
        var item = pool[i];
        path.Add(item);
        pool.RemoveAt(i);
        Permutation(pool, path, result);
        pool.Insert(i, item);
        path.Remove(item);
    }
}