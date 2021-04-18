using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2._2._18
{
    /// <summary>
    /// 链表类。
    /// </summary>
    /// <typeparam name="Item">链表存放的元素类型。</typeparam>
    public class LinkedList<TItem> : IEnumerable<TItem>
    {
        private Node<TItem> _first;
        private int _count;

        /// <summary>
        /// 建立一条链表。
        /// </summary>
        public LinkedList()
        {
            _first = null;
            _count = 0;
        }

        /// <summary>
        /// 在表头插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void Insert(TItem item)
        {
            var n = new Node<TItem>();
            n.item = item;
            n.next = _first;
            _first = n;
            _count++;
        }

        /// <summary>
        /// 在指定位置前面插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="position">要插入的位置。（从 0 开始）</param>
        public void Insert(TItem item, int position)
        {
            if (position > _count)
            {
                throw new IndexOutOfRangeException();
            }
            if (position == 0)
            {
                Insert(item);
                return;
            }

            var n = new Node<TItem>();
            n.item = item;

            var front = _first;
            for (var i = 1; i < position; i++)
            {
                front = front.next;
            }

            n.next = front.next;
            front.next = n;
            _count++;
        }

        /// <summary>
        /// 获取指定位置的元素。
        /// </summary>
        /// <param name="index">元素下标。</param>
        /// <returns></returns>
        public TItem Find(int index)
        {
            if (index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            var current = _first;
            for (var i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current.item;
        }

        /// <summary>
        /// 删除指定位置的元素，返回该元素。
        /// </summary>
        /// <param name="index">需要删除元素的位置。</param>
        /// <returns></returns>
        public TItem Delete(int index)
        {
            if (index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            var front = _first;
            var temp = _first.item;
            if (index == 0)
            {
                _first = _first.next;
                _count--;
                return temp;
            }

            for (var i = 1; i < index; i++)
            {
                front = front.next;
            }

            temp = front.next.item;
            front.next = front.next.next;
            _count--;
            return temp;
        }

        /// <summary>
        /// 获得链表的中间元素。
        /// </summary>
        /// <returns>链表的中间元素。</returns>
        public Node<TItem> GetMiddle()
        {
            var middle = _first;
            var mid = _count / 2;
            for (var i = 0; i < mid - 1; i++)
            {
                middle = middle.next;
            }
            return middle;
        }

        /// <summary>
        /// 检查链表是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// 获取链表中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>
        /// 将链表转化成单个字符串，元素之间用空格隔开。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var s = new StringBuilder();

            foreach (var i in this)
            {
                s.Append(i);
                s.Append(" ");
            }

            return s.ToString();
        }

        /// <summary>
        /// 获得表头结点。
        /// </summary>
        /// <returns>表头结点</returns>
        public Node<TItem> GetFirst() => _first;

        /// <summary>
        /// 设置表头结点。
        /// </summary>
        /// <param name="first">新的表头结点。</param>
        public void SetFirst(Node<TItem> first) => this._first = first;

        /// <summary>
        /// 将两个链表相连接。
        /// </summary>
        /// <param name="a">第一个链表。</param>
        /// <param name="b">第二个链表。（将被清空）</param>
        public static void Merge(LinkedList<TItem> a, LinkedList<TItem> b)
        {
            var pointer = a._first;
            while (pointer.next != null)
                pointer = pointer.next;
            pointer.next = b._first;
            a._count += b._count;
            b._first = null;
            b._count = 0;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new LinkedListEnumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LinkedListEnumerator : IEnumerator<TItem>
        {
            Node<TItem> _current;
            Node<TItem> _first;

            public LinkedListEnumerator(Node<TItem> first)
            {
                _current = new Node<TItem>();
                _current.next = first;
                this._first = _current;
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
