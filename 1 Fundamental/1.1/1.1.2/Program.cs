using System;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

// var 变量名 = 初始值  根据初始值自动判断变量类型
var a = (1 + 2.236) / 2;
var b = 1 + 2 + 3 + 4.0;
var c = 4.1 >= 4;
var d = 1 + 2 + "3";

// Console.WriteLine 向控制台输出一行
// 变量名.GetType() 返回变量类型

Console.WriteLine(@"	Name	Type     	Value");
Console.WriteLine($@"	a	{a.GetType()}	{a}");
Console.WriteLine($@"	b	{b.GetType()}	{b}");
Console.WriteLine($@"	c	{c.GetType()}	{c}");
Console.WriteLine($@"	d	{d.GetType()}	{d}");