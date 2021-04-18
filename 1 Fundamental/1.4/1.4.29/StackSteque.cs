namespace _1._4._29
{
    /// <summary>
    /// 用两个栈模拟的 Steque。
    /// </summary>
    /// <typeparam name="Item">Steque 中的元素类型。</typeparam>
    class StackSteque<Item>
    {
        readonly Stack<Item> H;
        readonly Stack<Item> T;

        /// <summary>
        /// 初始化一个 Steque
        /// </summary>
        public StackSteque()
        {
            H = new Stack<Item>();
            T = new Stack<Item>();
        }

        /// <summary>
        /// 向栈中添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Push(Item item)
        {
            ReverseT();
            H.Push(item);
        }

        /// <summary>
        /// 将 T 中的元素弹出并压入到 H 中。
        /// </summary>
        private void ReverseT()
        {
            while (!T.IsEmpty())
            {
                H.Push(T.Pop());
            }
        }

        /// <summary>
        /// 将 H 中的元素弹出并压入到 T 中。
        /// </summary>
        private void ReverseH()
        {
            while (!H.IsEmpty())
            {
                T.Push(H.Pop());
            }
        }

        /// <summary>
        /// 从 Steque 中弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            ReverseT();
            return H.Pop();
        }

        /// <summary>
        /// 在 Steque 尾部添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(Item item)
        {
            ReverseH();
            T.Push(item);
        }

        /// <summary>
        /// 检查 Steque 是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return H.IsEmpty() && T.IsEmpty();
        }
    }
}
