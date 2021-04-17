/* 证明：
 * 
 * 已知： a, b 皆为正整数，且 a > b。g 是 a、b 的最大公约数
 * 设 r0 = a % b, rk = rk-2 % rk-1
 * 那么有 gcd(a, b) = gcd(b, r0) = gcd(r0, r1)... = gcd(rn-1, rn)
 * 且 rn = 0 （此时算法终止）
 * 
 * 由于 rn-2 = qn * rn - 1 + rn = qn * rn-1 （qn = [rn-2 / rn-1] []代表向下取整)
 * 可得 rn-2 能被 rn-1 整除
 * 则 
 * rn-3 = qn-1 * rn-2 + rn-1 
 * = qn-1 * (qn * rn-1) + rn-1 （代入 rn-2 = qn * rn-1）
 * = qn-1 * qn * rn-1 + rn-1
 * = (qn-1 * qn + 1) * rn-1
 * 可得 rn-3 也能被 rn-1 整除
 * 以此类推，rn-1 可以整除 a 和 b，即 rn-1 是 a 和 b 的公约数
 * 则 rn-1 <= g
 * 
 * 因为 g 是 a、b 的最大公约数，由性质可得：
 * a = mg, b = ng （m、n 是自然数）
 * 
 * r0 
 * = a % b 
 * = a - q0 * b （q0 = [a / b] []代表向下取整）
 * = mg - q0 * ng （代入 17 行的结论）
 * = (m - q0 * n)g
 * 
 * 可得 r0 能被 g 整除
 * 同理 r1, r2, r3, ..., rn-1 都可以被 g 整除
 * 因此 g <= rn-1
 * 
 * 综合 17 行和 30 行的结论可得 rn-1 = g
 * 
 * 证明完毕
 * 
 */

// ReSharper disable UnusedLocalFunction
static int Gcd(int p, int q)
{
    if (q == 0)
    {
        return p;
    }

    var r = p % q;

    return Gcd(q, r);
}