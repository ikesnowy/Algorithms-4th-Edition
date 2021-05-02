using System;
// ReSharper disable CognitiveComplexity

namespace BinarySearchTree
{
    public class BstNonHibbard<TKey, TValue> : Bst<TKey, TValue> where TKey : IComparable<TKey>
    {
        private readonly Random _random = new();

        /// <summary>
        /// 从二叉查找树中删除键为 <paramref name="key"/> 的结点。
        /// </summary>
        /// <param name="x">要删除的结点的二叉查找树。</param>
        /// <param name="key">要删除的键。</param>
        /// <returns>删除结点后的二叉查找树。</returns>
        protected override Node Delete(Node x, TKey key)
        {
            if (x == null)
            {
                return null;
            }

            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
            {
                x.Left = Delete(x.Left, key);
            }
            else if (cmp > 0)
            {
                x.Right = Delete(x.Right, key);
            }
            else
            {
                if (x.Right == null)
                {
                    return x.Left;
                }

                if (x.Left == null)
                {
                    return x.Right;
                }
                var t = x;
                if (_random.NextDouble() < 0.5)
                {
                    x = Min(t.Right);
                    x.Right = DeleteMin(t.Right);
                    x.Left = t.Left;
                }
                else
                {
                    x = Max(t.Left);
                    x.Left = DeleteMax(t.Left);
                    x.Right = t.Right;
                }
            }
            x.Size = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }


    }
}