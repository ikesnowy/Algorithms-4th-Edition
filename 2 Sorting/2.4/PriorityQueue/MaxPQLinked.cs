using System;

namespace PriorityQueue
{
    /// <summary>
    /// 基于链式结构实现的最大堆。
    /// </summary>
    /// <typeparam name="Key">优先队列中保存的数据类型。</typeparam>
    public class MaxPqLinked<TKey> : IMaxPq<TKey> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 二叉堆的根结点。
        /// </summary>
        private TreeNode<TKey> _root;
        /// <summary>
        /// 二叉堆的最后一个结点。
        /// </summary>
        private TreeNode<TKey> _last;
        /// <summary>
        /// 二叉堆中的结点个数。
        /// </summary>
        private int _nodesCount;

        /// <summary>
        /// 删除并返回最大值。
        /// </summary>
        /// <returns>最大值。</returns>
        /// <remarks>如果希望获得最大值而不删除它，请使用 <see cref="Max"/>。</remarks>
        public TKey DelMax()
        {
            var result = _root.Value;
            Exch(_root, _last);

            if (_nodesCount == 2)
            {
                _root.Left = null;
                _last = _root;
                _nodesCount--;
                return result;
            }
            else if (_nodesCount == 1)
            {
                _last = null;
                _root = null;
                _nodesCount--;
                return result;
            }

            // 获得前一个结点。
            var newLast = _last;
            if (newLast == _last.Prev.Right)
                newLast = _last.Prev.Left;
            else
            {
                // 找到上一棵子树。
                while (newLast != _root)
                {
                    if (newLast != newLast.Prev.Left)
                        break;
                    newLast = newLast.Prev;
                }

                // 已经是满二叉树。
                if (newLast == _root)
                {
                    // 一路向右，回到上一层。
                    while (newLast.Right != null)
                        newLast = newLast.Right;
                }
                // 不是满二叉树。
                else
                {
                    // 向左子树移动，再一路向右。
                    newLast = newLast.Prev.Left;
                    while (newLast.Right != null)
                        newLast = newLast.Right;
                }
            }

            // 删除最后一个结点。
            if (_last.Prev.Left == _last)
                _last.Prev.Left = null;
            else
                _last.Prev.Right = null;

            Sink(_root);

            // 指向新的最后一个结点。
            _last = newLast;
            _nodesCount--;
            return result;
        }

        /// <summary>
        /// 插入一个新的结点。
        /// </summary>
        /// <param name="v">待插入的结点。</param>
        public void Insert(TKey v)
        {
            var item = new TreeNode<TKey>(v);
            // 堆为空。
            if (_last == null)
            {
                _root = item;
                _last = item;
                _nodesCount++;
                return;
            }
            
            // 堆只有一个结点。
            if (_last == _root)
            {
                item.Prev = _root;
                _root.Left = item;
                _last = item;
                _nodesCount++;
                Swim(item);
                return;
            }

            // 定位到最后一个节点的父结点。
            var prev = _last.Prev;

            // 右子节点为空，插入到右子节点。
            if (prev.Right == null)
            {
                item.Prev = prev;
                prev.Right = item;
            }
            else
            {
                // 当前子树已满，需要向上回溯。
                // 找到下一个子树（回溯的时候是从左子树回溯上去的）。
                while (prev != _root)
                {
                    if (prev != prev.Prev.Right)
                        break;
                    prev = prev.Prev;
                }

                // 已经是满二叉树。
                if (prev == _root)
                {
                    // 一路向左，进入下一层。
                    while (prev.Left != null)
                        prev = prev.Left;

                    item.Prev = prev;
                    prev.Left = item;
                }
                // 不是满二叉树。
                else
                {
                    // 向右子树移动，再一路向左。
                    prev = prev.Prev.Right;
                    while (prev.Left != null)
                        prev = prev.Left;

                    item.Prev = prev;
                    prev.Left = item;
                }
            }

            _last = item;
            _nodesCount++;
            Swim(item);
            return;
        }

        /// <summary>
        /// 返回二叉堆是否为空。
        /// </summary>
        /// <returns>如果为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => _root == null;

        /// <summary>
        /// 返回二叉堆中的最大值。
        /// </summary>
        /// <returns>堆中的最大值。</returns>
        /// <remarks>如果希望删除并返回最大元素，请使用 <see cref="DelMax"/>。</remarks>
        public TKey Max() => _root.Value;

        /// <summary>
        /// 返回二叉堆中的元素个数。
        /// </summary>
        /// <returns>堆中元素数量。</returns>
        public int Size() => _nodesCount;

        /// <summary>
        /// 使结点上浮。
        /// </summary>
        /// <param name="k">需要上浮的结点。</param>
        private void Swim(TreeNode<TKey> k)
        {
            while (k.Prev != null)
            {
                if (Less(k.Prev, k))
                {
                    Exch(k.Prev, k);
                    k = k.Prev;
                }
                else
                    break;
            }
        }

        /// <summary>
        /// 使结点下沉。
        /// </summary>
        /// <param name="k">需要下沉的结点。</param>
        private void Sink(TreeNode<TKey> k)
        {
            while (k.Left != null || k.Right != null)
            {
                TreeNode<TKey> toExch = null;
                if (k.Left != null && k.Right != null)
                    toExch = Less(k.Left, k.Right) ? k.Right : k.Left;
                else if (k.Left != null)
                    toExch = k.Left;
                else
                    toExch = k.Right;

                if (Less(k, toExch))
                    Exch(k, toExch);
                else
                    break;
                k = toExch;
            }
        }

        /// <summary>
        /// 交换二叉堆中的两个结点。
        /// </summary>
        /// <param name="a">要交换的第一个结点。</param>
        /// <param name="b">要交换的第二个结点。</param>
        private void Exch(TreeNode<TKey> a, TreeNode<TKey> b)
        {
            var temp = a.Value;
            a.Value = b.Value;
            b.Value = temp;
        }

        /// <summary>
        /// 比较第一个结点值的是否小于第二个。
        /// </summary>
        /// <param name="a">判断是否较小的结点。</param>
        /// <param name="b">判断是否较大的结点。</param>
        /// <returns>如果 <paramref name="a"/> 较小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Less(TreeNode<TKey> a, TreeNode<TKey> b)
            => a.Value.CompareTo(b.Value) < 0;
    }
}
