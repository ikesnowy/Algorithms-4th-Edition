using System;

namespace _1._3._38
{
    /// <summary>
    /// 以链表为基础的队列。
    /// </summary>
    /// <typeparam name="TItem">队列中要保存的元素。</typeparam>
    class LinkedListBasedGeneralizeQueue<TItem>
    {
        private class Node<T>
        {
            public T Item;
            public Node<T> Next;
            public bool IsVisited;
        }

        private Node<TItem> _first;
        private Node<TItem> _last;
        private int _count;

        /// <summary>
        /// 建立一个队列。
        /// </summary>
        public LinkedListBasedGeneralizeQueue()
        {
            _first = null;
            _last = null;
            _count = 0;
        }

        /// <summary>
        /// 检查数组是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _first == null;
        }

        /// <summary>
        /// 在队尾插入元素。
        /// </summary>
        /// <param name="item">需要插入的元素。</param>
        public void Insert(TItem item)
        {
            var oldLast = _last;
            _last = new Node<TItem>
            {
                Item = item,
                IsVisited = false,
                Next = null
            };

            if (oldLast == null)
            {
                _first = _last;
            }
            else
            {
                oldLast.Next = _last;
            }
            _count++;
        }

        /// <summary>
        /// 删除第 k 个插入的结点
        /// </summary>
        /// <param name="k">结点序号（从 1 开始）</param>
        /// <returns></returns>
        public TItem Delete(int k)
        {
            if (k > _count || k <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            k--;

            // 找到目标结点
            var current = _first;
            for (var i = 0; i < k; i++)
            {
                current = current.Next;
            }

            if (current.IsVisited)
            {
                throw new ArgumentException("this node had been already deleted");
            }

            current.IsVisited = true;
            return current.Item;
        }

    }
}
