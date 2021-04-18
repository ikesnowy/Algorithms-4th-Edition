namespace _1._4._30
{
    /// <summary>
    /// 用一个栈和一个 Steque 模拟的双向队列。
    /// </summary>
    /// <typeparam name="Item">双向队列中保存的元素类型。</typeparam>
    class Deque<TItem>
    {
        readonly Stack<TItem> _stack;  // 代表队列尾部
        readonly Steque<TItem> _steque;// 代表队列头部

        /// <summary>
        /// 创建一条空的双向队列。
        /// </summary>
        public Deque()
        {
            _stack = new Stack<TItem>();
            _steque = new Steque<TItem>();
        }

        /// <summary>
        /// 在左侧插入一个新元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushLeft(TItem item)
        {
            _steque.Push(item);
        }

        /// <summary>
        /// 将栈中的内容移动到 Steque 中。
        /// </summary>
        private void StackToSteque()
        {
            while (!_stack.IsEmpty())
            {
                _steque.Push(_stack.Pop());
            }
        }

        /// <summary>
        /// 将 Steque 中的内容移动到栈中。
        /// </summary>
        private void StequeToStack()
        {
            while (!_steque.IsEmpty())
            {
                _stack.Push(_steque.Pop());
            }
        }

        /// <summary>
        /// 从双向队列左侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem PopLeft()
        {
            if (_steque.IsEmpty())
            {
                StackToSteque();
            }
            return _steque.Pop();
        }

        /// <summary>
        /// 向双向队列右侧添加一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushRight(TItem item)
        {
            if (_stack.IsEmpty())
            {
                _steque.Enqueue(item);
            }
            else
            {
                _stack.Push(item);
            }
        }

        /// <summary>
        /// 从双向队列右侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem PopRight()
        {
            if (_stack.IsEmpty())
            {
                StequeToStack();
            }
            return _stack.Pop();
        }

        /// <summary>
        /// 判断队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _stack.IsEmpty() && _steque.IsEmpty();
        }

        /// <summary>
        /// 返回队列中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _stack.Size() + _steque.Size();
        }
    }
}
