using System;

Console.WriteLine($@"{ExR1(6)}");

// ExR1(6) = 
// ExR1(3) + 6 + ExR1(4) + 6
// ExR1(0) + 3 + ExR1(1) + 3 + 6 + ExR1(4) + 6
// "" + 3 + ExR1(-2) + 1 + ExR1(-1) + 1 + 3 + 6 + ExR1(4) + 6
// "" + 3 + "" + 1 + "" + 1 + 3 + 6 + ExR1(4) + 6
// "31136" + ExR1(4) + 6
// ......

static string ExR1(int n)
{
    if (n <= 0)
    {
        return "";
    }

    return ExR1(n - 3) + n + ExR1(n - 2) + n;
}
