using System;
// ReSharper disable CognitiveComplexity

namespace _2._2._18
{
    /// <summary>
    /// 分治法打乱链表。
    /// </summary>
    public class MergeShuffle
    {
        /// <summary>
        /// 利用分治法打乱链表。
        /// </summary>
        /// <typeparam name="T">链表元素类型。</typeparam>
        /// <param name="a">等待打乱的链表。</param>
        public void Shuffle<T>(LinkedList<T> a)
        {
            var blockLen = 1;
            var random = new Random();
            while (blockLen <= a.Size())
            {
                // 找到第一个块
                var lo = a.GetFirst();
                var mid = FindBlock(lo, blockLen);

                if (mid.Next == null)
                    break;

                while (mid.Next != null)
                {
                    var hi = FindBlock(mid.Next, blockLen);
                    Node<T>[] result;
                    if (lo == a.GetFirst())
                    {
                        result = Merge(lo, mid, hi, random);
                        a.SetFirst(result[0]);
                    }
                    else
                    {
                        result = Merge(lo.Next, mid, hi, random);
                        lo.Next = result[0];
                    }


                    // 跳到表尾
                    lo = result[1];

                    if (lo.Next != null)
                        mid = FindBlock(lo.Next, blockLen);
                    else
                        mid = lo;
                }
                blockLen *= 2;
            }
        }

        /// <summary>
        /// 将两个有序链表块随机归并，返回新的表头。
        /// </summary>
        /// <typeparam name="T">链表元素类型。</typeparam>
        /// <param name="lo">第一个块起点。</param>
        /// <param name="mid">第一个块终点（第二个块起点的前驱）。</param>
        /// <param name="hi">第二个块的终点。</param>
        /// <param name="random">随机数生成器。</param>
        /// <returns>新的表头。</returns>
        private Node<T>[] Merge<T>(Node<T> lo, Node<T> mid, Node<T> hi, Random random)
        {
            var after = hi.Next; // 要合并的两个块之后的元素
            var result = new Node<T>[2];
            var i = lo;          // 链表1
            var j = mid.Next;    // 链表2

            // 切割链表
            mid.Next = null;
            hi.Next = null;

            Node<T> current;
            // 决定新的表头
            if (random.NextDouble() >= 0.5)
            {
                current = i;
                i = i.Next;
            }
            else
            {
                current = j;
                j = j.Next;
            }

            var first = current;

            // 归并表
            while (i != null && j != null)
            {
                if (random.NextDouble() >= 0.5)
                {
                    current.Next = i;
                    i = i.Next;
                    current = current.Next;
                }
                else
                {
                    current.Next = j;
                    j = j.Next;
                    current = current.Next;
                }
            }

            if (i == null)
                current.Next = j;
            else
                current.Next = i;

            // 连接表尾（链表 1 的尾部或者链表 2 的尾部）
            if (mid.Next == null)
            {
                mid.Next = after;
                result[1] = mid;
            }
            else
            {
                hi.Next = after;
                result[1] = hi;
            }
            result[0] = first;
            
            return result;
        }

        /// <summary>
        /// 获取从指定位置开始定长的链表。
        /// </summary>
        /// <typeparam name="T">链表的元素类型。</typeparam>
        /// <param name="lo">链表的起始结点。</param>
        /// <param name="length">需要获取的链表长度。</param>
        /// <returns>结果链表的最后一个元素结点。</returns>
        private Node<T> FindBlock<T>(Node<T> lo, int length)
        {
            var hi = lo;
            for (var i = 0; i < length - 1 && hi.Next != null; i++)
            {
                hi = hi.Next;
            }
            
            return hi;
        }
    }
}
