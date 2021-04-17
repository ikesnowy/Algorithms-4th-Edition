using System;
using System.Diagnostics;
using System.IO;
// ReSharper disable UnusedLocalFunctionReturnValue
// ReSharper disable UnusedParameter.Local

var largeWString = File.ReadAllLines("largeW.txt");
var largeW = new int[largeWString.Length];
for (var i = 0; i < largeW.Length; i++)
{
    largeW[i] = int.Parse(largeWString[i]);
}

var timer = Stopwatch.StartNew();
BruteForceSearch(111111, largeW);
Console.WriteLine($@"BruteForceSearch: {timer.ElapsedMilliseconds} ms");
timer.Restart();
Rank(111111, largeW);
Console.WriteLine($@"BinarySearch: {timer.ElapsedMilliseconds} ms");
var largeTString = File.ReadAllLines("largeT.txt");
var largeT = new int[largeTString.Length];
for (var i = 0; i < largeW.Length; i++)
{
    largeT[i] = int.Parse(largeTString[i]);
}

timer.Restart();
BruteForceSearch(111111, largeT);
Console.WriteLine($@"BruteForceSearch: {timer.ElapsedMilliseconds} ms");
timer.Restart();
Rank(111111, largeT);
Console.WriteLine($@"BinarySearch: {timer.ElapsedMilliseconds} ms");

static int BruteForceSearch(int key, int[] a)
{
    for (var i = 0; i < a.Length; i++)
    {
        if (a[i] == key)
            return i;
    }

    return -1;
}

static int Rank(int key, int[] a)
{
    return RankInternal(key, a, 0, a.Length - 1, 1);
}

static int RankInternal(int key, int[] a, int lo, int hi, int number)
{
    if (lo > hi)
    {
        return -1;
    }

    var mid = lo + (hi - lo) / 2;

    if (key < a[mid])
    {
        return RankInternal(key, a, lo, mid - 1, number + 1);
    }
    else if (key > a[mid])
    {
        return RankInternal(key, a, mid + 1, hi, number + 1);
    }
    else
    {
        return mid;
    }
}