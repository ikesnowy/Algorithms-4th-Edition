namespace _1._4._31
{
    /// <summary>
    /// 用三个栈模拟的双向队列。
    /// </summary>
    /// <typeparam name="Item">双向队列中的元素。</typeparam>
    class Deque<Item>
    {
        readonly Stack<Item> left;
        readonly Stack<Item> middle;
        readonly Stack<Item> right;

        /// <summary>
        /// 构造一条新的双向队列。
        /// </summary>
        public Deque()
        {
            left = new Stack<Item>();
            middle = new Stack<Item>();
            right = new Stack<Item>();
        }

        /// <summary>
        /// 向双向队列左侧插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushLeft(Item item)
        {
            left.Push(item);
        }

        /// <summary>
        /// 向双向队列右侧插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushRight(Item item)
        {
            right.Push(item);
        }

        /// <summary>
        /// 当一侧栈为空时，将另一侧的下半部分元素移动过来。
        /// </summary>
        /// <param name="source">不为空的栈。</param>
        /// <param name="destination">空栈。</param>
        private void Move(Stack<Item> source, Stack<Item> destination) 
        {
            var n = source.Size();
            // 将上半部分元素移动到临时栈 middle
            for (var i = 0; i < n / 2; i++)
            {
                middle.Push(source.Pop());
            }
            // 将下半部分移动到另一侧栈中
            while (!source.IsEmpty())
            {
                destination.Push(source.Pop());
            }
            // 从 middle 取回上半部分元素
            while (!middle.IsEmpty())
            {
                source.Push(middle.Pop());
            }
        }

        /// <summary>
        /// 检查双端队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return right.IsEmpty() && middle.IsEmpty() && left.IsEmpty();
        }

        /// <summary>
        /// 从右侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopRight()
        {
            if (right.IsEmpty())
            {
                Move(left, right);
            }

            return right.Pop();
        }

        /// <summary>
        /// 从左侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopLeft()
        {
            if (left.IsEmpty())
            {
                Move(right, left);
            }

            return left.Pop();
        }

        /// <summary>
        /// 返回双端队列的大小。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return left.Size() + middle.Size() + right.Size();
        }
    }
}
