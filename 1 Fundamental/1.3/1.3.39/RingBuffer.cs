using System;

namespace _1._3._39
{
    /// <summary>
    /// 环形缓冲区。
    /// </summary>
    /// <typeparam name="TItem">缓冲区包含的元素类型。</typeparam>
    class RingBuffer<TItem>
    {
        private readonly TItem[] _buffer;
        private int _count;
        private int _first;  // 读指针
        private int _last;   // 写指针

        /// <summary>
        /// 建立一个缓冲区。
        /// </summary>
        /// <param name="n">缓冲区的大小。</param>
        public RingBuffer(int n)
        {
            _buffer = new TItem[n];
            _count = 0;
            _first = 0;
            _last = 0;
        }

        /// <summary>
        /// 检查缓冲区是否已满。
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return _count == _buffer.Length;
        }

        /// <summary>
        /// 检查缓冲区是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// 向缓冲区写入数据。
        /// </summary>
        /// <param name="item">要写入的数据。</param>
        public void Write(TItem item)
        {
            if (IsFull())
            {
                throw new OutOfMemoryException("buffer is full");
            }

            _buffer[_last] = item;
            _last = (_last + 1) % _buffer.Length;
            _count++;
        }

        /// <summary>
        /// 从缓冲区读取一个数据。
        /// </summary>
        /// <returns></returns>
        public TItem Read()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var temp = _buffer[_first];
            _first = (_first + 1) % _buffer.Length;
            _count--;
            return temp;
        }
    }
}
