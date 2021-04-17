using System;
// ReSharper disable AssignNullToNotNullAttribute

// 互质 = 最大公约数为 1 = gcd(i, j) == 1
var n = int.Parse(Console.ReadLine());

var a = new bool[n, n];

for (var i = 0; i < n; i++)
{
    for (var j = 0; j < n; j++)
    {
        a[i, j] = (Gcd(i, j) == 1);
    }
}

PrintArray2D(a, n, n);

static int Gcd(int a, int b)
{
    if (b == 0)
        return a;

    return Gcd(b, a % b);
}

static void PrintArray2D(bool[,] array, int rows, int columns)
{
    for (var i = 0; i < rows; i++)
    {
        for (var j = 0; j < columns; j++)
        {
            Console.Write($@"	{array[i, j]}");
        }

        Console.Write(@"
");
    }
}