using System;
using System.Collections.Generic;
using System.Drawing;

namespace _3._2._38
{
    public class BSTDrawing<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 二叉查找树的根结点。
        /// </summary>
        protected Node root;

        /// <summary>
        /// 二叉树结点类型。
        /// </summary>
        protected class Node
        {
            /// <summary>
            /// 键值对中的键。
            /// </summary>
            /// <value>
            /// 键。
            /// </value>
            public TKey Key { get; set; }
            /// <summary>
            /// 键值对中的值。
            /// </summary>
            /// <value>值。</value>
            public TValue Value { get; set; }
            /// <summary>
            /// 左子树的引用。
            /// </summary>
            /// <value>左子树的引用。</value>
            public Node Left { get; set; }
            /// <summary>
            /// 右子树的引用。
            /// </summary>
            /// <value>右子树的引用。</value>
            public Node Right { get; set; }
            /// <summary>
            /// 子树的结点数量。
            /// </summary>
            /// <value>子树的结点数量。</value>
            public int Size { get; set; }
            /// <summary>
            /// 结点的 X 位置。
            /// </summary>
            /// <value>结点的 X 位置。</value>
            public float X { get; set; }
            /// <summary>
            /// 结点的 Y 位置。
            /// </summary>
            /// <value>结点的 Y 位置。</value>
            public float Y { get; set; }

            /// <summary>
            /// 构造一个二叉树结点。
            /// </summary>
            /// <param name="key">键。</param>
            /// <param name="value">值。</param>
            /// <param name="size">子树大小。</param>
            public Node(TKey key, TValue value, int size)
            {
                Key = key;
                Value = value;
                Size = size;
                Left = null;
                Right = null;
            }
        }

        /// <summary>
        /// 向二叉查找树中插入一个键值对。
        /// </summary>
        /// <param name="key">要插入的键。</param>
        /// <param name="value">要插入的值。</param>
        public virtual void Put(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("calls Put() with a null key");
            if (value == null)
            {
                Delete(key);
                return;
            }
            root = Put(root, key, value);
        }

        /// <summary>
        /// 向二叉查找树中插入一个键值对，返回插入后的根结点。
        /// </summary>
        /// <param name="x">要插入结点的二叉查找树的根结点。</param>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        /// <returns>插入结点后的根结点。</returns>
        protected virtual Node Put(Node x, TKey key, TValue value)
        {
            if (x == null)
                return new Node(key, value, 1);
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Put(x.Left, key, value);
            else if (cmp > 0)
                x.Right = Put(x.Right, key, value);
            else
                x.Value = value;
            x.Size = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        /// <summary>
        /// 获得 <paramref name="key"/> 对应的值，不存在则返回 <c>default(TValue)</c>。
        /// </summary>
        /// <param name="key">需要查找的键。</param>
        /// <returns>找到的值，不存在则返回 <c>default(TValue)</c>。</returns>
        public virtual TValue Get(TKey key) => Get(root, key).Value;

        /// <summary>
        /// 递归查找 <paramref name="key"/> 所对应的结点。
        /// </summary>
        /// <param name="x">要查找的根结点。</param>
        /// <param name="key">要查找的键。</param>
        /// <returns>如果存在则返回对应的结点，否则返回 <c>default(TValue)</c>。</returns>
        protected virtual Node Get(Node x, TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("calls get() with a null key");
            if (x == null)
                return default;
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Get(x.Left, key);
            else if (cmp > 0)
                return Get(x.Right, key);
            else
                return x;
        }

        /// <summary>
        /// 删除含有某个键的结点。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
        public virtual void Delete(TKey key)
        {
            if (key == null)
                throw new InvalidOperationException("Symbol Table Underflow");
            root = Delete(root, key);
        }

        /// <summary>
        /// 从二叉查找树中删除键为 <paramref name="key"/> 的结点。
        /// </summary>
        /// <param name="x">要删除的结点的二叉查找树。</param>
        /// <param name="key">要删除的键。</param>
        /// <returns>删除结点后的二叉查找树。</returns>
        protected virtual Node Delete(Node x, TKey key)
        {
            if (x == null)
                return null;

            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Delete(x.Left, key);
            else if (cmp > 0)
                x.Right = Delete(x.Right, key);
            else
            {
                if (x.Right == null)
                    return x.Left;
                if (x.Left == null)
                    return x.Right;
                var t = x;
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }
            x.Size = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        /// <summary>
        /// 检查二叉查找树是否含有 <paramref name="key"/>。
        /// </summary>
        /// <param name="key">要查找的键值。</param>
        /// <returns>如果含有则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public virtual bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Contains is null!");
            var result = Get(key);
            if (default(TValue) != null)
            {
                return !EqualityComparer<TValue>.Default.Equals(result, default);
            }
            return result != null;
        }

        /// <summary>
        /// 二叉查找树是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public virtual bool IsEmpty() => Size(root) == 0;

        /// <summary>
        /// 获取二叉查找树的结点数量。
        /// </summary>
        /// <returns>二叉查找树的结点数量。</returns>
        public virtual int Size() => Size(root);

        /// <summary>
        /// 获取某个结点为根的二叉树结点数量。
        /// </summary>
        /// <param name="x">根结点。</param>
        /// <returns>以 <paramref name="x"/> 为根的二叉树的结点数量。</returns>
        protected virtual int Size(Node x)
        {
            if (x == null)
                return 0;
            return x.Size;
        }

        /// <summary>
        /// 获取符号表中键在 <paramref name="lo"/> 和 <paramref name="hi"/> 之间的键的数目。
        /// </summary>
        /// <param name="lo">键的下限。</param>
        /// <param name="hi">键的上限。</param>
        /// <returns><paramref name="lo"/> 和 <paramref name="hi"/> 之间键的数目。</returns>
        public virtual int Size(TKey lo, TKey hi)
        {
            if (lo == null)
                throw new ArgumentNullException("first argument to Size() is null");
            if (hi == null)
                throw new ArgumentNullException("second argument to Size() is null");

            if (lo.CompareTo(hi) > 0)
                return 0;
            if (Contains(hi))
                return Rank(hi) - Rank(lo) + 1;
            else
                return Rank(hi) - Rank(lo);
        }

        /// <summary>
        /// 获得二叉搜索树的高度。
        /// </summary>
        /// <returns>二叉搜索树的高度。</returns>
        public virtual int Height()
        {
            return Height(root);
        }

        /// <summary>
        /// 获得二叉搜索树的高度。
        /// </summary>
        /// <param name="x">二叉搜索树的根结点。</param>
        /// <returns>以 <paramref name="x"/> 为根结点的二叉树的高度。</returns>
        protected virtual int Height(Node x)
        {
            return x == null ? -1 : 1 + Math.Max(Height(x.Left), Height(x.Right));
        }

        /// <summary>
        /// 获得符号表全部的键。
        /// </summary>
        /// <returns>符号表全部的键。</returns>
        public virtual IEnumerable<TKey> Keys()
        {
            if (IsEmpty())
                return new List<TKey>();
            return Keys(Min(), Max());
        }

        /// <summary>
        /// 获取符号表中指定键之间的全部键。
        /// </summary>
        /// <param name="lo">键的下限。</param>
        /// <param name="hi">键的上限。</param>
        /// <returns>包含 <paramref name="lo"/> 和 <paramref name="hi"/> 及其之间的所有键。</returns>
        public virtual IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            if (lo == null)
                throw new ArgumentNullException("first argument to keys() is null");
            if (hi == null)
                throw new ArgumentNullException("second argument to keys() is null");

            var queue = new Queue<TKey>();
            Keys(root, queue, lo, hi);
            return queue;
        }

        /// <summary>
        /// 获取二叉查找树中在 <paramref name="lo"/> 和 <paramref name="hi"/> 之间的所有键。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="queue">要填充的队列。</param>
        /// <param name="lo">键的下限。</param>
        /// <param name="hi">键的上限。</param>
        protected virtual void Keys(Node x, Queue<TKey> queue, TKey lo, TKey hi)
        {
            if (x == null)
                return;
            var cmplo = lo.CompareTo(x.Key);
            var cmphi = hi.CompareTo(x.Key);
            if (cmplo < 0)
                Keys(x.Left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0)
                queue.Enqueue(x.Key);
            if (cmphi > 0)
                Keys(x.Right, queue, lo, hi);
        }

        /// <summary>
        /// 查找二叉查找树中的最小的键。
        /// </summary>
        /// <returns>二叉查找树中最小的键。</returns>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
        public virtual TKey Min()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Symbol Table Underflow");
            return Min(root).Key;
        }

        /// <summary>
        /// 在二叉查找树中查找包含最小键的结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>包含最小键的结点。</returns>
        protected virtual Node Min(Node x)
        {
            if (x.Left == null)
                return x;
            return Min(x.Left);
        }

        /// <summary>
        /// 查找二叉查找树中的最大的键。
        /// </summary>
        /// <returns>二叉查找树中最大的键。</returns>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
        public virtual TKey Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Symbol Table Underflow");
            return Max(root).Key;
        }

        /// <summary>
        /// 在二叉查找树中查找包含最大键的结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>包含最大键的结点。</returns>
        protected virtual Node Max(Node x)
        {
            if (x.Right == null)
                return x;
            return Max(x.Right);
        }

        /// <summary>
        /// 获得符号表中小于等于 <paramref name="key"/> 的最大键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>小于等于 <paramref name="key"/> 的最大键。</returns>
        public virtual TKey Floor(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to floor is null");
            if (IsEmpty())
                throw new InvalidOperationException("calls floor with empty symbol table");
            var x = Floor(root, key);
            if (x == null)
                return default;
            else
                return x.Key;
        }

        /// <summary>
        /// 获得符号表中小于等于 <paramref name="key"/> 的最大结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">键。</param>
        /// <returns>小于等于 <paramref name="key"/> 的最大结点。</returns>
        protected virtual Node Floor(Node x, TKey key)
        {
            if (x == null)
                return null;
            var cmp = key.CompareTo(x.Key);
            if (cmp == 0)
                return x;
            else if (cmp < 0)
                return Floor(x.Left, key);
            var t = Floor(x.Right, key);
            if (t != null)
                return t;
            else
                return x;
        }

        /// <summary>
        /// 获取符号表中大于等于 <paramref name="key"/> 的最小键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>大于等于 <paramref name="key"/> 的最小键。</returns>
        public virtual TKey Ceiling(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to ceiling is null");
            if (IsEmpty())
                throw new InvalidOperationException("calls ceiling with empty symbol table");
            var x = Ceiling(root, key);
            if (x == null)
                return default;
            return x.Key;
        }

        /// <summary>
        /// 获取符号表中大于等于 <paramref name="key"/> 的最小结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">键。</param>
        /// <returns>符号表中大于等于 <paramref name="key"/> 的最小结点。</returns>
        protected virtual Node Ceiling(Node x, TKey key)
        {
            if (x == null)
                return null;
            var cmp = key.CompareTo(x.Key);
            if (cmp == 0)
                return x;
            if (cmp < 0)
            {
                var t = Ceiling(x.Left, key);
                if (t != null)
                    return t;
                return x;
            }
            return Ceiling(x.Right, key);
        }

        /// <summary>
        /// 返回 <paramref name="key"/> 在符号表中的排名。
        /// </summary>
        /// <param name="key">要排名的键。</param>
        /// <returns><paramref name="key"/> 的排名。</returns>
        public virtual int Rank(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to rank() is null");
            return Rank(root, key);
        }

        /// <summary>
        /// 返回 <paramref name="key"/> 在二叉查找树中的排名。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <param name="key">要查找排名的键。</param>
        /// <returns><paramref name="key"/> 的排名。</returns>
        protected virtual int Rank(Node x, TKey key)
        {
            if (x == null)
                return 0;
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Rank(x.Left, key);
            else if (cmp > 0)
                return 1 + Size(x.Left) + Rank(x.Right, key);
            else
                return Size(x.Left);
        }

        /// <summary>
        /// 挑拣出排名为 <paramref name="k"/> 的键。
        /// </summary>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>排名为 <paramref name="k"/> 的键。</returns>
        public virtual TKey Select(int k)
        {
            if (k < 0 || k >= Size())
                throw new ArgumentException("argument to select() is invaild: " + k);
            var x = Select(root, k);
            return x.Key;
        }

        /// <summary>
        /// 挑拣出排名为 <paramref name="k"/> 的结点。
        /// </summary>
        /// <param name="x">树的根结点。</param>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>排名为 <paramref name="k"/> 的结点。</returns>
        protected virtual Node Select(Node x, int k)
        {
            if (x == null)
                return null;
            var t = Size(x.Left);
            if (t > k)
                return Select(x.Left, k);
            else if (t < k)
                return Select(x.Right, k - t - 1);
            else
                return x;
        }

        /// <summary>
        /// 删除二叉查找树中最小的结点。
        /// </summary>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
        public virtual void DeleteMin()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Symbol table underflow");
            root = DeleteMin(root);
        }

        /// <summary>
        /// 在以 <paramref name="x"/> 为根结点的二叉查找树中删除最小结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>删除后的二叉查找树。</returns>
        protected virtual Node DeleteMin(Node x)
        {
            if (x.Left == null)
                return x.Right;
            x.Left = DeleteMin(x.Left);
            x.Size = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        /// <summary>
        /// 删除二叉查找树中最大的结点。
        /// </summary>
        /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出该异常。</exception>
        public virtual void DeleteMax()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Symbol Table Underflow");
            root = DeleteMax(root);
        }

        /// <summary>
        /// 从指定二叉查找树中删除最大结点。
        /// </summary>
        /// <param name="x">二叉查找树的根结点。</param>
        /// <returns>删除后的二叉查找树。</returns>
        protected virtual Node DeleteMax(Node x)
        {
            if (x.Right == null)
                return x.Left;
            x.Right = DeleteMax(x.Right);
            x.Size = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        /// <summary>
        /// 获取二叉树的最大深度。
        /// </summary>
        /// <param name="x">二叉树的根结点。</param>
        /// <returns>二叉树的最大深度。</returns>
        private int Depth(Node x)
        {
            if (x == null)
                return 0;
            return 1 + Math.Max(Depth(x.Left), Depth(x.Right));
        }

        /// <summary>
        /// 在指定区域中绘制二叉树。
        /// </summary>
        /// <param name="pen">绘制面。</param>
        /// <param name="panel">绘制矩形。</param>
        public void DrawTree(Graphics pen, RectangleF panel)
        {
            var depth = Depth(root);
            var layerHeight = panel.Height / depth;
            // BFS
            var nowLayer = new Queue<Node>();
            var nextLayer = new Queue<Node>();
            nextLayer.Enqueue(root);

            for (var layer = 0; layer != depth; layer++)
            {
                var unitSizeX = (float)(panel.Width / Math.Pow(2, layer));
                var temp = nowLayer;
                nowLayer = nextLayer;
                nextLayer = temp;

                var cursorX = 0.0f;
                var cursorY = layer * layerHeight;
                while (nowLayer.Count != 0)
                {
                    var node = nowLayer.Dequeue();

                    if (node != null)
                    {
                        nextLayer.Enqueue(node.Left);
                        nextLayer.Enqueue(node.Right);
                    }
                    else
                    {
                        nextLayer.Enqueue(null);
                        nextLayer.Enqueue(null);
                    }


                    if (node != null)
                    {
                        node.X = cursorX + unitSizeX / 2.0f;
                        node.Y = cursorY;
                    }
                    
                    cursorX += unitSizeX;
                }
            }

            // Draw
            DrawTree(root, pen);
        }

        /// <summary>
        /// 递归的根据结点坐标绘制二叉树。
        /// </summary>
        /// <param name="node">根结点。</param>
        /// <param name="pen">绘图 <see cref="Graphics"/></param>
        private void DrawTree(Node node, Graphics pen)
        {
            const int pointRadius = 16;
            var pointEdge = new Pen(Color.OrangeRed, 3);
            var line = new Pen(Color.Black, 3);
            var font = new Font(FontFamily.GenericMonospace, 12);
            pen.DrawEllipse(pointEdge, node.X, node.Y, pointRadius * 2, pointRadius * 2);
            pen.DrawString(node.Key.ToString(), font, Brushes.Black, node.X, node.Y);
            if (node.Left != null)
            {
                pen.DrawLine(line, node.X, node.Y + pointRadius * 2, node.Left.X + pointRadius * 2, node.Left.Y);
                DrawTree(node.Left, pen);
            }

            if (node.Right != null)
            {
                pen.DrawLine(line, node.X + pointRadius * 2, node.Y + pointRadius * 2, node.Right.X, node.Right.Y);
                DrawTree(node.Right, pen);
            }
            pointEdge.Dispose();
            line.Dispose();
            font.Dispose();
        }
    }
}