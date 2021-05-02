using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._33
{
    /// <summary>
    /// 双端队列。
    /// </summary>
    /// <typeparam name="TItem">队列中要存放的元素。</typeparam>
    public class Deque<TItem> : IEnumerable<TItem>
    {
        private class DoubleNode<T>
        {
            public T Item;
            public DoubleNode<T> Next;
            public DoubleNode<T> Prev;
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
                Item = item,
                Prev = null,
                Next = oldFirst
            };
            if (oldFirst == null)
            {
                _last = _first;
            }
            else
            {
                oldFirst.Prev = _first;
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
                Item = item,
                Prev = oldLast,
                Next = null
            };

            if (oldLast == null)
            {
                _first = _last;
            }
            else
            {
                oldLast.Next = _last;
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

            var temp = _last.Item;
            _last = _last.Prev;
            _count--;

            if (_last == null)
            {
                _first = null;
            }
            else
            {
                _last.Next.Item = default(TItem);
                _last.Next = null;
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

            var temp = _first.Item;
            _first = _first.Next;
            _count--;

            if (_first == null)
            {
                _last = null;
            }
            else
            {
                _first.Prev.Item = default(TItem);
                _first.Prev = null;
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
                _current.Next = first;
                _current.Prev = null;
                _first = _current;
            }

            public TItem Current => _current.Item;

            object IEnumerator.Current => _current.Item;

            public void Dispose()
            {
                _current = null;
                _first = null;
            }

            public bool MoveNext()
            {
                if (_current.Next == null)
                    return false;
                _current = _current.Next;
                return true;
            }

            public void Reset()
            {
                _current = _first;
            }
        }
    }
}
