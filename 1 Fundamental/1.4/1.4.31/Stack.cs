using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._4._31
{
    /// <summary>
    /// 链栈。
    /// </summary>
    /// <typeparam name="Item">链栈中保存的元素。</typeparam>
    public class Stack<TItem> : IEnumerable<TItem>
    {
        private Node<TItem> _first;
        private int _count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Stack()
        {
            _first = null;
            _count = 0;
        }

        /// <summary>
        /// 复制构造函数。
        /// </summary>
        /// <param name="s">被复制的栈。</param>
        public Stack(Stack<TItem> s)
        {
            if (s._first != null)
            {
                _first = new Node<TItem>(s._first);
                for (var x = _first; x.next != null; x = x.next)
                {
                    x.next = new Node<TItem>(x.next);
                }
            }
            _count = s._count;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _first == null;
        }

        /// <summary>
        /// 返回栈内元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>
        /// 将一个元素压入栈中。
        /// </summary>
        /// <param name="item">要压入栈中的元素。</param>
        public void Push(TItem item)
        {
            var oldFirst = _first;
            _first = new Node<TItem>();
            _first.item = item;
            _first.next = oldFirst;
            _count++;
        }

        /// <summary>
        /// 将一个元素从栈中弹出，返回弹出的元素。
        /// </summary>
        /// <returns></returns>
        public TItem Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            var item = _first.item;
            _first = _first.next;
            _count--;
            return item;
        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public TItem Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            return _first.item;
        }

        /// <summary>
        /// 将两个栈连接。
        /// </summary>
        /// <param name="s1">第一个栈。</param>
        /// <param name="s2">第二个栈（将被删除）。</param>
        /// <returns></returns>
        public static Stack<TItem> Catenation(Stack<TItem> s1, Stack<TItem> s2)
        {
            if (s1.IsEmpty())
            {
                s1._first = s2._first;
                s1._count = s2._count;
            }
            else
            {
                var last = s1._first;
                while (last.next != null)
                {
                    last = last.next;
                }
                last.next = s2._first;
                s1._count += s2._count;
            }
            s2 = null;
            return s1;
        }

        /// <summary>
        /// 创建栈的浅表副本。
        /// </summary>
        /// <returns></returns>
        public Stack<TItem> Copy()
        {
            var temp = new Stack<TItem>();
            temp._first = _first;
            temp._count = _count;
            return temp;
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            foreach (var n in this)
            {
                s.Append(n);
                s.Append(' ');
            }
            return s.ToString();
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new StackEnumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<TItem>
        {
            private Node<TItem> _current;
            private Node<TItem> _first;

            public StackEnumerator(Node<TItem> first)
            {
                _current = new Node<TItem>();
                _current.next = first;
                this._first = _current;
            }

            TItem IEnumerator<TItem>.Current => _current.item;

            object IEnumerator.Current => _current.item;

            void IDisposable.Dispose()
            {
                _current = null;
                _first = null;
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
