using System;

const int n = 4;
Console.WriteLine($@"{FactorialLn(n)}");

// ln(N!) =
// ln(N * (N - 1) * ... * 1) =
// ln(N) + ln((N - 1)!)
static double FactorialLn(int n)
{
    if (n == 1)
    {
        return 0;
    }

    return Math.Log(n) + FactorialLn(n - 1);
}