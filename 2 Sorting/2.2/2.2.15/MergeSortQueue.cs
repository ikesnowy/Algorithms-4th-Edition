using System;

namespace _2._2._15
{
    /// <summary>
    /// 利用队列归并实现的自底向上的归并排序。
    /// </summary>
    class MergeSortQueue
    {
        /// <summary>
        /// 利用队列归并进行自底向上的归并排序。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="array">需要排序的数组。</param>
        public void Sort<T>(T[] array) where T : IComparable<T>
        {
            var queueList = new Queue<Queue<T>>();
            for (var i = 0; i < array.Length; i++)
            {
                var temp = new Queue<T>();
                temp.Enqueue(array[i]);
                queueList.Enqueue(temp);
            }

            while (queueList.Size() != 1)
            {
                var times = queueList.Size() / 2;
                for (var i = 0; i < times; i++)
                {
                    var a = queueList.Dequeue();
                    var b = queueList.Dequeue();
                    queueList.Enqueue(Merge(a, b));
                }
            }

            var result = queueList.Dequeue();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = result.Dequeue();
            }
        }

        /// <summary>
        /// 归并两个有序队列。输入队列将被清空。
        /// </summary>
        /// <typeparam name="T">有序队列的元素类型。</typeparam>
        /// <param name="a">需要归并的队列。</param>
        /// <param name="b">需要归并的队列。</param>
        /// <returns>归并后的新队列。</returns>
        public static Queue<T> Merge<T>(Queue<T> a, Queue<T> b) where T : IComparable<T>
        {
            var sortedQueue = new Queue<T>();
            while (!a.IsEmpty() && !b.IsEmpty())
            {
                if (a.Peek().CompareTo(b.Peek()) < 0)
                    sortedQueue.Enqueue(a.Dequeue());
                else
                    sortedQueue.Enqueue(b.Dequeue());
            }

            while (!a.IsEmpty())
                sortedQueue.Enqueue(a.Dequeue());
            while (!b.IsEmpty())
                sortedQueue.Enqueue(b.Dequeue());

            return sortedQueue;
        }
    }
}
