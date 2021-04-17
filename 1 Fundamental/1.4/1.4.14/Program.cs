using System;
using Measurement;

// char[] split = new char[1] { '\n' };
// string[] testcases = TestCase.Properties.Resources._1Kints.Split(split, StringSplitOptions.RemoveEmptyEntries);
// long[] a = new long[testcases.Length];
// for (int i = 0; i < testcases.Length; i++)
// {
//     a[i] = long.Parse(testcases[i]);
// }

var a = new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };

var timer = new Stopwatch();
FourSum.PrintAll(a);
Console.WriteLine(timer.ElapsedTime());