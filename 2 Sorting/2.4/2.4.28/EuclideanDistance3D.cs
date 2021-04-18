using System;

namespace _2._4._28
{
    /// <summary>
    /// 点到原点的欧几里得距离。
    /// </summary>
    class EuclideanDistance3D : IComparable<EuclideanDistance3D>
    {
        private readonly int x, y, z;
        private readonly double distance;

        /// <summary>
        /// 计算点到原点的欧几里得距离。
        /// </summary>
        /// <param name="x">x 轴坐标。</param>
        /// <param name="y">y 轴坐标。</param>
        /// <param name="z">z 轴坐标。</param>
        public EuclideanDistance3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            distance = Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// 比较两个欧几里得距离的大小。
        /// </summary>
        /// <param name="other">另一个欧几里得距离。</param>
        /// <returns></returns>
        public int CompareTo(EuclideanDistance3D other)
        {
            return distance.CompareTo(other.distance);
        }

        /// <summary>
        /// 以 "(x, y, z)" 形式输出点的坐标。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
    }
}
