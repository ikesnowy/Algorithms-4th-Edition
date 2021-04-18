using System;

namespace Merge
{
    /// <summary>
    /// 优化后的归并排序。
    /// </summary>
    public class MergeSortX : BaseSort
    {
        /// <summary>
        /// 对小于 CUTOFF 的数组使用插入排序。
        /// </summary>
        private static int _cutoff = 7;

        /// <summary>
        /// 设置启用插入排序的阈值，小于该阈值的数组将采用插入排序。
        /// </summary>
        /// <param name="cutoff">新的阈值。</param>
        public void SetCutOff(int cutoff) => _cutoff = cutoff;

        /// <summary>
        /// 将指定范围内的元素归并。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="src">原始数组。</param>
        /// <param name="dst">目标数组。</param>
        /// <param name="lo">范围起点。</param>
        /// <param name="mid">范围中点。</param>
        /// <param name="hi">范围终点。</param>
        private void Merge<T>(T[] src, T[] dst, int lo, int mid, int hi) where T : IComparable<T>
        {
            int i = lo, j = mid + 1;
            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                    dst[k] = src[j++];
                else if (j > hi)
                    dst[k] = src[i++];
                else if (Less(src[j], src[i]))
                    dst[k] = src[j++];
                else
                    dst[k] = src[i++];
            }
        }

        /// <summary>
        /// 自顶向下地对数组指定范围内进行归并排序，需要辅助数组。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="src">原数组。</param>
        /// <param name="dst">辅助数组。</param>
        /// <param name="lo">排序范围起点。</param>
        /// <param name="hi">排序范围终点。</param>
        private void Sort<T>(T[] src, T[] dst, int lo, int hi) where T : IComparable<T>
        {
            // 小于 CUTOFF 的数组调用插入排序
            if (hi <= lo + _cutoff)
            {
                var insertion = new InsertionSort();
                insertion.Sort(dst, lo, hi);
                return;
            }
            var mid = lo + (hi - lo) / 2;
            // 交换辅助数组和原数组
            Sort(dst, src, lo, mid);
            Sort(dst, src, mid + 1, hi);
            // 已排序的数组直接合并
            if (!Less(src[mid + 1], src[mid]))
            {
                Array.Copy(src, lo, dst, lo, hi - lo + 1);
                return;
            }
            Merge(src, dst, lo, mid, hi);
        }

        /// <summary>
        /// 利用优化后的归并排序对数组 a 排序。
        /// </summary>
        /// <typeparam name="T">数组中的元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            var aux = new T[a.Length];
            a.CopyTo(aux, 0);
            // aux 和 a 需要交换
            Sort(aux, a, 0, a.Length - 1);
        }
    }
}
