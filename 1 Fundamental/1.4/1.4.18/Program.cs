using System;

var a = new[] { 1, 2, 5, 3, 5 };
Console.WriteLine(LocalMinimum(a));

static int LocalMinimum(int[] a)
{
    var lo = 0;
    var hi = a.Length - 1;
    while (lo <= hi)
    {
        var mid = (hi - lo) / 2 + lo;
        var min = mid;

        // 取左中右最小值的下标
        if (mid != hi && a[min] >= a[mid + 1])
            min = mid + 1;
        if (mid != lo && a[min] >= a[mid - 1])
            min = mid - 1;

        if (min == mid)
            return mid;
        if (min > mid)
            lo = min;
        else
            hi = min;
    }

    return -1;
}