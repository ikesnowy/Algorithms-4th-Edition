using System;

// 书中给出的程序
const int sides = 6;
var dist = new double[2 * sides + 1];
for (var i = 1; i <= sides; i++)
for (var j = 1; j <= sides; j++)
    dist[i + j] += 1.0;

for (var k = 2; k <= 2 * sides; k++)
    dist[k] /= 36.0;

// 不断进行模拟，直至误差小于 0.001
var n = 36;
var isAccepted = false;
double[] distTemp = null;
const double error = 0.001;
while (isAccepted == false)
{
    distTemp = PlayDice(n);
    isAccepted = true;
    for (var i = 0; i < distTemp.Length; i++)
    {
        if (Math.Abs(distTemp[i] - dist[i]) >= error)
            isAccepted = false;
    }

    n++;
}

Console.WriteLine($"times:{n}\n");
for (var i = 0; i < dist.Length; i++)
{
    Console.WriteLine($"{i}:\n Standerd:{dist[i]}\nSimulated:{distTemp[i]}\nOffset:{Math.Abs(distTemp[i] - dist[i])}");
}

static double[] PlayDice(int times)
{
    var random = new Random();

    const int sides = 6;
    var dist = new double[2 * sides + 1];

    // 掷 times 次
    for (var i = 0; i < times; i++)
    {
        var sumTemp = random.Next(1, 7) + random.Next(1, 7);
        dist[sumTemp]++;
    }

    // 计算概率
    for (var i = 0; i < dist.Length; i++)
    {
        dist[i] /= times;
    }

    return dist;
}