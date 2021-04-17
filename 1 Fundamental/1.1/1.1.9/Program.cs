using System;

var N = 4;

// 1.直接转换 Convert.ToString(int, int) 第一个为要转换的数，第二个为要转换的进制
Console.WriteLine($"{Convert.ToString(N, 2)}");

// 2.转换为二进制数
var s = "";
for (var n = N; n > 0; n /= 2)
{
    s = (n % 2) + s;
}

Console.WriteLine(s);