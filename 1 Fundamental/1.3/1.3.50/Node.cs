namespace _1._3._50
{
    /// <summary>
    /// 链表结点类。
    /// </summary>
    /// <typeparam name="T">结点中保存的元素。</typeparam>
    public class Node<T>
    {
        public T Item;
        public Node<T> Next;

        public Node() { }

        public Node(Node<T> node)
        {
            Item = node.Item;
            Next = node.Next;
        }
    }
}
