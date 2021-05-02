namespace _1._4._27
{
    /// <summary>
    /// 用两个栈模拟的队列。
    /// </summary>
    /// <typeparam name="TItem">队列中的元素。</typeparam>
    class StackQueue<TItem>
    {
        readonly Stack<TItem> _h;// 用于保存出队元素
        readonly Stack<TItem> _;// 用于保存入队元素

        /// <summary>
        /// 构造一个队列。
        /// </summary>
        public StackQueue()
        {
            _h = new Stack<TItem>();
            _ = new Stack<TItem>();
        }

        /// <summary>
        /// 将栈 T 中的元素依次弹出并压入栈 H 中。
        /// </summary>
        private void Reverse()
        {
            while (!_.IsEmpty())
            {
                _h.Push(_.Pop());
            }
        }

        /// <summary>
        /// 将一个元素出队。
        /// </summary>
        /// <returns></returns>
        public TItem Dequeue()
        {
            // 如果没有足够的出队元素，则将 T 中的元素移动过来
            if (_h.IsEmpty())
            {
                Reverse();
            }

            return _h.Pop();
        }

        /// <summary>
        /// 将一个元素入队。
        /// </summary>
        /// <param name="item">要入队的元素。</param>
        public void Enqueue(TItem item)
        {
            _.Push(item);
        }
    }
}
