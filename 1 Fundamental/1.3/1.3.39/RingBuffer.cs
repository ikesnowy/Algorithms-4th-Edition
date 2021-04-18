using System;

namespace _1._3._39
{
    /// <summary>
    /// 环形缓冲区。
    /// </summary>
    /// <typeparam name="Item">缓冲区包含的元素类型。</typeparam>
    class RingBuffer<Item>
    {
        private readonly Item[] buffer;
        private int count;
        private int first;  // 读指针
        private int last;   // 写指针

        /// <summary>
        /// 建立一个缓冲区。
        /// </summary>
        /// <param name="N">缓冲区的大小。</param>
        public RingBuffer(int N)
        {
            buffer = new Item[N];
            count = 0;
            first = 0;
            last = 0;
        }

        /// <summary>
        /// 检查缓冲区是否已满。
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return count == buffer.Length;
        }

        /// <summary>
        /// 检查缓冲区是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 向缓冲区写入数据。
        /// </summary>
        /// <param name="item">要写入的数据。</param>
        public void Write(Item item)
        {
            if (IsFull())
            {
                throw new OutOfMemoryException("buffer is full");
            }

            buffer[last] = item;
            last = (last + 1) % buffer.Length;
            count++;
        }

        /// <summary>
        /// 从缓冲区读取一个数据。
        /// </summary>
        /// <returns></returns>
        public Item Read()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var temp = buffer[first];
            first = (first + 1) % buffer.Length;
            count--;
            return temp;
        }
    }
}
