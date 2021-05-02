using System;
using System.Diagnostics;
// ReSharper disable CognitiveComplexity

namespace Merge
{
    /// <summary>
    /// 三向归并排序。
    /// </summary>
    public class MergeSortThreeWay : BaseSort
    {
        /// <summary>
        /// 利用三项归并排序将数组按升序排序。
        /// </summary>
        /// <typeparam name="T">数组中的元素类型。</typeparam>
        /// <param name="a">待排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            var aux = new T[a.Length];
            Sort(a, aux, 0, a.Length - 1);
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 自顶向下地对数组指定范围内进行三向归并排序，需要辅助数组。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="a">原数组。</param>
        /// <param name="aux">辅助数组。</param>
        /// <param name="lo">排序范围起点。</param>
        /// <param name="hi">排序范围终点。</param>
        private void Sort<T>(T[] a, T[] aux, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo)       // 小于或等于一个元素
                return;
            var lmid = lo + (hi - lo) / 3;
            var rmid = hi - (hi - lo) / 3;
            Sort(a, aux, lo, lmid);
            Sort(a, aux, lmid + 1, rmid);
            Sort(a, aux, rmid + 1, hi);
            Merge(a, aux, lo, lmid, rmid, hi);
        }

        /// <summary>
        /// 返回两个元素中较小的那个。
        /// </summary>
        /// <typeparam name="T">比较的元素类型。</typeparam>
        /// <param name="a">用于比较的元素。</param>
        /// <param name="b">用于比较的元素。</param>
        /// <returns>较小的元素。</returns>
        private T Min<T>(T a, T b) where T : IComparable<T>
        {
            if (Less(a, b))
                return a;
            return b;
        }

        /// <summary>
        /// 将指定范围内的元素归并。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">原数组。</param>
        /// <param name="aux">辅助数组。</param>
        /// <param name="lo">范围起点。</param>
        /// <param name="lmid">范围三分之一点。</param>
        /// <param name="rmid">范围三分之二点。</param>
        /// <param name="hi">范围终点。</param>
        private void Merge<T>(T[] a, T[] aux, int lo, int lmid, int rmid, int hi) where T : IComparable<T>
        {
            for (var l = lo; l <= hi; l++)
            {
                aux[l] = a[l];
            }

            int i = lo, j = lmid + 1, k = rmid + 1;
            for (var l = lo; l <= hi; l++)
            {
                var flag = 0;
                if (i > lmid)
                    flag += 1;
                if (j > rmid)
                    flag += 10;
                if (k > hi)
                    flag += 100;
                switch (flag)
                {
                    case 0:         // 三个数组都还没有取完
                        var min = Min(aux[i], Min(aux[j], aux[k]));
                        if (min.Equals(aux[i]))
                            a[l] = aux[i++];
                        else if (min.Equals(aux[j]))
                            a[l] = aux[j++];
                        else
                            a[l] = aux[k++];
                        break;
                    case 1:         // 只有第一个数组取完了
                        if (Less(aux[j], aux[k]))
                            a[l] = aux[j++];
                        else
                            a[l] = aux[k++];
                        break;
                    case 10:        // 只有第二个数组取完了
                        if (Less(aux[i], aux[k]))
                            a[l] = aux[i++];
                        else
                            a[l] = aux[k++];
                        break;
                    case 100:       // 只有第三个数组取完了
                        if (Less(aux[i], aux[j]))
                            a[l] = aux[i++];
                        else
                            a[l] = aux[j++];
                        break;
                    case 11:        // 第一、二个数组取完了
                        a[l] = aux[k++];
                        break;
                    case 101:       // 第一、三个数组取完了
                        a[l] = aux[j++];
                        break;
                    case 110:       // 第二、三个数组取完了
                        a[l] = aux[i++];
                        break;
                }
            }
        }
    }
}
