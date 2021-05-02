using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2._2._15
{
    /// <summary>
    /// 队列类。
    /// </summary>
    /// <typeparam name="TItem">队列存放的元素类型。</typeparam>
    public class Queue<TItem> : IEnumerable<TItem>
    {
        private Node<TItem> _first;
        private Node<TItem> _last;
        private int _count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Queue()
        {
            _first = null;
            _last = null;
            _count = 0;
        }

        /// <summary>
        /// 复制构造函数。
        /// </summary>
        /// <param name="r"></param>
        public Queue(Queue<TItem> r)
        {
            foreach (var i in r)
            {
                Enqueue(i);
            }
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _first == null;
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
            return _first.Item;
        }

        /// <summary>
        /// 将一个新元素加入队列中。
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
        /// 将队列中的第一个元素出队并返回它。
        /// </summary>
        /// <returns></returns>
        public TItem Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            var item = _first.Item;
            _first = _first.Next;
            _count--;
            if (IsEmpty())
                _last = null;
            return item;
        }

        /// <summary>
        /// 在当前队列之后附加一个队列。
        /// </summary>
        /// <param name="q1">需要被附加的队列。</param>
        /// <param name="q2">需要附加的队列（将被删除）。</param>
        public static Queue<TItem> Catenation(Queue<TItem> q1, Queue<TItem> q2)
        {
            if (q1.IsEmpty())
            {
                q1._first = q2._first;
                q1._last = q2._last;
                q1._count = q2._count;
            }
            else
            {
                q1._last.Next = q2._first;
                q1._last = q2._last;
                q1._count += q2._count;
            }

            return q1;
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
            return new QueueEnumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<TItem>
        {
            private Node<TItem> _current;
            private Node<TItem> _first;

            public QueueEnumerator(Node<TItem> first)
            {
                _current = new Node<TItem>();
                _current.Next = first;
                _first = _current;
            }

            TItem IEnumerator<TItem>.Current => _current.Item;

            object IEnumerator.Current => _current.Item;

            void IDisposable.Dispose()
            {
                _first = null;
                _current = null;
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
