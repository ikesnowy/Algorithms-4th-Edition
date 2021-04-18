using System;
using System.Diagnostics;
using PriorityQueue;
// ReSharper disable RedundantJumpStatement

var repeatTime = 1000000;
double totalTime = 0;
for (var i = 0; i < repeatTime; i++)
{
    var pq = new MaxPq<char>();
    totalTime += Test(pq);
}

Console.WriteLine("Normal MaxPQ: " + totalTime);

totalTime = 0;
for (var i = 0; i < repeatTime; i++)
{
    var pqNoExch = new MaxPqNoExch<char>();
    totalTime += Test(pqNoExch);
}

Console.WriteLine("MaxPQ without Exch: " + totalTime);

static long Test(IMaxPq<char> pq)
{
    var sw = new Stopwatch();
    sw.Restart();
    var input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
    foreach (var c in input)
    {
        if (c == ' ')
        {
            continue;
        }
        else if (c == '*')
        {
            pq.DelMax();
        }
        else
        {
            pq.Insert(c);
        }
    }

    sw.Stop();
    return sw.ElapsedMilliseconds;
}