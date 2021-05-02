namespace UnionFind
{
    /// <summary>
    /// 使用路径压缩的 quick-union 并查集。
    /// </summary>
    public class QuickUnionPathCompressionUf : QuickFindUf
    {
        /// <summary>
        /// 新建一个大小为 n 的并查集。
        /// </summary>
        /// <param name="n">新建并查集的大小。</param>
        public QuickUnionPathCompressionUf(int n) : base(n) { }

        /// <summary>
        /// 寻找结点所属的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>结点所属的连通分量。</returns>
        public override int Find(int p)
        {
            var root = p;
            while (root != Parent[root])
            {
                root = Parent[root];
            }
            while (p != root)
            {
                var newp = Parent[p];
                Parent[p] = root;
                p = newp;
            }
            return p;
        }
    }
}
