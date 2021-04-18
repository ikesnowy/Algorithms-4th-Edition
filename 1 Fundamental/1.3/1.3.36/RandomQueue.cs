using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._36
{
    /// <summary>
    /// 随机队列。
    /// </summary>
    /// <typeparam name="Item">队列中要保存的元素。</typeparam>
    public class RandomQueue<TItem> : IEnumerable<TItem>
    {
        private TItem[] _queue;
        private int _count;

        /// <summary>
        /// 新建一个随机队列。
        /// </summary>
        public RandomQueue()
        {
            _queue = new TItem[2];
            _count = 0;
        }

        /// <summary>
        /// 判断队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _count == 0;
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

            var temp = new TItem[capacity];
            for (var i = 0; i < _count; i++)
            {
                temp[i] = _queue[i];
            }

            _queue = temp;
        }

        /// <summary>
        /// 向队列中添加一个元素。
        /// </summary>
        /// <param name="item">要向队列中添加的元素。</param>
        public void Enqueue(TItem item)
        {
            if (_queue.Length == _count)
            {
                Resize(_count * 2);
            }

            _queue[_count] = item;
            _count++;
        }

        /// <summary>
        /// 从队列中随机删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var random = new Random(DateTime.Now.Millisecond);
            var index = random.Next(_count);

            var temp = _queue[index];
            _queue[index] = _queue[_count - 1];
            _queue[_count - 1] = temp;

            _count--;

            if (_count < _queue.Length / 4)
            {
                Resize(_queue.Length / 2);
            }

            return temp;
        }

        /// <summary>
        /// 随机返回一个队列中的元素。
        /// </summary>
        /// <returns></returns>
        public TItem Sample()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var random = new Random();
            var index = random.Next(_count);

            return _queue[index];
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new RandomQueueEnumerator(_queue, _count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class RandomQueueEnumerator : IEnumerator<TItem>
        {
            private int _current;
            private readonly int _count;
            private TItem[] _queue;
            private int[] _sequence;

            public RandomQueueEnumerator(TItem[] queue, int count)
            {
                this._count = count;
                this._queue = queue;
                _current = -1;

                _sequence = new int[this._count];
                for (var i = 0; i < this._count; i++)
                {
                    _sequence[i] = i;
                }

                Shuffle(_sequence, DateTime.Now.Millisecond);
            }

            /// <summary>
            /// 随机打乱数组。
            /// </summary>
            /// <param name="a">需要打乱的数组。</param>
            /// <param name="seed">随机种子值。</param>
            private void Shuffle(int[] a, int seed)
            {
                var n = a.Length;
                var random = new Random(seed);
                for (var i = 0; i < n; i++)
                {
                    var r = i + random.Next(n - i);
                    var temp = a[i];
                    a[i] = a[r];
                    a[r] = temp;
                }
            }

            TItem IEnumerator<TItem>.Current => _queue[_sequence[_current]];

            object IEnumerator.Current => _queue[_sequence[_current]];

            void IDisposable.Dispose()
            {
                _current = -1;
                _sequence = null;
                _queue = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (_current == _count - 1)
                    return false;
                _current++;
                return true;
            }

            void IEnumerator.Reset()
            {
                _current = -1;
            }
        }
    }
}
