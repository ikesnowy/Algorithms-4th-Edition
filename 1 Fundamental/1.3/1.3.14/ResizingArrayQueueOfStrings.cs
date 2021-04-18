using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._14
{
    /// <summary>
    /// 可变长度的队列。
    /// </summary>
    /// <typeparam name="Item">队列中要存放的元素。</typeparam>
    class ResizingArrayQueueOfStrings<Item> : IEnumerable<Item>
    {
        private Item[] q;
        private int count;
        private int first;
        private int last;

        public ResizingArrayQueueOfStrings()
        {
            q = new Item[2];
            count = 0;
            first = 0;

        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Size()
        {
            return count;
        }

        private void Resize(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("capacity should be above zero");
            var temp = new Item[capacity];
            for (var i = 0; i < count; i++)
            {
                temp[i] = q[(first + i) % q.Length];
            }

            q = temp;
            first = 0;
            last = count;
        }

        public void Enqueue(Item item)
        {
            if (count == q.Length)
            {
                Resize(count * 2);
            }

            q[last] = item;
            last++;
            if (last == q.Length)
                last = 0;
            count++;
        }

        public Item Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            var item = q[first];
            q[first] = default(Item);
            count--;
            first++;
            if (first == q.Length)
                first = 0;

            if (count > 0 && count <= q.Length / 4)
                Resize(q.Length / 2);
            return item;
        }

        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            return q[first];
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new QueueEnumerator(q, first, last);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<Item>
        {
            int current;
            readonly int first;
            readonly int last;
            readonly Item[] q;

            public QueueEnumerator(Item[] q, int first, int last)
            {
                current = first - 1;
                this.first = first;
                this.last = last;
                this.q = q;
            }

            Item IEnumerator<Item>.Current => q[current];

            object IEnumerator.Current => q[current];

            void IDisposable.Dispose()
            {
                
            }

            bool IEnumerator.MoveNext()
            {
                if (current == last - 1)
                    return false;
                current++;
                return true;
            }

            void IEnumerator.Reset()
            {
                current = first - 1;
            }
        }
    }
}
