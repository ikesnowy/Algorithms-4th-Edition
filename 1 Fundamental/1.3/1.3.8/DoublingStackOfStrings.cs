using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._8
{
    /// <summary>
    /// 容量自动加倍的字符串栈。
    /// </summary>
    class DoublingStackOfStrings : IEnumerable<string>
    {
        private string[] _items;
        private int _count;

        /// <summary>
        /// 新建一个字符串栈。
        /// </summary>
        public DoublingStackOfStrings()
        {
            _items = new string[2];
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
        /// 返回栈中字符串的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>
        /// 向栈中压入一个字符串。
        /// </summary>
        /// <param name="s"></param>
        public void Push(string s)
        {
            if (_count == _items.Length)
                Resize(_items.Length * 2);
            _items[_count] = s;
            _count++;
        }

        /// <summary>
        /// 从栈中弹出一个字符串，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public string Pop()
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
        public string Peek()
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
            var temp = new string[capcity];
            
            for (var i = 0; i < _count; i++)
            {
                temp[i] = _items[i];
            }

            _items = temp;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new StackEnumerator(_items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<string>
        {
            int _current;
            string[] _items;

            public StackEnumerator(string[] items)
            {
                this._items = items;
                _current = -1;
            }

            string IEnumerator<string>.Current => _items[_current];

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
