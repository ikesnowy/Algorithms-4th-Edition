using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._3._31
{
    
     /// <summary>
     /// 双向链表。
     /// </summary>
     /// <typeparam name="Item">链表中要存放的元素。</typeparam>
    public class DoubleLinkList<TItem> : IEnumerable<TItem>
    {
        private class DoubleNode<T>
        {
            public T item;
            public DoubleNode<T> prev;
            public DoubleNode<T> next;
        }
        DoubleNode<TItem> _first;
        DoubleNode<TItem> _last;
        int _count;

        /// <summary>
        /// 建立一条双向链表。
        /// </summary>
        public DoubleLinkList()
        {
            _first = null;
            _last = null;
            _count = 0;
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
        /// 返回链表中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _count;
        }

        /// <summary>
        /// 在表头插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void InsertFront(TItem item)
        {
            var node = new DoubleNode<TItem>
            {
                item = item,
                next = _first,
                prev = null
            };
            if (_first != null)
            {
                _first.prev = node;
            }
            else
            {
                _last = node;
            }
            _first = node;
            _count++;
        }

        /// <summary>
        /// 在表尾插入一个元素。
        /// </summary>
        /// <param name="item">要插入表尾的元素。</param>
        public void InsertRear(TItem item)
        {
            var node = new DoubleNode<TItem>
            {
                item = item,
                next = null,
                prev = _last
            };
            if (_last != null)
            {
                _last.next = node;
            }
            else
            {
                _first = node;
            }
            _last = node;
            _count++;
        }

        /// <summary>
        /// 检索指定下标的元素。
        /// </summary>
        /// <param name="index">要检索的下标。</param>
        /// <returns></returns>
        public TItem At(int index)
        {
            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            var current = _first;
            for (var i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.item;
        }

        /// <summary>
        /// 返回指定下标的结点。
        /// </summary>
        /// <param name="index">要查找的下标。</param>
        /// <returns></returns>
        private DoubleNode<TItem> Find(int index)
        {
            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            var current = _first;
            for (var i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// 在指定位置之前插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="index">插入位置的下标。</param>
        public void InsertBefore(TItem item, int index)
        {
            if (index == 0)
            {
                InsertFront(item);
                return;
            }

            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            var current = Find(index);
            var node = new DoubleNode<TItem>
            {
                next = current,
                prev = current.prev,
                item = item
            };
            current.prev.next = node;
            current.prev = node;
            _count++;
        }

        /// <summary>
        /// 在指定位置之后插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="index">查找元素的下标。</param>
        public void InsertAfter(TItem item, int index)
        {
            if (index == _count - 1)
            {
                InsertRear(item);
                return;
            }

            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            var current = Find(index);
            var node = new DoubleNode<TItem>
            {
                prev = current,
                next = current.next,
                item = item
            };
            current.next.prev = node;
            current.next = node;
            _count++;
        }

        /// <summary>
        /// 删除表头元素。
        /// </summary>
        /// <returns></returns>
        public TItem DeleteFront()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List underflow");

            var temp = _first.item;
            _first = _first.next;
            _count--;
            if (IsEmpty())
            {
                _last = null;
            }
            else
            {
                _first.prev = null;
            }
            return temp;
        }

        /// <summary>
        /// 删除表尾的元素。
        /// </summary>
        /// <returns></returns>
        public TItem DeleteRear()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List underflow");

            var temp = _last.item;
            _last = _last.prev;
            _count--;
            if (IsEmpty())
            {
                _first = null;
            }
            else
            {
                _last.next = null;
            }
            return temp;
        }

        /// <summary>
        /// 删除指定位置的元素。
        /// </summary>
        /// <param name="index">要删除元素的下标。</param>
        /// <returns></returns>
        public TItem Delete(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                return DeleteFront();
            }

            if (index == _count - 1)
            {
                return DeleteRear();
            }

            var current = Find(index);
            var temp = current.item;
            current.prev.next = current.next;
            current.next.prev = current.prev;
            _count--;
            return temp;
        }

        public override string ToString()
        {
            var s = new StringBuilder();

            foreach (var i in this)
            {
                s.Append(i.ToString());
                s.Append(" ");
            }

            return s.ToString();
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new DoubleLinkListEnumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DoubleLinkListEnumerator : IEnumerator<TItem>
        {
            DoubleNode<TItem> _current;
            DoubleNode<TItem> _first;

            public DoubleLinkListEnumerator(DoubleNode<TItem> first)
            {
                _current = new DoubleNode<TItem>();
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
