using System;

Gcd(105, 24);
Console.WriteLine();
Gcd(111111, 1234567);

static int Gcd(int a, int b)
{
    Console.WriteLine($@"{a} {b}");
    if (b == 0)
    {
        return a;
    }

    return Gcd(b, a % b);
}