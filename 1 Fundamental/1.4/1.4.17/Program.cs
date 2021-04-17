using System;

var a = new[] { 0.1, 0.3, 0.6, 0.8, 0 };
double min = int.MaxValue;
double max = int.MinValue;

for (var i = 0; i < a.Length; i++)
{
    if (a[i] > max)
    {
        max = a[i];
    }

    if (a[i] < min)
    {
        min = a[i];
    }
}

Console.WriteLine($@"MaxDiff Pair: {min} {max}, Max Difference: {Math.Abs(max - min)}");