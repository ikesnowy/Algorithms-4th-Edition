using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._4._37
{
    /// <summary>
    /// 固定大小的栈。
    /// </summary>
    class FixedCapacityStack<TItem> : IEnumerable<TItem>
    {
        private readonly TItem[] _a;
        private int _n;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        /// <param name="capacity">栈的大小。</param>
        public FixedCapacityStack(int capacity)
        {
            _a = new TItem[capacity];
            _n = 0;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _n == 0;
        }

        /// <summary>
        /// 检查栈是否已满。
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return _n == _a.Length;
        }

        /// <summary>
        /// 将一个元素压入栈中。
        /// </summary>
        /// <param name="item">要压入栈中的元素。</param>
        public void Push(TItem item)
        {
            _a[_n] = item;
            _n++;
        }

        /// <summary>
        /// 从栈中弹出一个元素，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public TItem Pop()
        {
            _n--;
            return _a[_n];
        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public TItem Peek()
        {
            return _a[_n - 1];
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new ReverseEnmerator(_a);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ReverseEnmerator : IEnumerator<TItem>
        {
            private int _current;
            private TItem[] _a;

            public ReverseEnmerator(TItem[] a)
            {
                _current = a.Length;
                this._a = a;
            }

            TItem IEnumerator<TItem>.Current => _a[_current];

            object IEnumerator.Current => _a[_current];

            void IDisposable.Dispose()
            {
                _current = -1;
                _a = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (_current == 0)
                    return false;
                _current--;
                return true;
            }

            void IEnumerator.Reset()
            {
                _current = _a.Length;
            }
        }
    }
}
