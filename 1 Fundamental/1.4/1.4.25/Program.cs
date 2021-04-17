using System;

const int f = 100; // 需要寻找的 F 值
var building = new int[100000];
for (var i = 0; i < 100000; i++)
{
    building[i] = i;
}

// 第一问：第一个蛋按照 √(N), 2√(N), 3√(N), 4√(N),..., √(N) * √(N) 顺序查找直至碎掉。这里扔了 k 次，k <= √(N)
// k-1√(N) ~ k√(N) 顺序查找直至碎掉，F 值就找到了。这里最多扔 √(N) 次。
var a = PlanA(building);
Console.WriteLine($@"Plan A: F={a.F}, Broken Eggs={a.BrokenEggs}, Throw Times={a.ThrowTimes}");

// 第二问：按照第 1, 3, 6, 10,..., 1/2k^2 层顺序查找，一直到 1/2k^2 > F，
// 随后在 [1/2k^2 - k, 1/2k^2] 范围中顺序查找。
var b = PlanB(building);
Console.WriteLine($@"Plan B: F={b.F}, Broken Eggs={b.BrokenEggs}, Throw Times={b.ThrowTimes}");

// 扔鸡蛋，没碎返回 true，碎了返回 false。
static bool ThrowEgg(int floor)
{
    return floor <= f;
}

// 第一种方案。
static TestResult PlanA(int[] a)
{
    var lo = 0;
    var hi = 0;
    var eggs = 0;
    var throwTimes = 0;
    var result = new TestResult();

    while (ThrowEgg(hi))
    {
        throwTimes++;
        lo = hi;
        hi += (int)Math.Sqrt(a.Length);
    }

    eggs++;

    if (hi > a.Length - 1)
    {
        hi = a.Length - 1;
    }

    while (lo <= hi)
    {
        if (!ThrowEgg(lo))
        {
            eggs++;
            break;
        }

        throwTimes++;
        lo++;
    }

    result.BrokenEggs = eggs;
    result.F = lo - 1;
    result.ThrowTimes = throwTimes;
    return result;
}

// 第二种方案。
static TestResult PlanB(int[] a)
{
    var lo = 0;
    var hi = 0;
    var eggs = 0;
    var throwTimes = 0;
    var result = new TestResult();

    for (var i = 0; ThrowEgg(hi); i++)
    {
        throwTimes++;
        lo = hi;
        hi += i;
    }

    eggs++;

    if (hi > a.Length - 1)
    {
        hi = a.Length - 1;
    }

    while (lo <= hi)
    {
        if (!ThrowEgg(lo))
        {
            eggs++;
            break;
        }

        lo++;
        throwTimes++;
    }

    result.BrokenEggs = eggs;
    result.F = lo - 1;
    result.ThrowTimes = throwTimes;
    return result;
}

struct TestResult
{
    public int F; // 测试得出的 F 值
    public int BrokenEggs; // 碎掉的鸡蛋数。
    public int ThrowTimes; // 扔鸡蛋的次数。
}