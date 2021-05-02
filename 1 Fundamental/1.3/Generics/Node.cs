namespace Generics
{
    /// <summary>
    /// 链表结点类。
    /// </summary>
    /// <typeparam name="T">结点存放的元素类型。</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// 结点中存放的元素。
        /// </summary>
        /// <value>结点中存放的元素。</value>
        public T Item;
        /// <summary>
        /// 下一个结点的引用。
        /// </summary>
        /// <value>下一个结点的引用。</value>
        public Node<T> Next;

        /// <summary>
        /// 默认无参构造器。
        /// </summary>
        public Node() { }

        /// <summary>
        /// 复制构造器。
        /// </summary>
        /// <param name="node">要复制的结点。</param>
        public Node(Node<T> node)
        {
            Item = node.Item;
            Next = node.Next;
        }
    }
}
