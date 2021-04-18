using System;

int binomialCalled = 0; // 计算递归调用次数
double?[,] binomialCache; // 保存计算结果的数组

binomialCache = new double?[101, 51];
Console.WriteLine(Binomial(100, 50, 0.25));
Console.WriteLine(binomialCalled);

double? Binomial(int n, int k, double p)
{
    binomialCalled++;
    if (n == 0 && k == 0)
        return 1.0;
    if (n < 0 || k < 0)
        return 0.0;
    if (binomialCache[n, k] != null)
    {
        return binomialCache[n, k];
    }
    else
    {
        binomialCache[n, k] = (1.0 - p) * Binomial(n - 1, k, p) + p * Binomial(n - 1, k - 1, p);
        return binomialCache[n, k];
    }
}