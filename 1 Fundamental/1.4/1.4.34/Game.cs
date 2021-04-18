using System;

namespace _1._4._34
{
    /// <summary>
    /// 某次猜测的结果。
    /// </summary>
    enum GuessResult
    {
        Hot = 1,        // 比上次猜测更接近目标。
        Equal = 0,      // 猜中目标。
        Cold = -1,      // 比上次猜测更远离目标。
        FirstGuess = -2 // 第一次猜测。
    }

    /// <summary>
    /// 游戏类。
    /// </summary>
    class Game
    {
        public int N { get; }                       // 目标值的最大范围。
        public int SecretNumber { get; }            // 目标值。
        public int LastGuess { get; private set; }  // 上次猜测的值

        /// <summary>
        /// 构造函数，新开一局游戏。
        /// </summary>
        /// <param name="n">目标值的最大范围。</param>
        public Game(int n)
        {
            var random = new Random();
            this.N = n;
            SecretNumber = random.Next(n - 1) + 1;
            LastGuess = -1;
        }

        /// <summary>
        /// 猜测，根据与上次相比更为接近还是远离目标值返回结果。
        /// </summary>
        /// <param name="guess">本次的猜测值</param>
        /// <returns>接近或不变返回 Hot，远离则返回 Cold，猜中返回 Equal。</returns>
        public GuessResult Guess(int guess)
        {
            if (guess == SecretNumber)
            {
                return GuessResult.Equal;
            }
            if (LastGuess == -1)
            {
                LastGuess = guess;
                return GuessResult.FirstGuess;
            }

            var lastDiff = Math.Abs(LastGuess - SecretNumber);
            LastGuess = guess;
            var nowDiff = Math.Abs(guess - SecretNumber);
            if (nowDiff > lastDiff)
            {
                return GuessResult.Cold;
            }
            else
            {
                return GuessResult.Hot;
            }
        }

        /// <summary>
        /// 重置游戏，清空上次猜测的记录。目标值和最大值都不变。
        /// </summary>
        public void Restart()
        {
            LastGuess = -1;
        }
    }
}
