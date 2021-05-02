using System;

namespace _1._3._38
{
    /// <summary>
    /// 以一维数组为基础的队列。
    /// </summary>
    /// <typeparam name="TItem">队列中要保存的元素。</typeparam>
    class ArrayBasedGeneralizeQueue<TItem>
    {
        private TItem[] _queue;
        private bool[] _isVisited;
        private int _count;
        private int _last;

        /// <summary>
        /// 建立一个队列。
        /// </summary>
        public ArrayBasedGeneralizeQueue()
        {
            _queue = new TItem[2];
            _isVisited = new bool[2];
            _last = 0;
            _count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// 为队列重新分配空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            var temp = new TItem[capacity];
            for (var i = 0; i < _count; i++)
            {
                temp[i] = _queue[i];
            }
            _queue = temp;

            var t = new bool[capacity];
            for (var i = 0; i < _count; i++)
            {
                t[i] = _isVisited[i];
            }
            _isVisited = t;
        }

        /// <summary>
        /// 向队列中插入一个元素。
        /// </summary>
        /// <param name="item">要插入队列的元素。</param>
        public void Insert(TItem item)
        {
            if (_count == _queue.Length)
            {
                Resize(_queue.Length * 2);
            }

            _queue[_last] = item;
            _isVisited[_last] = false;
            _last++;
            _count++;
        }

        /// <summary>
        /// 从队列中删除并返回第 k 个插入的元素。
        /// </summary>
        /// <param name="k">要删除元素的顺序（从 1 开始）</param>
        /// <returns></returns>
        public TItem Delete(int k)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            if (k > _last || k < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_isVisited[k - 1])
            {
                throw new ArgumentException("this node had been already deleted");
            }

            var temp = _queue[k - 1];
            _isVisited[k - 1] = true;
            _count--;
            return temp;
        }
    }
}
