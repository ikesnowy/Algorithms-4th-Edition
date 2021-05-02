using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._33
{
    /// <summary>
    /// 双端队列。
    /// </summary>
    /// <typeparam name="Item">队列中要存放的元素。</typeparam>
    public class Deque<TItem> : IEnumerable<TItem>
    {
        private class DoubleNode<T>
        {
            public T item;
            public DoubleNode<T> next;
            public DoubleNode<T> prev;
        }

        DoubleNode<TItem> _first;
        DoubleNode<TItem> _last;
        int _count;

        /// <summary>
        /// 默认构造函数，建立一个双端队列。
        /// </summary>
        public Deque()
        {
            _first = null;
            _last = null;
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
        /// 向左端添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void PushLeft(TItem item)
        {
            var oldFirst = _first;
            _first = new DoubleNode<TItem>
            {
                item = item,
                prev = null,
                next = oldFirst
            };
            if (oldFirst == null)
            {
                _last = _first;
            }
            else
            {
                oldFirst.prev = _first;
            }
            _count++;
        }

        /// <summary>
        /// 向右端添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void PushRight(TItem item)
        {
            var oldLast = _last;
            _last = new DoubleNode<TItem>
            {
                item = item,
                prev = oldLast,
                next = null
            };

            if (oldLast == null)
            {
                _first = _last;
            }
            else
            {
                oldLast.next = _last;
            }
            _count++;
        }

        /// <summary>
        /// 从右端删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem PopRight()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var temp = _last.item;
            _last = _last.prev;
            _count--;

            if (_last == null)
            {
                _first = null;
            }
            else
            {
                _last.next.item = default(TItem);
                _last.next = null;
            }
            return temp;
        }

        /// <summary>
        /// 从左端删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem PopLeft()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var temp = _first.item;
            _first = _first.next;
            _count--;

            if (_first == null)
            {
                _last = null;
            }
            else
            {
                _first.prev.item = default(TItem);
                _first.prev = null;
            }

            return temp;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new DequeEnumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DequeEnumerator : IEnumerator<TItem>
        {
            private DoubleNode<TItem> _current;
            private DoubleNode<TItem> _first;

            public DequeEnumerator(DoubleNode<TItem> first) 
            {
                _current = new DoubleNode<TItem>();
                _current.next = first;
                _current.prev = null;
                this._first = _current;
            }

            public TItem Current => _current.item;

            object IEnumerator.Current => _current.item;

            public void Dispose()
            {
                _current = null;
                _first = null;
            }

            public bool MoveNext()
            {
                if (_current.next == null)
                    return false;
                _current = _current.next;
                return true;
            }

            public void Reset()
            {
                _current = _first;
            }
        }
    }
}
