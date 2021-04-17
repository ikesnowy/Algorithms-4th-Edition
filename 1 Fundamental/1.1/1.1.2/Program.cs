using System;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

// var 变量名 = 初始值  根据初始值自动判断变量类型
var a = (1 + 2.236) / 2;
var b = 1 + 2 + 3 + 4.0;
var c = 4.1 >= 4;
var d = 1 + 2 + "3";

// Console.WriteLine 向控制台输出一行
// 变量名.GetType() 返回变量类型

Console.WriteLine("\tName\tType     \tValue");
Console.WriteLine($"\ta\t{a.GetType()}\t{a}");
Console.WriteLine($"\tb\t{b.GetType()}\t{b}");
Console.WriteLine($"\tc\t{c.GetType()}\t{c}");
Console.WriteLine($"\td\t{d.GetType()}\t{d}");