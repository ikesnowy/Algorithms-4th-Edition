using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._48
{
    /// <summary>
    /// 双端栈。
    /// </summary>
    /// <typeparam name="Item">栈中所包含的元素。</typeparam>
    public class DeStack<TItem> : IEnumerable<TItem>
    {
        private class DoubleNode<T>
        {
            public T item;
            public DoubleNode<T> next;
            public DoubleNode<T> prev;
        }

        DoubleNode<TItem> _first;
        DoubleNode<TItem> _last;
        int _leftcount;
        int _rightcount;

        /// <summary>
        /// 默认构造函数，建立一个双端栈。
        /// </summary>
        public DeStack()
        {
            _first = null;
            _last = null;
            _leftcount = 0;
            _rightcount = 0;
        }

        /// <summary>
        /// 检查左侧栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsLeftEmpty()
        {
            return _leftcount == 0;
        }

        /// <summary>
        /// 检查右侧栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsRightEmpty()
        {
            return _rightcount == 0;
        }

        /// <summary>
        /// 返回左侧栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int LeftSize()
        {
            return _leftcount;
        }

        /// <summary>
        /// 返回右侧栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int RightSize()
        {
            return _rightcount;
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
            _leftcount++;
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
            _rightcount++;
        }

        /// <summary>
        /// 从右端删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem PopRight()
        {
            if (IsRightEmpty())
            {
                throw new InvalidOperationException();
            }

            var temp = _last.item;
            _last = _last.prev;
            _rightcount--;

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
            if (IsLeftEmpty())
            {
                throw new InvalidOperationException();
            }

            var temp = _first.item;
            _first = _first.next;
            _leftcount--;

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
