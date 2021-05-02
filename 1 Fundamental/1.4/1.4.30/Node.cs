namespace _1._4._30
{
    /// <summary>
    /// 链表结点类。
    /// </summary>
    /// <typeparam name="T">结点中存放的元素类型。</typeparam>
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
