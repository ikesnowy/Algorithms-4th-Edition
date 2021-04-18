using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._5._18
{
    /// <summary>
    /// 随机背包。
    /// </summary>
    /// <typeparam name="Item">背包中要存放的元素。</typeparam>
    public class RandomBag<Item> : IEnumerable<Item>
    {
        private Item[] bag;
        private int count;

        /// <summary>
        /// 建立一个随机背包。
        /// </summary>
        public RandomBag()
        {
            bag = new Item[2];
            count = 0;
        }

        /// <summary>
        /// 检查背包是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 返回背包中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 向背包中添加一个元素。
        /// </summary>
        /// <param name="item">要向背包中添加的元素。</param>
        public void Add(Item item)
        {
            if (count == bag.Length)
            {
                Resize(count * 2);
            }

            bag[count] = item;
            count++;
        }

        /// <summary>
        /// 重新为背包分配内存空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();
            var temp = new Item[capacity];
            for (var i = 0; i < count; i++)
            {
                temp[i] = bag[i];
            }
            bag = temp;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new RandomBagEnumerator(bag, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class RandomBagEnumerator : IEnumerator<Item>
        {
            private Item[] bag;
            private int[] sequence;
            private int current;
            private readonly int count;

            public RandomBagEnumerator(Item[] bag, int count)
            {
                this.bag = bag;
                current = -1;
                this.count = count;
                sequence = new int[count];
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

            Item IEnumerator<Item>.Current => bag[sequence[current]];

            object IEnumerator.Current => bag[sequence[current]];

            void IDisposable.Dispose()
            {
                bag = null;
                sequence = null;
                current = -1;
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
