using System.Collections.Generic;
using System.Diagnostics;

namespace Sort
{
    /// <summary>
    /// 选择排序类。
    /// </summary>
    public class SelectionSort : BaseSort
    {
        /// <summary>
        /// 利用选择排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                var min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (Less(a[j], a[min]))
                        min = j;
                }
                Exch(a, i, min);
                Debug.Assert(IsSorted(a, 0, i));
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 利用选择排序将数组按排序。（使用指定比较器）
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="c">比较器。</param>
        public void Sort<T>(T[] a, IComparer<T> c)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                var min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (Less(a[j], a[min], c))
                        min = j;
                }
                Exch(a, i, min);
                Debug.Assert(IsSorted(a, 0, i, c));
            }
            Debug.Assert(IsSorted(a, c));
        }
    }
}
