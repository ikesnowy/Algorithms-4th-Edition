namespace UnionFind
{
    /// <summary>
    /// 使用路径压缩的加权 quick-union 并查集。
    /// </summary>
    public class WeightedQuickUnionPathCompressionUf : WeightedQuickUnionUf
    {
        /// <summary>
        /// 新建一个大小为 n 的并查集。
        /// </summary>
        /// <param name="n">新建并查集的大小。</param>
        public WeightedQuickUnionPathCompressionUf(int n) : base(n)
        {
            size = new int[n];

            for (var i = 0; i < n; i++)
            {
                size[i] = 1;
            }
        }

        /// <summary>
        /// 寻找一个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>该结点所属的连通分量。</returns>
        public override int Find(int p)
        {
            Validate(p);
            var root = p;
            while (root != parent[p])
            {
                root = parent[p];
            }
            while (p != root)
            {
                var newP = parent[p];
                parent[p] = root;
                p = newP;
            }
            return root;
        }
    }
}
