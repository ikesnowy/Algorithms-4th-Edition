using System;
// ReSharper disable PossibleNullReferenceException

/*
 * 输入
 * 
 * 用空格隔开的三个整数，例如
 * 3 3 3
 * 
 * 输出
 * 
 * equal 或 not equal
 */
var input = Console.ReadLine();
var a = int.Parse(input.Split(' ')[0]);
var b = int.Parse(input.Split(' ')[1]);
var c = int.Parse(input.Split(' ')[2]);

if (a == b && b == c)
{
    Console.WriteLine("equal");
}
else
{
    Console.WriteLine("not equal");
}