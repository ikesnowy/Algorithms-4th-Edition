using System;
using _2._3._29;
using Quick;

Console.WriteLine(@"M	N	shuffle	random	shuffle/random");
Trial(10);
Trial(20);
Trial(50);

// 进行一次测试。
static void Trial(int m)
{
    var withShuffle = new QuickSortInsertion();
    var randomPivot = new QuickSortRandomPivot();
    var trialTime = 5;

    // M=10
    withShuffle.M = m;
    randomPivot.M = m;
    double timeShuffle = 0;
    double timeRandomPivot = 0;
    for (var n = 1000; n < 10000000; n *= 10)
    {
        for (var i = 0; i < trialTime; i++)
        {
            var a = new int[n];
            var b = new int[n];
            for (var j = 0; j < n; j++)
            {
                a[j] = j;
            }

            Shuffle(a);
            a.CopyTo(b, 0);
            timeShuffle += SortCompare.Time(withShuffle, a);
            timeRandomPivot += SortCompare.Time(randomPivot, b);
        }

        timeShuffle /= trialTime;
        timeRandomPivot /= trialTime;
        Console.WriteLine(
            withShuffle.M
            + "\t"
            + n
            + "\t"
            + timeShuffle
            + "\t"
            + timeRandomPivot
            + "\t"
            + timeShuffle / timeRandomPivot);
    }
}

// 打乱数组。
static void Shuffle<T>(T[] a)
{
    var random = new Random();
    for (var i = 0; i < a.Length; i++)
    {
        var r = i + random.Next(a.Length - i);
        var temp = a[i];
        a[i] = a[r];
        a[r] = temp;
    }
}