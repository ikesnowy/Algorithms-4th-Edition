using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._33
{
    /// <summary>
    /// 可自动扩容的双端队列。
    /// </summary>
    /// <typeparam name="Item">队列中要存放的元素。</typeparam>
    public class ResizingArrayDeque<Item> : IEnumerable<Item>
    {
        private Item[] deque;
        private int first;
        private int last;
        private int count;

        /// <summary>
        /// 默认构造函数，建立一个双向队列。
        /// </summary>
        public ResizingArrayDeque()
        {
            deque = new Item[2];
            first = 0;
            last = 0;
            count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 返回队列中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 为队列重新分配空间。
        /// </summary>
        /// <param name="capacity">需要重新分配的空间大小。</param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();

            var temp = new Item[capacity];
            for (var i = 0; i < count; i++)
            {
                temp[i] = deque[(first + i) % deque.Length];
            }
            deque = temp;
            first = 0;
            last = count;
        }


        /// <summary>
        /// 在队列左侧添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素</param>
        public void PushLeft(Item item)
        {
            if (count == deque.Length)
            {
                Resize(2 * count);
            }

            first--;
            if (first < 0)
            {
                first += deque.Length;
            }
            deque[first] = item;
            count++;
        }

        public void PushRight (Item item)
        {
            if (count == deque.Length)
            {
                Resize(2 * count);
            }

            deque[last] = item;
            last = (last + 1) % deque.Length;
            count++;
        }

        public Item PopRight()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            last--;
            if (last < 0)
            {
                last += deque.Length;
            }
            var temp = deque[last];
            count--;
            if (count > 0 && count == deque.Length / 4)
                Resize(deque.Length / 2);
            return temp;
        }

        public Item PopLeft()
        {
            if (IsEmpty())
                throw new ArgumentException();

            var temp = deque[first];
            first = (first + 1) % deque.Length;
            count--;
            if (count > 0 && count == deque.Length / 4)
            {
                Resize(deque.Length / 2);
            }
            return temp;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new ResizingDequeEnumerator(deque, first, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ResizingDequeEnumerator : IEnumerator<Item>
        {
            private Item[] deque;
            private int current;
            private readonly int first;
            private readonly int count;

            public ResizingDequeEnumerator(Item[] deque, int first, int count)
            {
                this.deque = deque;
                this.first = first;
                this.count = count;
                current = -1;
            }

            Item IEnumerator<Item>.Current => deque[(first + current) % deque.Length];

            object IEnumerator.Current => deque[(first + current) % deque.Length];

            void IDisposable.Dispose()
            {
                deque = null;
                current = -1;
            }

            bool IEnumerator.MoveNext()
            {
                if (current == count - 1)
                {
                    return false;
                }

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
