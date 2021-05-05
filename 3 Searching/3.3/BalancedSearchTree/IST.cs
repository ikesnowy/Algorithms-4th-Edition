using System;
using System.Collections.Generic;

namespace BalancedSearchTree
{
    /// <summary>
    /// 符号表 API。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public interface ISt<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 向符号表插入键值对。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        void Put(TKey key, TValue value);

        /// <summary>
        /// 获取键 <paramref name="key"/> 对应的值，不存在则返回 <c>default(Value)</c>。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>键 <paramref name="key"/> 对应的值，不存在则返回 <c>default(Value)</c>。</returns>
        TValue Get(TKey key);

        /// <summary>
        /// 从表中删去键 <paramref name="key"/> 及其对应的值。
        /// </summary>
        /// <param name="key">要删除的键。</param>
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
        /// <returns>符号表中键值对的数量。</returns>
        int Size();

        /// <summary>
        /// 获得符号表中所有键的集合。
        /// </summary>
        /// <returns>符号表中所有键的集合。</returns>
        IEnumerable<TKey> Keys();
    }
}
