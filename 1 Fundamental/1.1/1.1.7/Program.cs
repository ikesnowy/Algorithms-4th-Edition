using System;

static void A()
{
    Console.WriteLine("a");
    var t = 9.0;
    while (Math.Abs(t - 9.0 / t) > .001)
    {
        t = (9.0 / t + t) / 2.0;
    }

    Console.Write($"{t:N5}\n"); // :N5代表保留5位小数，同理可使用N1、N2……
}

static void B()
{
    Console.WriteLine("\nb");
    var sum = 0;
    for (var i = 1; i < 1000; i++)
    {
        for (var j = 0; j < i; j++)
        {
            sum++;
        }
    }

    Console.WriteLine(sum);
}

static void C()
{
    Console.WriteLine("\nc");
    var sum = 0;
    for (var i = 1; i < 1000; i *= 2)
    {
        for (var j = 0; j < 1000; j++)
        {
            sum++;
        }
    }

    Console.WriteLine(sum);
}

// A double 计算存在误差
A();

// B 1000+999+998……
B();

// C 由于2^10 = 1024 > 1000，最终sum = 1000 * 10 = 10000
C();