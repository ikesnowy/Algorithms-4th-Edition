using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._3._29
{
    /// <summary>
    /// 队列类。
    /// </summary>
    /// <typeparam name="Item">队列中存放的元素。</typeparam>
    public class Queue<TItem> : IEnumerable<TItem>
    {
        private Node<TItem> _last;
        private int _count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Queue()
        {
            _last = null;
            _count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _last == null;
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
        /// 返回队列中的第一个元素（但不让它出队）。
        /// </summary>
        /// <returns></returns>
        public TItem Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            return _last.next.item;
        }

        /// <summary>
        /// 将一个新元素加入队列中。
        /// </summary>
        /// <param name="item">要入队的元素。</param>
        public void Enqueue(TItem item)
        {
            var oldLast = _last;
            _last = new Node<TItem>();
            _last.item = item;
            _last.next = _last;

            if (oldLast != null)
            {
                _last.next = oldLast.next;
                oldLast.next = _last;
            }
            _count++;
        }

        /// <summary>
        /// 将队列中的第一个元素出队并返回它。
        /// </summary>
        /// <returns></returns>
        public TItem Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            TItem item = _last.next.item;
            _last.next = _last.next.next;
            _count--;
            if (IsEmpty())
                _last = null;
            return item;
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            foreach (var item in this)
            {
                s.Append(item);
                s.Append(" ");
            }
            return s.ToString();
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new QueueEnumerator(_last);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<TItem>
        {
            private Node<TItem> _current;
            private Node<TItem> _first;

            public QueueEnumerator(Node<TItem> last)
            {
                _current = new Node<TItem>();
                _current.next = last.next;
                _first = _current;
            }

            TItem IEnumerator<TItem>.Current => _current.item;

            object IEnumerator.Current => _current.item;

            void IDisposable.Dispose()
            {
                _first = null;
                _current = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (_current.next == _first.next)
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

    public class Node<TItem>
    {
        public TItem item;
        public Node<TItem> next;
    }
}
