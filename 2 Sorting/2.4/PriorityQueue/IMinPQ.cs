using System;

namespace PriorityQueue
{
    /// <summary>
    /// 实现优先队列 API 的接口。（最小堆）
    /// </summary>
    /// <typeparam name="TKey">优先队列容纳的元素。</typeparam>
    public interface IMinPq<TKey> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 向优先队列中插入一个元素。
        /// </summary>
        /// <param name="v">插入元素的类型。</param>
        void Insert(TKey v);

        /// <summary>
        /// 返回最小元素。
        /// </summary>
        /// <returns>最小的元素。</returns>
        TKey Min();

        /// <summary>
        /// 删除并返回最小元素。
        /// </summary>
        /// <returns>最小的元素。</returns>
        TKey DelMin();

        /// <summary>
        /// 返回队列是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        bool IsEmpty();

        /// <summary>
        /// 返回队列中的元素个数。
        /// </summary>
        /// <returns>队列中的元素个数。</returns>
        int Size();
    }
}
