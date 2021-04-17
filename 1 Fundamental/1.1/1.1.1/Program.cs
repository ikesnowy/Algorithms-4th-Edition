using System;
// ReSharper disable RedundantLogicalConditionalExpressionOperand
// ReSharper disable ConditionIsAlwaysTrueOrFalse

var a = (0 + 15) / 2;
var b = 2.0e-6 * 100000000.1;
var c = true && false || true && true;

// Console.WriteLine 向控制台窗口输出一行
Console.WriteLine($@"a.{a}");
Console.WriteLine($@"b.{b}");
Console.WriteLine($@"c.{c}");
