using System;
using System.Collections.Generic;

namespace BalancedSearchTree
{
    /// <summary>
    /// 有序符号表 API。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public interface IOrderedSt<TKey, TValue> : ISt<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// [<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns>[<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。</returns>
        int Size(TKey lo, TKey hi);

        /// <summary>
        /// 获得符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns>符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。</returns>
        IEnumerable<TKey> Keys(TKey lo, TKey hi);

        /// <summary>
        /// 最小的键。
        /// </summary>
        /// <returns>最小的键。</returns>
        TKey Min();

        /// <summary>
        /// 最大的键。
        /// </summary>
        /// <returns>最大的键。</returns>
        TKey Max();

        /// <summary>
        /// 小于等于 <paramref name="key"/> 的最大值。
        /// </summary>
        /// <returns>小于等于 <paramref name="key"/> 的最大值。</returns>
        TKey Floor(TKey key);

        /// <summary>
        /// 大于等于 <paramref name="key"/> 的最小值。
        /// </summary>
        /// <returns>大于等于 <paramref name="key"/> 的最小值。</returns>
        TKey Ceiling(TKey key);

        /// <summary>
        /// 小于 <paramref name="key"/> 的键的数量。
        /// </summary>
        /// <returns>小于 <paramref name="key"/> 的键的数量。</returns>
        int Rank(TKey key);

        /// <summary>
        /// 获得排名为 k 的键。
        /// </summary>
        /// <param name="k">需要获得的键的排名。</param>
        /// <returns>排名为 k 的键。</returns>
        TKey Select(int k);

        /// <summary>
        /// 删除最小的键。
        /// </summary>
        void DeleteMin();

        /// <summary>
        /// 删除最大的键。
        /// </summary>
        void DeleteMax();
    }
}
