using System;

int binomialCalled = 0; // 计算递归调用次数
double?[,] binomialCache; // 保存计算结果的数组

binomialCache = new double?[101, 51];
Console.WriteLine(Binomial(100, 50, 0.25));
Console.WriteLine(binomialCalled);

double? Binomial(int N, int k, double p)
{
    binomialCalled++;
    if (N == 0 && k == 0)
        return 1.0;
    if (N < 0 || k < 0)
        return 0.0;
    if (binomialCache[N, k] != null)
    {
        return binomialCache[N, k];
    }
    else
    {
        binomialCache[N, k] = (1.0 - p) * Binomial(N - 1, k, p) + p * Binomial(N - 1, k - 1, p);
        return binomialCache[N, k];
    }
}