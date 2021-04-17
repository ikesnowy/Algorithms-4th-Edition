using System;

var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Rank(9, array);

static int Rank(int key, int[] a)
{
    return RankInternal(key, a, 0, a.Length - 1, 1);
}

static int RankInternal(int key, int[] a, int lo, int hi, int number)
{

    for (var i = 0; i < number; i++)
    {
        Console.Write(" ");
    }

    Console.WriteLine($"{number}: {lo} {hi}");

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