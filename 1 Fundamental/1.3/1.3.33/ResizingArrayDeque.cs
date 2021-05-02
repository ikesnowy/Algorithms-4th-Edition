using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._33
{
    /// <summary>
    /// 可自动扩容的双端队列。
    /// </summary>
    /// <typeparam name="TItem">队列中要存放的元素。</typeparam>
    public class ResizingArrayDeque<TItem> : IEnumerable<TItem>
    {
        private TItem[] _deque;
        private int _first;
        private int _last;
        private int _count;

        /// <summary>
        /// 默认构造函数，建立一个双向队列。
        /// </summary>
        public ResizingArrayDeque()
        {
            _deque = new TItem[2];
            _first = 0;
            _last = 0;
            _count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// 返回队列中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>
        /// 为队列重新分配空间。
        /// </summary>
        /// <param name="capacity">需要重新分配的空间大小。</param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();

            var temp = new TItem[capacity];
            for (var i = 0; i < _count; i++)
            {
                temp[i] = _deque[(_first + i) % _deque.Length];
            }
            _deque = temp;
            _first = 0;
            _last = _count;
        }


        /// <summary>
        /// 在队列左侧添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素</param>
        public void PushLeft(TItem item)
        {
            if (_count == _deque.Length)
            {
                Resize(2 * _count);
            }

            _first--;
            if (_first < 0)
            {
                _first += _deque.Length;
            }
            _deque[_first] = item;
            _count++;
        }

        public void PushRight (TItem item)
        {
            if (_count == _deque.Length)
            {
                Resize(2 * _count);
            }

            _deque[_last] = item;
            _last = (_last + 1) % _deque.Length;
            _count++;
        }

        public TItem PopRight()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            _last--;
            if (_last < 0)
            {
                _last += _deque.Length;
            }
            var temp = _deque[_last];
            _count--;
            if (_count > 0 && _count == _deque.Length / 4)
                Resize(_deque.Length / 2);
            return temp;
        }

        public TItem PopLeft()
        {
            if (IsEmpty())
                throw new ArgumentException();

            var temp = _deque[_first];
            _first = (_first + 1) % _deque.Length;
            _count--;
            if (_count > 0 && _count == _deque.Length / 4)
            {
                Resize(_deque.Length / 2);
            }
            return temp;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new ResizingDequeEnumerator(_deque, _first, _count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ResizingDequeEnumerator : IEnumerator<TItem>
        {
            private TItem[] _deque;
            private int _current;
            private readonly int _first;
            private readonly int _count;

            public ResizingDequeEnumerator(TItem[] deque, int first, int count)
            {
                _deque = deque;
                _first = first;
                _count = count;
                _current = -1;
            }

            TItem IEnumerator<TItem>.Current => _deque[(_first + _current) % _deque.Length];

            object IEnumerator.Current => _deque[(_first + _current) % _deque.Length];

            void IDisposable.Dispose()
            {
                _deque = null;
                _current = -1;
            }

            bool IEnumerator.MoveNext()
            {
                if (_current == _count - 1)
                {
                    return false;
                }

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
