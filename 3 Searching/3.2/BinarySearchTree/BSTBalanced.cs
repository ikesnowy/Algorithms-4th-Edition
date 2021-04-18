using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BstBalanced<TKey, TValue> : Bst<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 构造一棵平衡的二叉搜索树。
        /// </summary>
        /// <param name="init">初始键值对。</param>
        public BstBalanced(KeyValuePair<TKey, TValue>[] init)
        {
            Array.Sort(init, (left, right) => left.Key.CompareTo(right.Key));
            root = BuildTree(init, 0, init.Length - 1);
        }

        /// <summary>
        /// 根据给定的中序序列递归地构造一棵平衡的二叉搜索树。
        /// </summary>
        /// <param name="init">有序键值对。</param>
        /// <param name="lo">构造范围的下标最小值。</param>
        /// <param name="hi">构造范围的下标最大值。</param>
        /// <returns>构造完毕后二叉搜索树的根结点。</returns>
        private Node BuildTree(KeyValuePair<TKey, TValue>[] init, int lo, int hi)
        {
            if (lo > hi)
            {
                return null;
            }

            var mid = (hi - lo) / 2 + lo;
            var current = new Node(init[mid].Key, init[mid].Value, 1);
            current.Left = BuildTree(init, lo, mid - 1);
            current.Right = BuildTree(init, mid + 1, hi);
            if (current.Left != null)
            {
                current.Size += current.Left.Size;
            }

            if (current.Right != null)
            {
                current.Size += current.Right.Size;
            }
            return current;
        }
    }
}