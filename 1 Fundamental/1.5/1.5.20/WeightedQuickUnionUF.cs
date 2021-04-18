using System;

namespace _1._5._20
{
    /// <summary>
    /// 使用加权 quick-union 算法的并查集。
    /// </summary>
    public class WeightedQuickUnionUf
    {
        protected LinkedList<int> parent;       // 记录各个结点的父级。
        protected LinkedList<int> size;         // 记录各个树的大小。
        protected int count;                    // 分量数目。

        /// <summary>
        /// 建立使用加权 quick-union 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public WeightedQuickUnionUf()
        {
            parent = new LinkedList<int>();
            size = new LinkedList<int>();
        }

        /// <summary>
        /// 获取 parent 数组。
        /// </summary>
        /// <returns>parent 数组。</returns>
        public LinkedList<int> GetParent()
        {
            return parent;
        }

        /// <summary>
        /// 获取 size 数组。
        /// </summary>
        /// <returns>返回 size 数组。</returns>
        public LinkedList<int> GetSize()
        {
            return size;
        }

        /// <summary>
        /// 在并查集中增加一个新的结点。
        /// </summary>
        /// <returns>新结点的下标。</returns>
        public int NewSite()
        {
            parent.Insert(parent.Size(), parent.Size());
            size.Insert(1, size.Size());
            count++;
            return parent.Size() - 1;
        }

        /// <summary>
        /// 寻找一个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>该结点所属的连通分量。</returns>
        public int Find(int p)
        {
            Validate(p);
            while (p != parent.Find(p))
            {
                p = parent.Find(p);
            }
            return p;
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public void Union(int p, int q)
        {
            var rootP = Find(p);
            var rootQ = Find(q);
            if (rootP == rootQ)
            {
                return;
            }

            if (size.Find(rootP) < size.Find(rootQ))
            {
                parent.Motify(rootP, rootQ);
                size.Motify(rootQ, size.Find(rootQ) + size.Find(rootP));
            }
            else
            {
                parent.Motify(rootQ, rootP);
                size.Motify(rootP, size.Find(rootQ) + size.Find(rootP));
            }
            count--;
        }

        /// <summary>
        /// 检查输入的 p 是否符合条件。
        /// </summary>
        /// <param name="p">输入的 p 值。</param>
        protected void Validate(int p)
        {
            var n = parent.Size();
            if (p < 0 || p >= n)
            {
                throw new ArgumentException("index" + p + " is not between 0 and " + (n - 1));
            }
        }
    }
}
