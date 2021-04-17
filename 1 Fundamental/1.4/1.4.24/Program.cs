using System;

const int f = 100; // 需要寻找的 F 值
var building = new int[100000];
for (var i = 0; i < 100000; i++)
{
    building[i] = i;
}

// 第一问：二分查找即可
var a = PlanA(building);
Console.WriteLine($@"Plan A: F={a.F}, Broken Eggs={a.BrokenEggs}");

// 第二问：按照第 1, 2, 4, 8,..., 2^k 层顺序查找，一直到 2^k > F，
// 随后在 [2^(k - 1), 2^k] 范围中二分查找。
var b = PlanB(building);
Console.WriteLine($@"Plan B: F={b.F}, Broken Eggs={b.BrokenEggs}");

static bool ThrowEgg(int floor)
{
    return floor <= f;
}

static TestResult PlanA(int[] a)
{
    var lo = 0;
    var hi = a.Length - 1;
    var eggs = 0;
    var result = new TestResult();

    while (lo <= hi)
    {
        var mid = lo + (hi - lo) / 2;
        if (ThrowEgg(mid))
        {
            lo = mid + 1;
        }
        else
        {
            eggs++;
            hi = mid - 1;
        }
    }

    result.BrokenEggs = eggs;
    result.F = hi;
    return result;
}

static TestResult PlanB(int[] a)
{
    var lo = 0;
    var hi = 1;
    var eggs = 0;
    var result = new TestResult();

    while (ThrowEgg(hi))
    {
        lo = hi;
        hi *= 2;
    }

    eggs++;

    if (hi > a.Length - 1)
    {
        hi = a.Length - 1;
    }

    while (lo <= hi)
    {
        var mid = lo + (hi - lo) / 2;
        if (ThrowEgg(mid))
        {
            lo = mid + 1;
        }
        else
        {
            eggs++;
            hi = mid - 1;
        }
    }

    result.BrokenEggs = eggs;
    result.F = hi;
    return result;
}

struct TestResult
{
    public int F; // 找到的 F 值。
    public int BrokenEggs; // 打碎的鸡蛋数。
}