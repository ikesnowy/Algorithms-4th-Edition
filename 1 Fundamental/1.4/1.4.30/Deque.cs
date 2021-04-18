namespace _1._4._30
{
    /// <summary>
    /// 用一个栈和一个 Steque 模拟的双向队列。
    /// </summary>
    /// <typeparam name="Item">双向队列中保存的元素类型。</typeparam>
    class Deque<Item>
    {
        readonly Stack<Item> stack;  // 代表队列尾部
        readonly Steque<Item> steque;// 代表队列头部

        /// <summary>
        /// 创建一条空的双向队列。
        /// </summary>
        public Deque()
        {
            stack = new Stack<Item>();
            steque = new Steque<Item>();
        }

        /// <summary>
        /// 在左侧插入一个新元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushLeft(Item item)
        {
            steque.Push(item);
        }

        /// <summary>
        /// 将栈中的内容移动到 Steque 中。
        /// </summary>
        private void StackToSteque()
        {
            while (!stack.IsEmpty())
            {
                steque.Push(stack.Pop());
            }
        }

        /// <summary>
        /// 将 Steque 中的内容移动到栈中。
        /// </summary>
        private void StequeToStack()
        {
            while (!steque.IsEmpty())
            {
                stack.Push(steque.Pop());
            }
        }

        /// <summary>
        /// 从双向队列左侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopLeft()
        {
            if (steque.IsEmpty())
            {
                StackToSteque();
            }
            return steque.Pop();
        }

        /// <summary>
        /// 向双向队列右侧添加一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushRight(Item item)
        {
            if (stack.IsEmpty())
            {
                steque.Enqueue(item);
            }
            else
            {
                stack.Push(item);
            }
        }

        /// <summary>
        /// 从双向队列右侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopRight()
        {
            if (stack.IsEmpty())
            {
                StequeToStack();
            }
            return stack.Pop();
        }

        /// <summary>
        /// 判断队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return stack.IsEmpty() && steque.IsEmpty();
        }

        /// <summary>
        /// 返回队列中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return stack.Size() + steque.Size();
        }
    }
}
