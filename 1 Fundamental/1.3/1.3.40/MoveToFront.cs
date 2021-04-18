using System;
using System.Text;

namespace _1._3._40
{
    /// <summary>
    /// 前移编码队列。
    /// </summary>
    /// <typeparam name="Item">需要前移编码的元素类型。</typeparam>
    class MoveToFront<TItem>
    {
        private class Node<T>
        {
            public T item;
            public Node<T> next;
        }

        private Node<TItem> _first;
        private int _count;

        /// <summary>
        /// 检查编码组是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _first == null;
        }

        /// <summary>
        /// 建立一个前移编码组。
        /// </summary>
        public MoveToFront()
        {
            _first = null;
            _count = 0;
        }

        /// <summary>
        /// 找到相应元素的前驱结点。
        /// </summary>
        /// <param name="item">要寻找的元素。</param>
        /// <returns></returns>
        private Node<TItem> Find(TItem item)
        {
            if (IsEmpty())
            {
                return null;
            }

            var current = _first;
            while (current.next != null)
            {
                if (current.next.item.Equals(item))
                {
                    return current;
                }
                current = current.next;
            }
            return null;
        }

        /// <summary>
        /// 前移编码插入。
        /// </summary>
        /// <param name="item">需要插入的元素。</param>
        public void Insert(TItem item)
        {
            var temp = Find(item);
            if (temp == null)
            {
                temp = new Node<TItem>()
                {
                    item = item,
                    next = _first
                };

                _first = temp;
                _count++;
            }
            else if (temp != null && _count != 1)
            {
                var target = temp.next;
                temp.next = temp.next.next;
                target.next = _first;
                _first = target;
            }
        }

        /// <summary>
        /// 查看第一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem Peek()
        {
            if (_first == null)
            {
                throw new InvalidOperationException();
            }

            return _first.item;
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            var current = _first;
            while (current != null)
            {
                s.Append(current.item.ToString());
                s.Append(" ");
                current = current.next;
            }

            return s.ToString();
        }
    }
}
