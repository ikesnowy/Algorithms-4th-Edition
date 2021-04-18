using System;
using System.Diagnostics;
using Quick;

namespace _2._3._17
{
    /// <summary>
    /// 快速排序类。
    /// </summary>
    public class QuickSortX : BaseSort
    {
        /// <summary>
        /// 用快速排序对数组 a 进行升序排序。
        /// </summary>
        /// <typeparam name="T">需要排序的类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            Shuffle(a);

            // 把最大元素放到最后一位
            var maxIndex = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (Less(a[maxIndex], a[i]))
                    maxIndex = i;
            }
            Exch(a, maxIndex, a.Length - 1);

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
            var v = a[lo];
            while (true)
            {
                while (Less(a[++i], v)) ;
             //     if (i == hi)
             //         break;
                while (Less(v, a[--j])) ;
             //     if (j == lo)
             //         break;
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
