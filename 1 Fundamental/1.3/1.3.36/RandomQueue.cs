using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._36
{
    /// <summary>
    /// 随机队列。
    /// </summary>
    /// <typeparam name="Item">队列中要保存的元素。</typeparam>
    public class RandomQueue<Item> : IEnumerable<Item>
    {
        private Item[] queue;
        private int count;

        /// <summary>
        /// 新建一个随机队列。
        /// </summary>
        public RandomQueue()
        {
            queue = new Item[2];
            count = 0;
        }

        /// <summary>
        /// 判断队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 为队列重新分配内存空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException();
            }

            var temp = new Item[capacity];
            for (var i = 0; i < count; i++)
            {
                temp[i] = queue[i];
            }

            queue = temp;
        }

        /// <summary>
        /// 向队列中添加一个元素。
        /// </summary>
        /// <param name="item">要向队列中添加的元素。</param>
        public void Enqueue(Item item)
        {
            if (queue.Length == count)
            {
                Resize(count * 2);
            }

            queue[count] = item;
            count++;
        }

        /// <summary>
        /// 从队列中随机删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var random = new Random(DateTime.Now.Millisecond);
            var index = random.Next(count);

            var temp = queue[index];
            queue[index] = queue[count - 1];
            queue[count - 1] = temp;

            count--;

            if (count < queue.Length / 4)
            {
                Resize(queue.Length / 2);
            }

            return temp;
        }

        /// <summary>
        /// 随机返回一个队列中的元素。
        /// </summary>
        /// <returns></returns>
        public Item Sample()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var random = new Random();
            var index = random.Next(count);

            return queue[index];
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new RandomQueueEnumerator(queue, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class RandomQueueEnumerator : IEnumerator<Item>
        {
            private int current;
            private readonly int count;
            private Item[] queue;
            private int[] sequence;

            public RandomQueueEnumerator(Item[] queue, int count)
            {
                this.count = count;
                this.queue = queue;
                current = -1;

                sequence = new int[this.count];
                for (var i = 0; i < this.count; i++)
                {
                    sequence[i] = i;
                }

                Shuffle(sequence, DateTime.Now.Millisecond);
            }

            /// <summary>
            /// 随机打乱数组。
            /// </summary>
            /// <param name="a">需要打乱的数组。</param>
            /// <param name="seed">随机种子值。</param>
            private void Shuffle(int[] a, int seed)
            {
                var N = a.Length;
                var random = new Random(seed);
                for (var i = 0; i < N; i++)
                {
                    var r = i + random.Next(N - i);
                    var temp = a[i];
                    a[i] = a[r];
                    a[r] = temp;
                }
            }

            Item IEnumerator<Item>.Current => queue[sequence[current]];

            object IEnumerator.Current => queue[sequence[current]];

            void IDisposable.Dispose()
            {
                current = -1;
                sequence = null;
                queue = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (current == count - 1)
                    return false;
                current++;
                return true;
            }

            void IEnumerator.Reset()
            {
                current = -1;
            }
        }
    }
}
