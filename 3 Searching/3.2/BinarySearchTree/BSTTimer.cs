using System;
using System.Diagnostics;

namespace BinarySearchTree
{
    public class BstTimer<TKey, TValue> : Bst<TKey, TValue> where TKey : IComparable<TKey>
    {
        public long PutTime { get; set; }
        public long SetTime { get; set; }

        /// <summary>
        /// 向二叉查找树中插入一个键值对。
        /// </summary>
        /// <param name="key">要插入的键。</param>
        /// <param name="value">要插入的值。</param>
        public override void Put(TKey key, TValue value)
        {
            var timer = Stopwatch.StartNew();
            base.Put(key, value);
            timer.Stop();
            PutTime += timer.ElapsedMilliseconds;
        }

        /// <summary>
        /// 获得 <paramref name="key"/> 对应的值，不存在则返回 <c>default(TValue)</c>。
        /// </summary>
        /// <param name="key">需要查找的键。</param>
        /// <returns>找到的值，不存在则返回 <c>default(TValue)</c>。</returns>
        public override TValue Get(TKey key)
        {
            var timer = Stopwatch.StartNew();
            var result = base.Get(key);
            timer.Stop();
            SetTime += timer.ElapsedMilliseconds;
            return result;
        }
    }
}