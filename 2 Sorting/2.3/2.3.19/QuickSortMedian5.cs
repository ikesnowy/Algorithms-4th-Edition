using System;
using System.Diagnostics;
using Quick;

namespace _2._3._19
{
    /// <summary>
    /// 五取样快速排序
    /// </summary>
    public class QuickSortMedian5 : BaseSort
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

            // 少于五个元素的数组直接进行插入排序
            if (hi - lo + 1 < 5)
            {
                var n = hi - lo + 1;
                for (var i = lo; i - lo < n; i++)
                {
                    for (var k = i; k > 0 && Less(a[k], a[k - 1]); --k)
                    {
                        Exch(a, k, k - 1);
                    }
                }

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

            // 假设为 a b c d e 五个数字
            // 首先对 b c 排序
            if (Less(a[lo + 2], a[lo + 1]))
                Exch(a, lo + 2, lo + 1);
            // 然后再排序 d e
            if (Less(a[lo + 4], a[lo + 3]))
                Exch(a, lo + 4, lo + 3);

            // 这时满足 b < c, d < e
            // 比较 b d，把较小的一组放到 b c 的位置上去
            if (Less(a[lo + 3], a[lo + 1]))
            {
                Exch(a, lo + 1, lo + 3);
                Exch(a, lo + 2, lo + 4);
            }

            // 这时满足 b < c, b < d < e，即 b 是 b c d e 中的最小值
            // 交换 a 和 b
            Exch(a, lo, lo + 1);

            // 重新排序 b c
            if (Less(a[lo + 2], a[lo + 1]))
                Exch(a, lo + 2, lo + 1);

            // 这时再次满足 b < c, d < e
            // 比较 b d，把最小的一组放到 b c 的位置上去
            if (Less(a[lo + 3], a[lo + 1]))
            {
                Exch(a, lo + 1, lo + 3);
                Exch(a, lo + 2, lo + 4);
            }

            // 这时 a 和 b 为五个数中的最小值和次小值（顺序不固定，a 也可以是次小值）
            // 最后比较 c 和 d，较小的那一个即为中位数（即第三小的数）
            if (Less(a[lo + 3], a[lo + 2]))
                Exch(a, lo + 3, lo + 2);

            // 此时 c 即为中位数
            Exch(a, lo, lo + 2);

            // d e 放到数组末尾充当哨兵
            Exch(a, lo + 3, hi);
            Exch(a, lo + 4, hi - 1);
            
            // 调整指针位置，前两位和后两位都已经在合适位置了
            j -= 2;
            i += 2;
            
            var v = a[lo];
            while (true)
            {
                while (Less(a[++i], v)) ;
                while (Less(v, a[--j])) ;
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
