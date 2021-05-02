using System;
using BinarySearchTree;

var bst = new Bst<string, int>();
var tale = BinarySearchTree.Properties.Resources.tale.Split(' ', StringSplitOptions.RemoveEmptyEntries);
var distinctCount = FrequencyCounter.CountDistinct(tale, bst);
Console.WriteLine(@"distinctCount: " + distinctCount);

// 二叉查找树的内存开销 = 对象开销 + 根结点引用 + N个结点
//     = 对象开销 + 根结点引用 + N×(对象开销 + 父类型引用 + 左 / 右子树引用 + 键 / 值引用 + 结点数)
//     = 16 + 8 + N×(16 + 8 + 16 + 16 + 4 + 4) = 24 + 64N 字节

// BinarySearchST：对象开销 + 键 / 值数组引用 + 键 / 值数组 + 计数器（一个 int）。
//     = 16 + 16 + (16 + 4 + 4 + 8N)×2 + 4 + 4 = 88 + 16N 字节。

// SequentialSearchST：对象开销 + 头结点引用 + N个结点 + 计数器
//     = 对象开销 + 头结点引用 + N×(对象开销 + 父类型引用 + next引用 + 键 / 值引用) + 计数器
//     = 16 + 8 + N×(16 + 8 + 8 + 16) + 4 + 4 = 32 + 48N 字节

// 《双城记》中不重复的单词有 26436 个（不包括最后的版权声明），全部是原文的子字符串，每个占 40 字节。
// 一个 Integer 占 24 字节，于是估计的内存消耗为：24 + (64 + 40 + 24)×26436 = 3383832 字节。