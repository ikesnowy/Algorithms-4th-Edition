using System;

namespace PriorityQueue
{
    /// <summary>
    /// 元素保持输入顺序的优先队列。（基于链表）
    /// </summary>
    /// <typeparam name="Key">优先队列中的元素类型。</typeparam>
    public class OrderedLinkedMaxPq<TKey> : IMaxPq<TKey> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 用于保存元素的链表。
        /// </summary>
        private readonly LinkedList<TKey> _pq;

        /// <summary>
        /// 默认构造函数，建立一条优先队列。
        /// </summary>
        public OrderedLinkedMaxPq()
        {
            _pq = new LinkedList<TKey>();
        }

        /// <summary>
        /// 向优先队列中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(TKey v)
        {
            var i = _pq.Size() - 1;
            while (i >= 0 && Less(v, _pq.Find(i)))
                i--;
            _pq.Insert(v, i + 1);
        }

        /// <summary>
        /// 返回并删除优先队列中的最大值。
        /// </summary>
        /// <returns>优先队列中的最大值。</returns>
        /// <remarks>如果希望获得最大值而不删除它，请使用 <see cref="Max"/>。</remarks>
        public TKey DelMax() => _pq.Delete(_pq.Size() - 1);

        /// <summary>
        /// 检查优先队列是否为空。
        /// </summary>
        /// <returns>如果为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => _pq.IsEmpty();

        /// <summary>
        /// 获得（但不删除）优先队列中的最大元素。
        /// </summary>
        /// <returns>优先队列中的最大元素。</returns>
        /// <remarks>如果希望获得并删除最大元素，请使用 <see cref="DelMax"/>。</remarks>
        public TKey Max() => _pq.Find(_pq.Size() - 1);

        /// <summary>
        /// 检查优先队列中含有的元素数量。
        /// </summary>
        /// <returns>优先队列中的元素数量。</returns>
        public int Size() => _pq.Size();

        /// <summary>
        /// 比较第一个元素是否小于第二个元素。
        /// </summary>
        /// <param name="a">第一个元素。</param>
        /// <param name="b">第二个元素。</param>
        /// <returns>如果 <paramref name="a"/> 较小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Less(TKey a, TKey b) => a.CompareTo(b) < 0;
    }
}
