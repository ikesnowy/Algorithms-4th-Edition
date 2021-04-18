using System;
using Merge;

namespace _2._2._20
{
    /// <summary>
    /// 归并排序类。
    /// </summary>
    public class MergeSort : BaseSort
    {
        /// <summary>
        /// 利用归并排序将数组按升序排序。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">待排序的数组。</param>
        public int[] IndexSort<T>(T[] a) where T : IComparable<T>
        {
            var aux = new int[a.Length];
            var index = new int[a.Length];
            for (var i = 0; i < a.Length; i++)
            {
                index[i] = i;
            }
            Sort(a, index, aux, 0, a.Length - 1);
            return index;
        }

        /// <summary>
        /// 自顶向下地对数组指定范围内进行归并排序，需要辅助数组。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="a">原数组。</param>
        /// <param name="aux">辅助数组。</param>
        /// <param name="lo">排序范围起点。</param>
        /// <param name="hi">排序范围终点。</param>
        private void Sort<T>(T[] a, int[] index, int[] aux, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo)
                return;
            var mid = lo + (hi - lo) / 2;
            Sort(a, index, aux, lo, mid);
            Sort(a, index, aux, mid + 1, hi);
            Merge(a, index, aux, lo, mid, hi);
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
        private void Merge<T>(T[] a, int[] index, int[] aux, int lo, int mid, int hi) where T : IComparable<T>
        {
            for (var k = lo; k <= hi; k++)
            {
                aux[k] = index[k];
            }

            int i = lo, j = mid + 1;
            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    index[k] = aux[j];
                    j++;
                }
                else if (j > hi)
                {
                    index[k] = aux[i];
                    i++;
                }
                else if (Less(a[aux[j]], a[aux[i]]))
                {
                    index[k] = aux[j];
                    j++;
                }
                else
                {
                    index[k] = aux[i];
                    i++;
                }
            }
        }

        public override void Sort<T>(T[] a)
        {
            throw new NotImplementedException();
        }
    }
}
