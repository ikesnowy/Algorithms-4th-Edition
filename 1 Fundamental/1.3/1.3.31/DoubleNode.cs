using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._3._31
{
    
     /// <summary>
     /// 双向链表。
     /// </summary>
     /// <typeparam name="TItem">链表中要存放的元素。</typeparam>
    public class DoubleLinkList<TItem> : IEnumerable<TItem>
    {
        private class DoubleNode<T>
        {
            public T Item;
            public DoubleNode<T> Prev;
            public DoubleNode<T> Next;
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
                Item = item,
                Next = _first,
                Prev = null
            };
            if (_first != null)
            {
                _first.Prev = node;
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
                Item = item,
                Next = null,
                Prev = _last
            };
            if (_last != null)
            {
                _last.Next = node;
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
                current = current.Next;
            }
            return current.Item;
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
                current = current.Next;
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
                Next = current,
                Prev = current.Prev,
                Item = item
            };
            current.Prev.Next = node;
            current.Prev = node;
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
                Prev = current,
                Next = current.Next,
                Item = item
            };
            current.Next.Prev = node;
            current.Next = node;
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

            var temp = _first.Item;
            _first = _first.Next;
            _count--;
            if (IsEmpty())
            {
                _last = null;
            }
            else
            {
                _first.Prev = null;
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

            var temp = _last.Item;
            _last = _last.Prev;
            _count--;
            if (IsEmpty())
            {
                _first = null;
            }
            else
            {
                _last.Next = null;
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
            var temp = current.Item;
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
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
