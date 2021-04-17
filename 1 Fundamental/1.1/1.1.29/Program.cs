using System;
// ReSharper disable PossibleNullReferenceException

var whiteList = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
Array.Sort(whiteList);
Console.WriteLine("Type the numbers you want to query: ");
var input = Console.ReadLine();
var query = new int[input.Split(' ').Length];
for (var i = 0; i < query.Length; i++)
{
    query[i] = int.Parse(input.Split(' ')[i]);
}

Console.WriteLine("Result:");
foreach (var n in query)
{
    var less = Rank(n, whiteList);
    var equal = Count(n, whiteList);
    Console.WriteLine($"Less: {less} Equal: {equal}");
}

static int Count(int key, int[] a)
{
    var lowerBound = Rank(key, a);
    var upperBound = lowerBound;

    if (lowerBound == -1)
        return 0;

    while (true)
    {
        var result = RankInternal(key, a, upperBound + 1, a.Length - 1);
        if (result == -1)
            break;
        if (result > upperBound)
        {
            upperBound = result;
        }
    }

    return upperBound - lowerBound + 1;
}

static int Rank(int key, int[] a)
{
    var mid = RankInternal(key, a, 0, a.Length - 1);
    if (mid == -1)
        return 0;
    while (true)
    {
        var result = RankInternal(key, a, 0, mid - 1);

        if (result == -1)
            break;
        if (result < mid)
            mid = result;
    }

    return mid;
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