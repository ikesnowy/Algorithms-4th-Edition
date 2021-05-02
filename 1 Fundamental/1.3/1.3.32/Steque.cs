using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._3._32
{
    // API:
    // public class Steque<Item> : IEnumerable<Item>
    //    public Steque(); 默认构造函数。
    //    public bool IsEmpty(); 检查 Steque 是否为空。
    //    public int Size(); 返回 Steque 中的元素数量。
    //    public void Push(Item item); 向 Steque 中压入一个元素。
    //    public Item Pop(); 从 Steque 中弹出一个元素。
    //    public void Peek(); 返回栈顶元素（但不弹出它）。
    //    public void Enqueue(Item item); 将一个元素添加入 Steque 中。

    /// <summary>
    /// Steque。
    /// </summary>
    /// <typeparam name="TItem">Steque 中要存放的元素。</typeparam>
    public class Steque<TItem> : IEnumerable<TItem>
    {
        private Node<TItem> _first;
        private Node<TItem> _last;
        private int _count;

        private class Node<T>
        {
            public T Item;
            public Node<T> Next;
        }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Steque()
        {
            _first = null;
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
            _first.Item = item;
            _first.Next = oldFirst;

            if (oldFirst == null)
            {
                _last = _first;
            }
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
            var item = _first.Item;
            _first = _first.Next;
            _count--;
            if (_count == 0)
            {
                _last = null;
            }
            return item;
        }

        /// <summary>
        /// 将一个元素加入队列中。
        /// </summary>
        /// <param name="item">要入队的元素。</param>
        public void Enqueue(TItem item)
        {
            var oldLast = _last;
            _last = new Node<TItem>();
            _last.Item = item;
            _last.Next = null;
            if (IsEmpty())
                _first = _last;
            else
                oldLast.Next = _last;
            _count++;
        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public TItem Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            return _first.Item;
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
                _current.Next = first;
                _first = _current;
            }

            TItem IEnumerator<TItem>.Current => _current.Item;

            object IEnumerator.Current => _current.Item;

            void IDisposable.Dispose()
            {
                _current = null;
                _first = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (_current.Next == null)
                    return false;

                _current = _current.Next;
                return true;
            }

            void IEnumerator.Reset()
            {
                _current = _first;
            }
        }
    }
}
