using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    /// <summary>
    /// 背包类。
    /// </summary>
    /// <typeparam name="Item">背包中存放的元素类型。</typeparam>
    public class Bag<TItem> : IEnumerable<TItem>
    {
        private Node<TItem> _first;
        private int _count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Bag()
        {
            _first = null;
            _count = 0;
        }

        /// <summary>
        /// 背包是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty()
        {
            return _first == null;
        }

        /// <summary>
        /// 获得背包中元素的数量。
        /// </summary>
        /// <returns>背包中元素的数量。</returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>
        /// 向背包中添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void Add(TItem item)
        {
            var oldFirst = _first;
            _first = new Node<TItem>();
            _first.item = item;
            _first.next = oldFirst;
            _count++;
        }

        /// <summary>
        /// 获得枚举器。
        /// </summary>
        /// <returns>返回枚举器对象。</returns>
        public IEnumerator<TItem> GetEnumerator()
        {
            return new BagEnumerator(_first);
        }

        /// <summary>
        /// 获得枚举器。
        /// </summary>
        /// <returns>背包枚举器对象。</returns>
        /// <remarks>这个方法实际上调用的是 <see cref="GetEnumerator"/>。</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 背包枚举器类。
        /// </summary>
        private class BagEnumerator : IEnumerator<TItem>
        {
            private Node<TItem> _current;
            private Node<TItem> _first;

            TItem IEnumerator<TItem>.Current => _current.item;

            object IEnumerator.Current => _current.item;

            /// <summary>
            /// 构造一个背包枚举器。
            /// </summary>
            /// <param name="first">背包的第一个结点。</param>
            public BagEnumerator(Node<TItem> first)
            {
                _current = new Node<TItem>();
                _current.next = first;
                this._first = _current;
            }

            void IDisposable.Dispose()
            {
                _current = null;
                _first = null;
                return;
            }

            bool IEnumerator.MoveNext()
            {
                if (_current.next == null)
                    return false;

                _current = _current.next;
                return true;
            }

            void IEnumerator.Reset()
            {
                _current = _first;
            }
        }
    }


}
