using System;

namespace BinarySearchTree
{
    public class BstRandomKey<TKey, TValue> : Bst<TKey, TValue> where TKey : IComparable<TKey>
    {
        private readonly Random _random = new();

        /// <summary>
        /// 从树中随机返回一个键。
        /// </summary>
        /// <returns>树中的某一个键值。</returns>
        public TKey RandomKey()
        {
            var rank = _random.Next(1, Size() + 1);
            return GetKeyWithRank(Root, rank);
        }

        /// <summary>
        /// 获取排名为 <paramref name="rank"/> 的结点。
        /// </summary>
        /// <param name="x">搜寻开始的结点。</param>
        /// <param name="rank">要搜寻的排名。</param>
        /// <returns>排名为 <paramref name="rank"/> 的结点。</returns>
        private TKey GetKeyWithRank(Node x, int rank)
        {
            var left = (x.Left == null ? 0 : x.Left.Size) + 1;  // 加上结点本身。
            if (left > rank)
            {
                return GetKeyWithRank(x.Left, rank);
            }
            else if (left == rank)
            {
                return x.Key;
            }
            else
            {
                return GetKeyWithRank(x.Right, rank - left);
            }
        }
    }
}