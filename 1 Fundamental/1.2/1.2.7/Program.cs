using System;

Console.WriteLine(Mystery("Hello1"));

static string Mystery(string s)
{
    var n = s.Length;
    if (n <= 1)
        return s;
    var a = s.Substring(0, n / 2);
    var b = s.Substring(n / 2, n - n / 2);

    return Mystery(b) + Mystery(a);
}