using System;
// ReSharper disable StringCompareToIsCultureSpecific

// if (this == that) return 0;
// 如果比较的两个 string 是同一个对象的引用，直接返回相等结果
// 而不必再逐字符比较。
var s = "123456";
var p = s;
Console.WriteLine(s.CompareTo(p)); // 输出 0