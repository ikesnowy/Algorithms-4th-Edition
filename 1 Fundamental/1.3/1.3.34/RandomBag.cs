using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._34
{
    /// <summary>
    /// 随即背包。
    /// </summary>
    /// <typeparam name="TItem">背包中要存放的元素。</typeparam>
    public class RandomBag<TItem> : IEnumerable<TItem>
    {
        private TItem[] _bag;
        private int _count;

        /// <summary>
        /// 建立一个随机背包。
        /// </summary>
        public RandomBag()
        {
            _bag = new TItem[2];
            _count = 0;
        }

        /// <summary>
        /// 检查背包是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// 返回背包中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>
        /// 向背包中添加一个元素。
        /// </summary>
        /// <param name="item">要向背包中添加的元素。</param>
        public void Add(TItem item)
        {
            if (_count == _bag.Length)
            {
                Resize(_count * 2);
            }

            _bag[_count] = item;
            _count++;
        }

        /// <summary>
        /// 重新为背包分配内存空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();
            var temp = new TItem[capacity];
            for (var i = 0; i < _count; i++)
            {
                temp[i] = _bag[i];
            }
            _bag = temp;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new RandomBagEnumerator(_bag, _count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class RandomBagEnumerator : IEnumerator<TItem>
        {
            private TItem[] _bag;
            private int[] _sequence;
            private int _current;
            private readonly int _count;

            public RandomBagEnumerator(TItem[] bag, int count)
            {
                _bag = bag;
                _current = -1;
                _count = count;
                _sequence = new int[count];
                for (var i = 0; i < _count; i++)
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

            TItem IEnumerator<TItem>.Current => _bag[_sequence[_current]];

            object IEnumerator.Current => _bag[_sequence[_current]];

            void IDisposable.Dispose()
            {
                _bag = null;
                _sequence = null;
                _current = -1;
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
