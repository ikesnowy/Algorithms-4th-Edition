using System;

int[] data = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
var index = IndirectSort(data);
for (var i = 0; i < data.Length; i++)
{
    Console.Write(data[i] + " ");
}

Console.WriteLine();
for (var i = 0; i < index.Length; i++)
{
    Console.Write(index[i] + " ");
}

Console.WriteLine();

// 间接排序。
static int[] IndirectSort<T>(T[] keys) where T : IComparable<T>
{
    var n = keys.Length;
    var index = new int[n];
    for (var i = 0; i < n; i++)
        index[i] = i;

    for (var i = 0; i < n; i++)
    for (var j = i; j > 0 && keys[index[j]].CompareTo(keys[index[j - 1]]) < 0; j--)
    {
        var temp = index[j];
        index[j] = index[j - 1];
        index[j - 1] = temp;
    }

    return index;
}