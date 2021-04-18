using System;

namespace UnionFind
{
    /// <summary>
    /// 并查集 API。
    /// </summary>
    public class UF
    {
        /// <summary>
        /// 记录各个结点的父级的数组。
        /// </summary>
        /// <value>记录了各个结点的父级。</value>
        protected int[] parent;
        /// <summary>
        /// 连通分量的数目。
        /// </summary>
        /// <value>连通分量的数目。</value>
        protected int count;
        /// <summary>
        /// 各结点的深度。
        /// </summary>
        /// <value>各结点的深度。</value>
        private readonly byte[] rank;

        /// <summary>
        /// 新建一个大小为 n 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public UF(int n)
        {
            if (n < 0)
                throw new ArgumentException();
            count = n;
            parent = new int[n];
            rank = new byte[n];
            for (var i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        /// <summary>
        /// 寻找 p 所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>p 所在的连通分量。</returns>
        public virtual int Find(int p)
        {
            Validate(p);
            while (p != parent[p])
            {
                parent[p] = parent[parent[p]];
                p = parent[p];
            }
            return p;
        }

        /// <summary>
        /// 合并两个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public virtual void Union(int p, int q)
        {
            var rootP = Find(p);
            var rootQ = Find(q);

            if (rootP == rootQ)
                return;

            if (rank[rootP] < rank[rootQ])
                parent[rootP] = rootQ;
            else if (rank[rootP] > rank[rootQ])
                parent[rootQ] = rootP;
            else
            {
                parent[rootQ] = rootP;
                rank[rootP]++;
            }
            count--;
        }

        /// <summary>
        /// 返回分量的数目。
        /// </summary>
        /// <returns>分量的数目。</returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// 判断两个结点是否同属于一个连通分量。
        /// </summary>
        /// <param name="p">需要判断的结点。</param>
        /// <param name="q">需要判断的另一个结点。</param>
        /// <returns>两个结点是否同属于一个连通分量。</returns>
        public virtual bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// 检查输入的 p 是否符合条件。
        /// </summary>
        /// <param name="p">输入的 p 值。</param>
        /// <exception cref="ArgumentException">当 <paramref name="p"/> 不在索引范围内时抛出。</exception>
        protected void Validate(int p)
        {
            var n = parent.Length;
            if (p < 0 || p >= n)
            {
                throw new ArgumentException("index" + p + " is not between 0 and " + (n - 1));
            }
        }

    }
}
