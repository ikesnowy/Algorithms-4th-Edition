using System.Collections.Generic;

namespace BalancedSearchTree
{
    /// <summary>
    /// 有序符号表 API。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public interface IOrderedSt<TKey, TValue>
    {
        #region IST

        /// <summary>
        /// 向符号表插入键值对。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        void Put(TKey key, TValue value);

        /// <summary>
        /// 获取键 <paramref name="key"/> 对应的值，不存在则返回 null。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns><typeparamref name="TKey"/> 对应的值。</returns>
        TValue Get(TKey key);

        /// <summary>
        /// 从表中删去键 <paramref name="key"/> 对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        void Delete(TKey key);

        /// <summary>
        /// 键 <paramref name="key"/> 在表中是否存在对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>如果存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        bool Contains(TKey key);

        /// <summary>
        /// 符号表是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        bool IsEmpty();

        /// <summary>
        /// 获得符号表中键值对的数量。
        /// </summary>
        /// <returns>键值对数量。</returns>
        int Size();

        /// <summary>
        /// [<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns>[<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。</returns>
        int Size(TKey lo, TKey hi);

        /// <summary>
        /// 获得符号表中所有键的集合。
        /// </summary>
        /// <returns>全部键的集合。</returns>
        IEnumerable<TKey> Keys();

        /// <summary>
        /// 获得符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns>符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。</returns>
        IEnumerable<TKey> Keys(TKey lo, TKey hi);

        #endregion

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
