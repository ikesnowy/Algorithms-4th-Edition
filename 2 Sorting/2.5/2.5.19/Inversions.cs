using System;
using System.Collections.Generic;

namespace _2._5._19
{
    /// <summary>
    /// 归并排序类。
    /// </summary>
    public class Inversions
    {
        public int Counter;

        /// <summary>
        /// 利用归并排序计算逆序对的数量。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">待排序的数组。</param>
        public void Count<T>(T[] a) where T : IComparable<T>
        {
            Counter = 0;
            var aux = new T[a.Length];
            Count(a, aux, 0, a.Length - 1);
        }

        /// <summary>
        /// 自顶向下地对数组指定范围内进行归并排序并计算逆序对的数量，需要辅助数组。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="a">原数组。</param>
        /// <param name="aux">辅助数组。</param>
        /// <param name="lo">排序范围起点。</param>
        /// <param name="hi">排序范围终点。</param>
        private void Count<T>(T[] a, T[] aux, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo)
                return;
            var mid = lo + (hi - lo) / 2;
            Count(a, aux, lo, mid);
            Count(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }

        /// <summary>
        /// 将指定范围内的元素归并。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">原数组。</param>
        /// <param name="aux">辅助数组。</param>
        /// <param name="lo">范围起点。</param>
        /// <param name="mid">范围中点。</param>
        /// <param name="hi">范围终点。</param>
        private void Merge<T>(T[] a, T[] aux, int lo, int mid, int hi) where T : IComparable<T>
        {
            for (var k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            int i = lo, j = mid + 1;
            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j];
                    j++;
                }
                else if (j > hi)
                {
                    a[k] = aux[i];
                    i++;
                }
                else if (Less(aux[j], aux[i]))      // 右侧的小于左侧的，出现逆序
                {
                    a[k] = aux[j];
                    Counter += mid - i + 1;    // 统计逆序对数
                    j++;
                }
                else
                {
                    a[k] = aux[i];
                    i++;
                }
            }
        }

        /// <summary>
        /// 比较第一个参数是否小于第二个参数。
        /// </summary>
        /// <param name="v">第一个参数。</param>
        /// <param name="w">第二个参数。</param>
        /// <returns>如果第一个参数小于第二个参数则返回 true，
        /// 否则返回 false。</returns>
        protected bool Less<T>(T v, T w) where T : IComparable<T>
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// 使用指定的比较器比较第一个参数是否小于第二个参数。
        /// </summary>
        /// <typeparam name="T">比较的元素类型。</typeparam>
        /// <param name="v">比较的第一个元素。</param>
        /// <param name="w">比较的第二个元素</param>
        /// <param name="c">比较器。</param>
        /// <returns></returns>
        protected bool Less<T>(T v, T w, IComparer<T> c)
        {
            return c.Compare(v, w) < 0;
        }

        /// <summary>
        /// 交换数组中下标为 i, j 的两个元素。
        /// </summary>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <param name="a">元素所在的数组。</param>
        /// <param name="i">需要交换的第一个元素。</param>
        /// <param name="j">需要交换的第二个元素。</param>
        protected void Exch<T>(T[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
