namespace _1._4._29
{
    /// <summary>
    /// 用两个栈模拟的 Steque。
    /// </summary>
    /// <typeparam name="Item">Steque 中的元素类型。</typeparam>
    class StackSteque<TItem>
    {
        readonly Stack<TItem> _h;
        readonly Stack<TItem> _;

        /// <summary>
        /// 初始化一个 Steque
        /// </summary>
        public StackSteque()
        {
            _h = new Stack<TItem>();
            _ = new Stack<TItem>();
        }

        /// <summary>
        /// 向栈中添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Push(TItem item)
        {
            ReverseT();
            _h.Push(item);
        }

        /// <summary>
        /// 将 T 中的元素弹出并压入到 H 中。
        /// </summary>
        private void ReverseT()
        {
            while (!_.IsEmpty())
            {
                _h.Push(_.Pop());
            }
        }

        /// <summary>
        /// 将 H 中的元素弹出并压入到 T 中。
        /// </summary>
        private void ReverseH()
        {
            while (!_h.IsEmpty())
            {
                _.Push(_h.Pop());
            }
        }

        /// <summary>
        /// 从 Steque 中弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public TItem Pop()
        {
            ReverseT();
            return _h.Pop();
        }

        /// <summary>
        /// 在 Steque 尾部添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(TItem item)
        {
            ReverseH();
            _.Push(item);
        }

        /// <summary>
        /// 检查 Steque 是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _h.IsEmpty() && _.IsEmpty();
        }
    }
}
