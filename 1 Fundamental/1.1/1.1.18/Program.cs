using System;

Console.WriteLine($@"Mystery(2, 25): {Mystery(2, 25)}");
Console.WriteLine($@"Mystery(3, 11): {Mystery(3, 11)}");

Console.WriteLine($@"mysteryChanged(2, 8): {MysteryChanged(2, 8)}");
Console.WriteLine($@"mysteryChanged(3, 2): {MysteryChanged(3, 2)}");

// Mystery(a, b) = a * b
// 利用等式：a * b = 2a * b/2 = (2a * (b-1) / 2) + a
// 示例：
// Mystery(2, 25) =
// Mystery(2 + 2, 12) + 2 =
// Mystery(4 + 4, 6) + 2 =
// Mystery(8 + 8, 3) =
// Mystery(16 + 16, 1) + 16 + 2 =
// Mystery(32 + 32, 0) + 32 + 16 + 2 =
// 0 + 32 + 16 + 2 =
// 50
static int Mystery(int a, int b)
{
    if (b == 0)
        return 0;
    if (b % 2 == 0)
        return Mystery(a + a, b / 2);
    return Mystery(a + a, b / 2) + a;
}

// mysteryChanged(a, b) = a ^ b
// 同理（乘方与乘法，乘法与加法之间具有类似的性质）
// a ^ b = (a ^ 2) ^ (b / 2) = (a ^ 2) ^ ((b - 1) / 2) * a
static int MysteryChanged(int a, int b)
{
    if (b == 0)
        return 1;
    if (b % 2 == 0)
        return MysteryChanged(a * a, b / 2);
    return MysteryChanged(a * a, b / 2) * a;
}