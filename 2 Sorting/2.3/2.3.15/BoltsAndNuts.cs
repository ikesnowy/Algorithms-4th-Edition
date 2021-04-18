using System;

namespace _2._3._15
{
    /// <summary>
    /// 螺母类。
    /// </summary>
    public class Nut<T> : IComparable<Bolt<T>> where T : IComparable<T>
    {
        /// <summary>
        /// 螺母的值。
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 螺母的构造函数。
        /// </summary>
        /// <param name="value">螺母的值。</param>
        public Nut(T value) => Value = value;

        /// <summary>
        /// 比较方法，螺母只能和螺丝比较。
        /// </summary>
        /// <param name="other">需要比较的螺丝。</param>
        /// <returns></returns>
        public int CompareTo(Bolt<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }

    /// <summary>
    /// 螺丝类。
    /// </summary>
    public class Bolt<T> : IComparable<Nut<T>> where T : IComparable<T>
    {
        /// <summary>
        /// 螺丝的值。
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 螺丝的默认构造函数。
        /// </summary>
        /// <param name="value">螺丝的值。</param>
        public Bolt(T value) => Value = value;

        /// <summary>
        /// 比较方法，螺丝只能和螺母比较。
        /// </summary>
        /// <param name="other">需要比较的螺母。</param>
        /// <returns></returns>
        public int CompareTo(Nut<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }

    /// <summary>
    /// 用快排的方式解决螺母和螺帽的问题。
    /// </summary>
    public class BoltsAndNuts
    {
        private readonly Random random = new();

        /// <summary>
        /// 对螺丝和螺母排序。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="bolts">螺母数组。</param>
        /// <param name="nuts">螺丝数组。</param>
        public void Sort<T>(Bolt<T>[] bolts, Nut<T>[] nuts) where T : IComparable<T>
        {
            if (bolts.Length != nuts.Length)
                throw new ArgumentException("数组长度必须一致");

            Shuffle(bolts);
            Shuffle(nuts);
            Sort(bolts, nuts, 0, bolts.Length - 1);
        }

        /// <summary>
        /// 对螺丝和螺母排序。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="bolts">螺母数组。</param>
        /// <param name="nuts">螺丝数组。</param>
        /// <param name="lo">起始下标。</param>
        /// <param name="hi">终止下标。</param>
        public void Sort<T>(Bolt<T>[] bolts, Nut<T>[] nuts, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo)
                return;
            var j = Partition(bolts, nuts, lo, hi);
            Sort(bolts, nuts, lo, j - 1);
            Sort(bolts, nuts, j + 1, hi);
        }

        /// <summary>
        /// 对数组进行切分。
        /// </summary>
        /// <typeparam name="T">需要排序的数组类型。</typeparam>
        /// <param name="bolts">螺母数组。</param>
        /// <param name="nuts">螺丝数组。</param>
        /// <param name="lo">起始下标。</param>
        /// <param name="hi">终止下标。</param>
        /// <returns>切分位置。</returns>
        private int Partition<T>(Bolt<T>[] bolts, Nut<T>[] nuts, int lo, int hi) where T : IComparable<T>
        {
            int i = lo, j = hi + 1;
            var pivotB = bolts[lo];
            // 找到对应螺丝
            for (var k = lo; k <= hi; k++)
            {
                if (nuts[k].CompareTo(pivotB) == 0)
                {
                    Exch(nuts, k, lo);
                    break;
                }
            }
            // 先用螺母去套螺丝
            while (true)
            {
                while (nuts[++i].CompareTo(pivotB) < 0)
                    if (i == hi)
                        break;
                while (pivotB.CompareTo(nuts[--j]) < 0)
                    if (j == lo)
                        break;

                if (i >= j)
                    break;
                Exch(nuts, i, j);
            }
            Exch(nuts, lo, j);

            // 再用螺丝去比较螺母
            var pivotN = nuts[j];
            i = lo;
            j = hi + 1;
            while (true)
            {
                while (bolts[++i].CompareTo(pivotN) < 0)
                    if (i == hi)
                        break;
                while (pivotN.CompareTo(bolts[--j]) < 0)
                    if (j == lo)
                        break;

                if (i >= j)
                    break;

                Exch(bolts, i, j);
            }
            Exch(bolts, lo, j);

            return j;
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <typeparam name="T">需要打乱的数组类型。</typeparam>
        /// <param name="a">需要打乱的数组。</param>
        private void Shuffle<T>(T[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                var r = i + random.Next(a.Length - i);
                var temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// 交换两个元素。
        /// </summary>
        /// <typeparam name="T">元素类型。</typeparam>
        /// <param name="a">需要交换的第一个元素。</param>
        /// <param name="b">需要交换的第二个元素。</param>
        private void Exch<T>(T[] a, int lo, int hi)
        {
            var t = a[lo];
            a[lo] = a[hi];
            a[hi] = t;
        }
    }
}
