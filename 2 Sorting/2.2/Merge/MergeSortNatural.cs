using System;
using System.Diagnostics;

namespace Merge
{
    /// <summary>
    /// 自然的归并排序。
    /// </summary>
    public class MergeSortNatural : BaseSort
    {
        /// <summary>
        /// 利用自然的归并排序进行自底向上的排序。
        /// </summary>
        /// <typeparam name="T">用于排序的元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            var aux = new T[a.Length];

            while (true)
            {
                // 找到第一个块
                var lo = 0;
                var mid = FindBlock(lo, a) - 1;
                if (mid == a.Length - 1)
                    break;

                while (mid < a.Length - 1)
                {
                    var hi = FindBlock(mid + 1, a) + mid;
                    Merge(lo, mid, hi, a, aux);
                    lo = hi + 1;
                    mid = FindBlock(lo, a) + lo - 1;
                }
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 将两个块归并。
        /// </summary>
        /// <typeparam name="T">数组的元素类型。</typeparam>
        /// <param name="lo">第一个块的开始下标。</param>
        /// <param name="mid">第一个块的结束下标（第二个块的开始下标 - 1）。</param>
        /// <param name="hi">第二个块的结束下标。</param>
        /// <param name="a">需要归并的数组。</param>
        /// <param name="aux">辅助数组。</param>
        private void Merge<T>(int lo, int mid, int hi, T[] a, T[] aux) where T : IComparable<T>
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
                else if (Less(aux[j], aux[i]))
                {
                    a[k] = aux[j];
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
        /// 获取下一个有序块。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="lo">查找起点。</param>
        /// <param name="a">用于查找的数组。</param>
        /// <returns>块的大小。</returns>
        private int FindBlock<T>(int lo, T[] a) where T : IComparable<T>
        {
            var size = 1;
            for (var i = lo; i < a.Length - 1; i++)
            {
                if (Less(a[i], a[i + 1]) || a[i].Equals(a[i + 1]))
                    size++;
                else
                    break;
            }
            return size;
        }
    }
}
