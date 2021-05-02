using System;

namespace _1._5._20
{
    /// <summary>
    /// 使用加权 quick-union 算法的并查集。
    /// </summary>
    public class WeightedQuickUnionUf
    {
        protected LinkedList<int> Parent;       // 记录各个结点的父级。
        protected LinkedList<int> Size;         // 记录各个树的大小。
        protected int Count;                    // 分量数目。

        /// <summary>
        /// 建立使用加权 quick-union 的并查集。
        /// </summary>
        public WeightedQuickUnionUf()
        {
            Parent = new LinkedList<int>();
            Size = new LinkedList<int>();
        }

        /// <summary>
        /// 获取 parent 数组。
        /// </summary>
        /// <returns>parent 数组。</returns>
        public LinkedList<int> GetParent()
        {
            return Parent;
        }

        /// <summary>
        /// 获取 size 数组。
        /// </summary>
        /// <returns>返回 size 数组。</returns>
        public LinkedList<int> GetSize()
        {
            return Size;
        }

        /// <summary>
        /// 在并查集中增加一个新的结点。
        /// </summary>
        /// <returns>新结点的下标。</returns>
        public int NewSite()
        {
            Parent.Insert(Parent.Size(), Parent.Size());
            Size.Insert(1, Size.Size());
            Count++;
            return Parent.Size() - 1;
        }

        /// <summary>
        /// 寻找一个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>该结点所属的连通分量。</returns>
        public int Find(int p)
        {
            Validate(p);
            while (p != Parent.Find(p))
            {
                p = Parent.Find(p);
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

            if (Size.Find(rootP) < Size.Find(rootQ))
            {
                Parent.Motify(rootP, rootQ);
                Size.Motify(rootQ, Size.Find(rootQ) + Size.Find(rootP));
            }
            else
            {
                Parent.Motify(rootQ, rootP);
                Size.Motify(rootP, Size.Find(rootQ) + Size.Find(rootP));
            }
            Count--;
        }

        /// <summary>
        /// 检查输入的 p 是否符合条件。
        /// </summary>
        /// <param name="p">输入的 p 值。</param>
        protected void Validate(int p)
        {
            var n = Parent.Size();
            if (p < 0 || p >= n)
            {
                throw new ArgumentException("index" + p + " is not between 0 and " + (n - 1));
            }
        }
    }
}
