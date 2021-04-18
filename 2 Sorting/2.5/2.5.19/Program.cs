using System;
using _2._5._19;

// 官方解答：
// https://algs4.cs.princeton.edu/25applications/KendallTau.java.html
// https://algs4.cs.princeton.edu/22mergesort/Inversions.java.html

int[] testA = { 0, 3, 1, 6, 2, 5, 4 };
int[] testB = { 1, 0, 3, 6, 4, 2, 5 };
Console.WriteLine(Distance(testA, testB));

static long Distance(int[] a, int[] b)
{
    if (a.Length != b.Length)
        throw new ArgumentException("Array dimensions disagree");
    var n = a.Length;

    var ainv = new int[n];
    for (var i = 0; i < n; i++)
    {
        ainv[a[i]] = i;
    }

    var bnew = new int[n];
    for (var i = 0; i < n; i++)
    {
        bnew[i] = ainv[b[i]];
    }

    var inversions = new Inversions();
    inversions.Count(bnew);
    return inversions.Counter;
}