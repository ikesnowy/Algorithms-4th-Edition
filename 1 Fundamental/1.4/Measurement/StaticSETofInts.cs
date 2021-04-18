using System;

namespace Measurement
{
    /// <summary>
    /// 有序数组，能够快速查找并自动维护其中的顺序。
    /// </summary>
    public class StaticSETofInts
    {
        private readonly int[] a;

        /// <summary>
        /// 用一个数组初始化有序数组。
        /// </summary>
        /// <param name="keys">源数组。</param>
        public StaticSETofInts(int[] keys)
        {
            a = new int[keys.Length];
            for (var i = 0; i < keys.Length; i++)
            {
                a[i] = keys[i];
            }
            Array.Sort(a);
        }

        /// <summary>
        /// 检查数组中是否存在指定元素。
        /// </summary>
        /// <param name="key">要查找的值。</param>
        /// <returns>存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(int key)
        {
            return Rank(key, 0, a.Length - 1) != -1;
        }

        /// <summary>
        /// 返回某个元素在数组中存在的数量。
        /// </summary>
        /// <param name="key">关键值。</param>
        /// <returns><paramref name="key"/> 在数组中存在的数量。</returns>
        public int HowMany(int key)
        {
            var hi = a.Length - 1;
            var lo = 0;
            
            return HowMany(key, lo, hi);
        }

        /// <summary>
        /// 返回某个元素在数组某个范围中存在的数量。
        /// </summary>
        /// <param name="key">关键值。</param>
        /// <param name="lo">查找起始下标。</param>
        /// <param name="hi">查找结束下标。</param>
        /// <returns><paramref name="key"/> 在数组中存在的数量。</returns>
        private int HowMany(int key, int lo, int hi)
        {
            var mid = Rank(key, lo, hi);
            if (mid == -1)
                return 0;
            else
            {
                return 1 + HowMany(key, lo, mid - 1) + HowMany(key, mid + 1, hi);
            }
        }

        /// <summary>
        /// 二分查找。
        /// </summary>
        /// <param name="key">关键值。</param>
        /// <param name="lo">查找的起始下标。</param>
        /// <param name="hi">查找的结束下标。</param>
        /// <returns>返回关键值的下标，如果不存在则返回 -1。</returns>
        public int Rank(int key, int lo, int hi)
        {
            while (lo <= hi)
            {
                var mid = (hi - lo) / 2 + lo;
                if (key < a[mid])
                    hi = mid - 1;
                else if (key > a[mid])
                    lo = mid + 1;
                else
                    return mid;
            }
            return -1;
        }
    }
}
