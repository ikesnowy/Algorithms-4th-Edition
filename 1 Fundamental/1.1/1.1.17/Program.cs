using System;
// ReSharper disable FunctionRecursiveOnAllPaths

Console.WriteLine($@"{ExR2(6)}"); // 抛出 StackOverflow Exception

static string ExR2(int n)
{
    var s = ExR2(n - 3) + n + ExR2(n - 2) + n; // 运行到 ExR2 即展开，不会再运行下一句
    if (n <= 0)
    {
        return "";
    }

    return s;
}