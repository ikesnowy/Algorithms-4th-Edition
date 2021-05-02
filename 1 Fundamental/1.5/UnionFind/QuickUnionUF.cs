namespace UnionFind
{
    /// <summary>
    /// 用 QuickUnion 算法实现的并查集。
    /// </summary>
    public class QuickUnionUf : Uf
    {
        /// <summary>
        /// 数组访问次数的计数器。
        /// </summary>
        /// <value>当前数组访问次数。</value>
        public int ArrayVisitCount { get; private set; }

        /// <summary>
        /// 建立使用 QuickUnion 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public QuickUnionUf(int n) : base(n) { }

        /// <summary>
        /// 重置数组访问计数。
        /// </summary>
        public virtual void ResetArrayCount()
        {
            ArrayVisitCount = 0;
        }

        /// <summary>
        /// 获得 parent 数组。
        /// </summary>
        /// <returns>返回 parent 数组。</returns>
        public int[] GetParent()
        {
            return Parent;
        }

        /// <summary>
        /// 寻找一个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>该结点所属的连通分量。</returns>
        public override int Find(int p)
        {
            Validate(p);
            while (p != Parent[p])
            {
                p = Parent[p];
                ArrayVisitCount += 2;
            }
            return p;
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public override void Union(int p, int q)
        {
            var rootP = Find(p);
            var rootQ = Find(q);
            if (rootP == rootQ)
            {
                return;
            }

            Parent[rootP] = rootQ;
            ArrayVisitCount++;
            TotalCount--;
        }
    }

}
