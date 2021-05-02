using System;
using System.Diagnostics;
// ReSharper disable CognitiveComplexity

namespace SortApplication
{
    /// <summary>
    /// 取样排序类。
    /// </summary>
    public class SampleSort : QuickSort
    {
        /// <summary>
        /// 取样数组长度 2^k - 1 的阶数。
        /// </summary>
        /// <value>取样数组长度的阶数。</value>
        public int K { get; set; }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public SampleSort()
        {
            K = 8;
        }

        /// <summary>
        /// 用快速排序对数组 a 进行升序排序。
        /// </summary>
        /// <typeparam name="T">需要排序的类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            if (a.Length < Math.Pow(2, K + 1))
            {
                // 小于 2^(k+1) 的数组直接进行快排
                base.Sort(a);
                return;
            }

            Shuffle(a);
            var samplehi = (int)Math.Pow(2, K) - 2;
            // 利用快速排序对取样数组进行排序
            base.Sort(a, 0, samplehi);
            // 找到取样数组的中位数
            var sampleMedian = samplehi / 2;
            // 将取样数组后半部分放到数组末尾
            int i = samplehi, j = a.Length - 1;
            while (i != sampleMedian)
                Exch(a, i--, j--);
            // 根据取样数组进行排序
            Sort(a, 0, sampleMedian, j, a.Length - 1);
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 用快速排序对数组 a 的 lo ~ hi 范围排序。
        /// </summary>
        /// <typeparam name="T">需要排序的数组类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="samplelo">取样数组的起始下标。</param>
        /// <param name="lo">排序范围的起始下标。</param>
        /// <param name="hi">排序范围的结束下标。</param>
        /// <param name="samplehi">取样数组的终止下标。</param>
        private void Sort<T>(T[] a, int samplelo, int lo, int hi, int samplehi) where T : IComparable<T>
        {
            if (hi <= lo)                   // 别越界
                return;

            var j = Partition(a, lo, hi);
            // 将前部的有序取样数组取半，后半部分放在枢轴前面。
            if (lo - samplelo > 1)
            {
                // p 应该始终指向有序部分的最后一项
                // v 应该始终指向有序部分的前面一项
                int p = lo - 1, v = j - 1;
                for (var i = 0; i < (lo - samplelo) / 2; i++)
                {
                    Exch(a, p--, v--);
                }
                Sort(a, samplelo, p, v, j - 1);
            }
            else
            {
                // 取样数组已经用完，退化为普通 Quicksort
                base.Sort(a, samplelo, j - 1);
            }

            // 将尾部有序取样数组取半，前半部分放在枢轴后面。
            if (samplehi - hi > 1)
            {
                // p 应该始终指向有序部分的前面一项
                // v 应该始终指向有序部分的最后一项
                int p = hi, v = j;
                for (var i = 0; i < (samplehi - hi) / 2; i++)
                {
                    Exch(a, ++p, ++v);
                }
                Sort(a, j + 1, v, p, samplehi);
            }
            else
            {
                // 取样数组已用完，退化为普通 Quicksort
                base.Sort(a, j + 1, samplehi);
            }
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
                while (Less(a[++i], v))
                    if (i == hi)
                        break;
                while (Less(v, a[--j]))
                    if (j == lo)
                        break;
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
