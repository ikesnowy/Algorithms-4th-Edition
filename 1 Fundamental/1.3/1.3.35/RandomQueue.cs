using System;

namespace _1._3._35
{
    /// <summary>
    /// 随机队列。
    /// </summary>
    /// <typeparam name="TItem">队列中要存放的元素。</typeparam>
    public class RandomQueue<TItem>
    {
        private TItem[] _queue;
        private int _count;

        /// <summary>
        /// 新建一个随机队列。
        /// </summary>
        public RandomQueue()
        {
            _queue = new TItem[2];
            _count = 0;
        }

        /// <summary>
        /// 判断队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// 为队列重新分配内存空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException();
            }

            var temp = new TItem[capacity];
            for (var i = 0; i < _count; i++)
            {
                temp[i] = _queue[i];
            }

            _queue = temp;
        }

        /// <summary>
        /// 向队列中添加一个元素。
        /// </summary>
        /// <param name="item">要向队列中添加的元素。</param>
        public void Enqueue(TItem item)
        {
            if (_queue.Length == _count)
            {
                Resize(_count * 2);
            }

            _queue[_count] = item;
            _count++;
        }

        /// <summary>
        /// 从队列中随机删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var random = new Random(DateTime.Now.Millisecond);
            var index = random.Next(_count);

            var temp = _queue[index];
            _queue[index] = _queue[_count - 1];
            _queue[_count - 1] = temp;

            _count--;

            if (_count < _queue.Length / 4)
            {
                Resize(_queue.Length / 2);
            }

            return temp;
        }

        /// <summary>
        /// 随机返回一个队列中的元素。
        /// </summary>
        /// <returns></returns>
        public TItem Sample()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var random = new Random();
            var index = random.Next(_count);

            return _queue[index];
        }
    }
}
