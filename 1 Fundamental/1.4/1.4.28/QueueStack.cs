namespace _1._4._28
{
    /// <summary>
    /// 用一条队列模拟的栈。
    /// </summary>
    /// <typeparam name="Item">栈中保存的元素。</typeparam>
    class QueueStack<Item>
    {
        readonly Queue<Item> queue;

        /// <summary>
        /// 初始化一个栈。
        /// </summary>
        public QueueStack()
        {
            queue = new Queue<Item>();
        }

        /// <summary>
        /// 向栈中添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Push(Item item)
        {
            queue.Enqueue(item);
            var size = queue.Size();
            // 倒转队列
            for (var i = 0; i < size - 1; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        /// <summary>
        /// 从栈中弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            return queue.Dequeue();
        }

        /// <summary>
        /// 确定栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return queue.IsEmpty();
        }
    }
}
