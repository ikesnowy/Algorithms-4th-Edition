using System;

namespace Merge
{
    /// <summary>
    /// 不稳定的归并排序。
    /// </summary>
    public class MergeSortUnstable : BaseSort
    {
        /// <summary>
        /// 利用归并排序将数组按升序排序。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">待排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            var aux = new T[a.Length];
            Sort(a, aux, 0, a.Length - 1);
        }

        /// <summary>
        /// 自顶向下地对数组指定范围内进行归并排序，需要辅助数组。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="a">原数组。</param>
        /// <param name="aux">辅助数组。</param>
        /// <param name="lo">排序范围起点。</param>
        /// <param name="hi">排序范围终点。</param>
        private void Sort<T>(T[] a, T[] aux, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo)
                return;
            var mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
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
            // 前半部分升序复制
            for (var k = lo; k <= mid; k++)
            {
                aux[k] = a[k];
            }
            // 后半部分降序复制
            for (var k = mid + 1; k <= hi; k++)
            {
                aux[k] = a[hi - k + mid + 1];
            }

            // i 指向最左端，j 指向最右端
            int i = lo, j = hi;
            for (var k = lo; k <= hi; k++)
            {
                if (Less(aux[j], aux[i]))
                    a[k] = aux[j--];
                else
                    a[k] = aux[i++];

            }
        }
    }
}
