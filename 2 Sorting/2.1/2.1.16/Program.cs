using System;
// ReSharper disable StringCompareToIsCultureSpecific

var test = new[] { "a", "b", "d", "c", "e" };
Console.WriteLine(CheckArraySort(test));
Console.WriteLine(CheckSelectionSort(test));

// 测试 Array.Sort() 方法。
static bool CheckArraySort(string[] a)
{
    var backup = new string[a.Length];
    a.CopyTo(backup, 0);

    Array.Sort(a);

    foreach (var n in a)
    {
        var isFind = false;
        for (var i = 0; i < a.Length; i++)
        {
            if (ReferenceEquals(n, backup[i]))
            {
                isFind = true;
                break;
            }
        }

        if (!isFind)
        {
            return false;
        }
    }

    return true;
}

// 测试选择排序。
static bool CheckSelectionSort(string[] a)
{
    var backup = new string[a.Length];
    a.CopyTo(backup, 0);

    SelectionSort(a);

    foreach (var n in a)
    {
        var isFind = false;
        for (var i = 0; i < a.Length; i++)
        {
            if (ReferenceEquals(n, backup[i]))
            {
                isFind = true;
                break;
            }
        }

        if (!isFind)
        {
            return false;
        }
    }

    return true;
}

// 选择排序，其中的交换部分使用新建对象并复制的方法。
static void SelectionSort(string[] s)
{
    for (var i = 0; i < s.Length; i++)
    {
        var min = i;
        for (var j = i + 1; j < s.Length; j++)
        {
            if (s[j].CompareTo(s[min]) < 0)
            {
                min = j;
            }
        }

        var temp = new string(s[i].ToCharArray());
        s[i] = s[min];
        s[min] = temp;
    }
}