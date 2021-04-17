using System;
using System.Collections.Generic;
using System.IO;
// ReSharper disable PossibleNullReferenceException

// 从largeW.txt中读取数据
// 用 HashSet 的不可重复性去除重复
var hashSet = new HashSet<string>(File.ReadAllLines("largeW.txt"));
var strings = new string[hashSet.Count];
hashSet.CopyTo(strings);
var whiteList = new int[strings.Length];
for (var i = 0; i < strings.Length; i++)
{
    whiteList[i] = int.Parse(strings[i]);
}

Array.Sort(whiteList);
Console.WriteLine(@"Type the numbers you want to query: ");
// 输入样例：5 824524 478510 387221
var input = Console.ReadLine();
var query = new int[input.Split(' ').Length];
for (var i = 0; i < query.Length; i++)
{
    query[i] = int.Parse(input.Split(' ')[i]);
}

Console.WriteLine(@"Irrelevant:");
foreach (var n in query)
{
    if (Rank(n, whiteList) == -1)
    {
        Console.WriteLine(n);
    }
}

static int Rank(int key, int[] a)
{
    return RankInternal(key, a, 0, a.Length - 1);
}

static int RankInternal(int key, int[] a, int lo, int hi)
{
    if (lo > hi)
    {
        return -1;
    }

    var mid = lo + (hi - lo) / 2;

    if (key < a[mid])
    {
        return RankInternal(key, a, lo, mid - 1);
    }
    else if (key > a[mid])
    {
        return RankInternal(key, a, mid + 1, hi);
    }
    else
    {
        return mid;
    }
}