using System;

namespace _1._2._16
{
    public class Rational
    {
        public long Numerator { get; }
        public long Denominator { get; }
        private readonly bool isNagative;

        /// <summary>
        /// 构造一个有理数对象，自动变为最简形式。
        /// </summary>
        /// <param name="numerator">分子。</param>
        /// <param name="denominator">分母。</param>
        /// <exception cref="ArgumentException">分母为 0 时抛出</exception>
        public Rational(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be 0");

            if (numerator < 0 && denominator < 0)
            {
                isNagative = false;
                numerator = -numerator;
                denominator = -denominator;
            }
            else if (numerator < 0 || denominator < 0)
            {
                isNagative = true;
            }
            else
            {
                isNagative = false;
            }

            var gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            if (gcd != 1)
            {
                numerator /= gcd;
                denominator /= gcd;
            }
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// 将两个有理数对象相加，返回一个有理数。
        /// </summary>
        /// <param name="b">加数。</param>
        /// <returns></returns>
        public Rational Plus(Rational b)
        {
            var result = new Rational(Numerator * b.Denominator + b.Numerator * Denominator, Denominator * b.Denominator);
            return result;
        }

        /// <summary>
        /// 以当前对象为被减数，减去一个有理数。
        /// </summary>
        /// <param name="b">减数。</param>
        /// <returns></returns>
        public Rational Minus(Rational b)
        {
            var result = new Rational(Numerator * b.Denominator - b.Numerator * Denominator, Denominator * b.Denominator);
            return result;
        }

        /// <summary>
        /// 将两个有理数对象相乘。
        /// </summary>
        /// <param name="b">乘数。</param>
        /// <returns></returns>
        public Rational Multiply(Rational b)
        {
            var result = new Rational(Numerator * b.Numerator, Denominator * b.Denominator);
            return result;
        }

        /// <summary>
        /// 以当前有理数为被除数，除以一个有理数。
        /// </summary>
        /// <param name="b">除数。</param>
        /// <returns></returns>
        public Rational Divide(Rational b)
        {
            var result = new Rational(Numerator * b.Denominator, Denominator * b.Numerator);
            return result;
        }

        /// <summary>
        /// 求两个正整数的最大公约数。
        /// </summary>
        /// <param name="a">第一个整数。</param>
        /// <param name="b">第二个整数。</param>
        /// <returns></returns>
        private long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (obj.GetType() != GetType())
                return false;

            var that = (Rational)obj;
            return (Numerator == that.Numerator) && (Denominator == that.Denominator);
        }

        public override int GetHashCode()
        {
            return 31 * Numerator.GetHashCode() + Denominator.GetHashCode();
        }

        /// <summary>
        /// 返回形如 “分子/分母” 的字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = "";
            if (isNagative)
                result += "-";
            result += Math.Abs(Numerator) + "/" + Math.Abs(Denominator);
            return result;
        }
    }
}
