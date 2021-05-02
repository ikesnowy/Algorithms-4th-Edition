namespace UnionFind
{
    /// <summary>
    /// 使用加权 quick-union 算法的并查集。
    /// </summary>
    public class WeightedQuickUnionUf : QuickUnionUf
    {
        /// <summary>
        /// 记录各个树大小的数组。
        /// </summary>
        /// <value>记录各个树大小的数组。</value>
        protected int[] Size;

        /// <summary>
        /// 记录 parent 数组的访问次数的计数器。
        /// </summary>
        /// <value>parent 数组的访问次数。</value>
        public int ArrayParentVisitCount { get; private set; }
        /// <summary>
        /// 记录 size 数组的访问次数的计数器。
        /// </summary>
        /// <value>size 数组的访问次数。</value>
        public int ArraySizeVisitCount { get; private set; }

        /// <summary>
        /// 建立使用加权 quick-union 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public WeightedQuickUnionUf(int n) : base(n)
        {
            Size = new int[n];
            for (var i = 0; i < n; i++)
            {
                Size[i] = 1;
            }
            ArrayParentVisitCount = 0;
            ArraySizeVisitCount = 0;
        }

        /// <summary>
        /// 清零数组访问计数。
        /// </summary>
        public override void ResetArrayCount()
        {
            ArrayParentVisitCount = 0;
            ArraySizeVisitCount = 0;
        }

        /// <summary>
        /// 获取 size 数组。
        /// </summary>
        /// <returns>返回 size 数组。</returns>
        public int[] GetSize()
        {
            return Size;
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
                ArrayParentVisitCount += 2;
            }
            ArrayParentVisitCount++;
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

            if (Size[rootP] < Size[rootQ])
            {
                Parent[rootP] = rootQ;
                Size[rootQ] += Size[rootP];
            }
            else
            {
                Parent[rootQ] = rootP;
                Size[rootP] += Size[rootQ];
            }
            ArrayParentVisitCount++;
            ArraySizeVisitCount += 4;
            TotalCount--;
        }
    }
}
