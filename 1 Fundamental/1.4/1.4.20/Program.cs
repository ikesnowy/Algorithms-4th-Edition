using System;
using _1._4._20;

var a = BitonicMax.Bitonic(100);
var max = BitonicMax.Max(a, 0, a.Length - 1);
var key = a[50];
var leftSide = BinarySearchAscending(a, key, 0, max);
var rightSide = BinarySearchDescending(a, key, max, a.Length - 1);
if (leftSide != -1)
{
    Console.WriteLine(leftSide);
}
else if (rightSide != -1)
{
    Console.WriteLine(rightSide);
}
else
{
    Console.WriteLine(@"No Result");
}

static int BinarySearchAscending(int[] a, int key, int lo, int hi)
{
    while (lo <= hi)
    {
        var mid = lo + (hi - lo) / 2;

        if (a[mid] < key)
        {
            lo = mid + 1;
        }
        else if (a[mid] > key)
        {
            hi = mid - 1;
        }
        else
        {
            return mid;
        }
    }

    return -1;
}

static int BinarySearchDescending(int[] a, int key, int lo, int hi)
{
    while (lo < hi)
    {
        var mid = lo + (hi - lo) / 2;

        if (a[mid] > key)
        {
            lo = mid + 1;
        }
        else if (a[mid] < key)
        {
            hi = mid - 1;
        }
        else
        {
            return mid;
        }
    }

    return -1;
}