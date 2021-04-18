using System;
using _2._2._12;

// 中文版的翻译比较难理解
// 实际上就是另一种归并排序的实现方式
// 先把数组分成若干个大小为 M 的块
// 对于每个块，用选择排序进行排序
// 随后遍历数组，将各个块归并起来
var a = new[] { 1, 3, 5, 7, 9, 2, 4, 6, 8, -1 };
var mergeSort = new MergeSort();
mergeSort.Sort(a, 3);
for (var i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();