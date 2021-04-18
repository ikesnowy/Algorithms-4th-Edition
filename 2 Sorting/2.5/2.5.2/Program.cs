using System;
using System.Collections.Generic;
// ReSharper disable PossibleNullReferenceException

var keywords = Console.ReadLine().Split(' ');
Array.Sort(keywords, new StringLengthComparer());
var minLength = keywords[0].Length * 2;
// 找到第一个大于 minLength 的字符串
var canCombine = 0;
while (keywords[canCombine].Length < minLength && canCombine < keywords.Length)
    canCombine++;

// 依次测试是否可能
while (canCombine < keywords.Length)
{
    var sum = keywords[canCombine].Length;
    for (var i = 0; i < canCombine; i++)
    {
        var start = BinarySearch(keywords, sum - keywords[i].Length, i, canCombine);
        if (start != -1)
        {
            while (keywords[start].Length + keywords[i].Length == sum)
            {
                if (keywords[start] + keywords[i] == keywords[canCombine])
                    Console.WriteLine(keywords[canCombine] + " = " + keywords[start] + " + " + keywords[i]);
                else if (keywords[i] + keywords[start] == keywords[canCombine])
                    Console.WriteLine(keywords[canCombine] + " = " + keywords[i] + " + " + keywords[start]);
                start++;
            }
        }
    }

    canCombine++;
}

// 二分查找，返回符合条件的最小下标。
static int BinarySearch(string[] keys, int length, int lo, int hi)
{
    while (lo <= hi)
    {
        var mid = lo + (hi - lo) / 2;
        if (keys[mid].Length == length)
        {
            while (mid >= lo && keys[mid].Length == length)
                mid--;
            return mid + 1;
        }
        else if (length > keys[mid].Length)
            lo = mid + 1;
        else
            hi = mid - 1;
    }

    return -1;
}

/// <summary>
/// 根据字符串长度进行比较。
/// </summary>
internal class StringLengthComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return x.Length.CompareTo(y.Length);
    }
}