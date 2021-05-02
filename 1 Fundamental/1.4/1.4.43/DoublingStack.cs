using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._4._43
{
    /// <summary>
    /// 容量自动加倍的栈。
    /// </summary>
    class DoublingStack<TItem> : IEnumerable<TItem>
    {
        private TItem[] _items;
        private int _count;

        /// <summary>
        /// 新建一个栈。
        /// </summary>
        public DoublingStack()
        {
            _items = new TItem[2];
            _count = 0;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// 返回栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>
        /// 向栈中压入一个元素。
        /// </summary>
        /// <param name="s"></param>
        public void Push(TItem s)
        {
            if (_count == _items.Length)
                Resize(_items.Length * 2);
            _items[_count] = s;
            _count++;
        }

        /// <summary>
        /// 从栈中弹出一个元素，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public TItem Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack underflow");
            _count--;

            // 缩小长度
            if (_count > 0 && _count <= _items.Length / 4)
                Resize(_items.Length / 2);

            return _items[_count];

        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public TItem Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack underflow");
            return _items[_count - 1];
        }

        /// <summary>
        /// 为栈重新分配空间，超出空间的元素将被舍弃。
        /// </summary>
        /// <param name="capcity">重新分配的空间大小。</param>
        private void Resize(int capcity)
        {
            var temp = new TItem[capcity];
            
            for (var i = 0; i < _count; i++)
            {
                temp[i] = _items[i];
            }

            _items = temp;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new StackEnumerator(_items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<TItem>
        {
            int _current;
            TItem[] _items;

            public StackEnumerator(TItem[] items)
            {
                _items = items;
                _current = -1;
            }

            TItem IEnumerator<TItem>.Current => _items[_current];

            object IEnumerator.Current => _items[_current];

            void IDisposable.Dispose()
            {
                _items = null;
                _current = -1;
            }

            bool IEnumerator.MoveNext()
            {
                if (_current == _items.Length - 1)
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
