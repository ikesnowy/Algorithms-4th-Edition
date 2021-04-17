using System;
using System.IO;
using _1._2._9;

// 参考 1.1.10 节的代码
var count = new Counter("BinarySearch");

// 读取白名单
var whiteListString = File.ReadAllLines("tinyW.txt");
var whiteList = new int[whiteListString.Length];

for (var i = 0; i < whiteListString.Length; i++)
{
    whiteList[i] = int.Parse(whiteListString[i]);
}

Array.Sort(whiteList);

// 读取查询值
var inputListString = File.ReadAllLines("tinyT.txt");
var inputList = new int[inputListString.Length];

for (var i = 0; i < inputListString.Length; i++)
{
    inputList[i] = int.Parse(inputListString[i]);
}

// 对每一个查询值进行二分查找
foreach (var n in inputList)
{
    var result = Rank(n, whiteList, count);
    // 将不在白名单上的数据输出
    if (result == -1)
    {
        Console.WriteLine(n);
    }
}

Console.WriteLine();

// 输出查询数目
Console.WriteLine(count.Tally());

static int Rank(int key, int[] a, Counter count)
{
    var lo = 0;
    var hi = a.Length - 1;
    while (lo <= hi)
    {
        var mid = lo + (hi - lo) / 2;
        count.Increment();
        if (key < a[mid])
        {
            hi = mid - 1;
        }
        else if (key > a[mid])
        {
            lo = mid + 1;
        }
        else
        {
            return mid;
        }
    }

    return -1;
}