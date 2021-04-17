using System;
using _1._4._34;

var game = new Game(1000);
var a = PlayGameA(game);
game.Restart();
var b = PlayGameB(game);
Console.WriteLine($@"SecretNumber:{game.SecretNumber}");
Console.WriteLine(@"TestResultA:");
Console.WriteLine($@"SecretNumber:{a.SecretNumber}, TryTimes:{a.TryTimes}");
Console.WriteLine();
Console.WriteLine(@"TestResultB:");
Console.WriteLine($@"SecretNumber:{b.SecretNumber}, TryTimes:{b.TryTimes}");

// 方案一，用二分查找实现，需要猜测 2lgN 次。
static TestResult PlayGameA(Game game)
{
    TestResult result;
    result.TryTimes = 0;
    result.SecretNumber = 0;

    var hi = game.N;
    var lo = 1;

    // 利用二分查找猜测，2lgN
    while (lo <= hi)
    {
        var mid = lo + (hi - lo) / 2;

        var guessResult = game.Guess(lo);
        result.TryTimes++;
        if (guessResult == GuessResult.Equal)
        {
            result.SecretNumber = lo;
            return result;
        }

        guessResult = game.Guess(hi);
        result.TryTimes++;
        if (guessResult == GuessResult.Equal)
        {
            result.SecretNumber = hi;
            return result;
        }
        else if (guessResult == GuessResult.Hot)
        {
            lo = mid;
        }
        else
        {
            hi = mid;
        }
    }

    return result;
}

// 方案二，根据 (lastGuess + nowGuess)/2 = (lo + hi) / 2 确定每次猜测的值。
static TestResult PlayGameB(Game game)
{
    TestResult result;
    result.TryTimes = 0;
    result.SecretNumber = 0;

    var hi = game.N;
    var lo = 1;
    var isRightSide = true;

    // 第一次猜测
    var guessResult = game.Guess(1);
    result.TryTimes++;
    if (guessResult == GuessResult.Equal)
    {
        result.SecretNumber = 1;
        return result;
    }

    while (lo < hi)
    {
        var mid = lo + (hi - lo) / 2;
        var nowGuess = (lo + hi) - game.LastGuess;

        guessResult = game.Guess(nowGuess);
        result.TryTimes++;
        if (guessResult == GuessResult.Equal)
        {
            result.SecretNumber = nowGuess;
            break;
        }
        else if (guessResult == GuessResult.Hot)
        {
            if (isRightSide)
            {
                lo = mid;
            }
            else
            {
                hi = mid;
            }
        }
        else
        {
            if (isRightSide)
            {
                hi = mid;
            }
            else
            {
                lo = mid;
            }
        }

        isRightSide = !isRightSide;
        if (hi - lo <= 1)
        {
            break;
        }
    }

    if (game.Guess(lo) == GuessResult.Equal)
    {
        result.TryTimes++;
        result.SecretNumber = lo;
    }
    else if (game.Guess(hi) == GuessResult.Equal)
    {
        result.TryTimes++;
        result.SecretNumber = hi;
    }

    return result;
}

/// <summary>
/// 某种方案的测试结果，包含猜测结果和尝试次数。
/// </summary>
struct TestResult
{
    public int SecretNumber; // 猜测到的数字。
    public int TryTimes; // 尝试次数。
}