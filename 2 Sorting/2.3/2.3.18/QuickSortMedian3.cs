using System;
using System.Diagnostics;
using Quick;
// ReSharper disable CognitiveComplexity

namespace _2._3._18
{
    /// <summary>
    /// 三取样快速排序
    /// </summary>
    public class QuickSortMedian3 : BaseSort
    {
        /// <summary>
        /// 用快速排序对数组 a 进行升序排序。
        /// </summary>
        /// <typeparam name="T">需要排序的类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            Shuffle(a);
            Sort(a, 0, a.Length - 1);
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 用快速排序对数组 a 的 lo ~ hi 范围排序。
        /// </summary>
        /// <typeparam name="T">需要排序的数组类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="lo">排序范围的起始下标。</param>
        /// <param name="hi">排序范围的结束下标。</param>
        private void Sort<T>(T[] a, int lo, int hi) where T: IComparable<T>
        {
            if (hi <= lo)                   // 别越界
                return;

            // 只有两个元素的数组直接排序
            if (hi == lo + 1)
            {
                if (Less(a[hi], a[lo]))
                    Exch(a, lo, hi);

                return;
            }

            var j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        /// <summary>
        /// 对数组进行切分，返回枢轴位置。
        /// </summary>
        /// <typeparam name="T">需要切分的数组类型。</typeparam>
        /// <param name="a">需要切分的数组。</param>
        /// <param name="lo">切分的起始点。</param>
        /// <param name="hi">切分的末尾点。</param>
        /// <returns>枢轴下标。</returns>
        private int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            int i = lo, j = hi + 1;
            
            if (Less(a[lo + 1], a[lo]))
                Exch(a, lo + 1, lo);
            if (Less(a[lo + 2], a[lo]))
                Exch(a, lo + 2, lo);
            if (Less(a[lo + 2], a[lo + 1]))
                Exch(a, lo + 1, lo + 2);

            Exch(a, lo, lo + 1);        // 中位数放最左侧
            Exch(a, hi, lo + 2);        // 较大的值放最右侧作为哨兵

            var v = a[lo];
            while (true)
            {
                while (Less(a[++i], v))
                {
                }

                while (Less(v, a[--j]))
                {
                }

                if (i >= j)
                    break;
                Exch(a, i, j);
            }
            Exch(a, lo, j);
            return j;
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <typeparam name="T">需要打乱的数组类型。</typeparam>
        /// <param name="a">需要打乱的数组。</param>
        private void Shuffle<T>(T[] a)
        {
            var random = new Random();
            for (var i = 0; i < a.Length; i++)
            {
                var r = i + random.Next(a.Length - i);
                var temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}
