using System;

var s1 = "ACTGACG";
var s2 = "TGACGAC";

Console.WriteLine(Circular(s1, s2));

// 对于任意字符串 s，将其拆分成 s = s1 + s2（s2长度即为循环移动的位数）
// 其回环变位则为 s' = s2 + s1
// 显然 s' + s' = s2 + s1 + s2 + s1
// 即 s' + s' = s2 + s + s1，其中必定包含 s
// 例如 ABC 和 BCA， BCABCA 显然包含 ABC
static bool Circular(string s1, string s2)
{
    return s1.Length == s2.Length && (s2 + s2).Contains(s1);
}