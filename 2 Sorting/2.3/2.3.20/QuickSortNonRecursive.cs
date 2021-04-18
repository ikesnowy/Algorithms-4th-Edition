using System;
using System.Diagnostics;
using Quick;

namespace _2._3._20
{
    /// <summary>
    /// 快速排序类。
    /// </summary>
    public class QuickSortNonRecursive : BaseSort
    {
        /// <summary>
        /// 用快速排序对数组 a 进行升序排序。
        /// </summary>
        /// <typeparam name="T">需要排序的类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            Shuffle(a);
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(a.Length - 1);

            while (!stack.IsEmpty())
            {
                // 压入顺序是先 lo，再 hi，故弹出顺序是先 hi 再 lo
                var hi = stack.Pop();
                var lo = stack.Pop();

                if (hi <= lo)
                    continue;

                var j = Partition(a, lo, hi);

                // 让较大的子数组先入栈（先排序较小的子数组）
                if (j - lo > hi - j)
                {
                    stack.Push(lo);
                    stack.Push(j - 1);

                    stack.Push(j + 1);
                    stack.Push(hi);
                }
                else
                {
                    stack.Push(j + 1);
                    stack.Push(hi);

                    stack.Push(lo);
                    stack.Push(j - 1);
                }
            }
            Debug.Assert(IsSorted(a));
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
