using System;

const int n = 4;
Console.WriteLine($@"{FactorialLn(n)}");

// ln(N!) =
// ln(N * (N - 1) * ... * 1) =
// ln(N) + ln((N - 1)!)
static double FactorialLn(int N)
{
    if (N == 1)
    {
        return 0;
    }

    return Math.Log(N) + FactorialLn(N - 1);
}