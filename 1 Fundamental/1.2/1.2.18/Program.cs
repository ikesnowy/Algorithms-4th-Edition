// 当数据比较大时—— 例如 10^9 加上随机小数组成的数列，这时 double 的小数精度将受限。
// 求和之后整数部分更大，小数部分将自动四舍五入，出现误差
// 这时再计算平均值时将会带来较大的误差。
// 因此采用另一个递推公式：
// k 为下标。
// Mk = Mk-1+ (xk – Mk-1)/k
// Sk = Sk-1 + (xk – Mk-1)*(xk – Mk).
// 方差 s^2 = Sk/(k – 1).
// 这种情况下并没有直接对所有输入值求和，小数精度不受到整数部分长度的影响。

using System;
using _1._2._18;

var T = 100000;
var random = new Random();
var a = new Accumulator();
for (var t = 0; t < T; t++)
{
    a.AddDataValue(random.NextDouble() + 1000000000);
}

Console.WriteLine(a.Stddev());
Console.WriteLine(a);