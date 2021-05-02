namespace _1._4._28
{
    /// <summary>
    /// 用一条队列模拟的栈。
    /// </summary>
    /// <typeparam name="TItem">栈中保存的元素。</typeparam>
    class QueueStack<TItem>
    {
        readonly Queue<TItem> _queue;

        /// <summary>
        /// 初始化一个栈。
        /// </summary>
        public QueueStack()
        {
            _queue = new Queue<TItem>();
        }

        /// <summary>
        /// 向栈中添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Push(TItem item)
        {
            _queue.Enqueue(item);
            var size = _queue.Size();
            // 倒转队列
            for (var i = 0; i < size - 1; i++)
            {
                _queue.Enqueue(_queue.Dequeue());
            }
        }

        /// <summary>
        /// 从栈中弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem Pop()
        {
            return _queue.Dequeue();
        }

        /// <summary>
        /// 确定栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _queue.IsEmpty();
        }
    }
}
