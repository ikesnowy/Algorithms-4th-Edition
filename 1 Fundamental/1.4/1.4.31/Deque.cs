namespace _1._4._31
{
    /// <summary>
    /// 用三个栈模拟的双向队列。
    /// </summary>
    /// <typeparam name="Item">双向队列中的元素。</typeparam>
    class Deque<TItem>
    {
        readonly Stack<TItem> _left;
        readonly Stack<TItem> _middle;
        readonly Stack<TItem> _right;

        /// <summary>
        /// 构造一条新的双向队列。
        /// </summary>
        public Deque()
        {
            _left = new Stack<TItem>();
            _middle = new Stack<TItem>();
            _right = new Stack<TItem>();
        }

        /// <summary>
        /// 向双向队列左侧插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushLeft(TItem item)
        {
            _left.Push(item);
        }

        /// <summary>
        /// 向双向队列右侧插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushRight(TItem item)
        {
            _right.Push(item);
        }

        /// <summary>
        /// 当一侧栈为空时，将另一侧的下半部分元素移动过来。
        /// </summary>
        /// <param name="source">不为空的栈。</param>
        /// <param name="destination">空栈。</param>
        private void Move(Stack<TItem> source, Stack<TItem> destination) 
        {
            var n = source.Size();
            // 将上半部分元素移动到临时栈 middle
            for (var i = 0; i < n / 2; i++)
            {
                _middle.Push(source.Pop());
            }
            // 将下半部分移动到另一侧栈中
            while (!source.IsEmpty())
            {
                destination.Push(source.Pop());
            }
            // 从 middle 取回上半部分元素
            while (!_middle.IsEmpty())
            {
                source.Push(_middle.Pop());
            }
        }

        /// <summary>
        /// 检查双端队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _right.IsEmpty() && _middle.IsEmpty() && _left.IsEmpty();
        }

        /// <summary>
        /// 从右侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem PopRight()
        {
            if (_right.IsEmpty())
            {
                Move(_left, _right);
            }

            return _right.Pop();
        }

        /// <summary>
        /// 从左侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem PopLeft()
        {
            if (_left.IsEmpty())
            {
                Move(_right, _left);
            }

            return _left.Pop();
        }

        /// <summary>
        /// 返回双端队列的大小。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _left.Size() + _middle.Size() + _right.Size();
        }
    }
}
