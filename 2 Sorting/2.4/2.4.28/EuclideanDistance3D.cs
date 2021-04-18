using System;

namespace _2._4._28
{
    /// <summary>
    /// 点到原点的欧几里得距离。
    /// </summary>
    class EuclideanDistance3D : IComparable<EuclideanDistance3D>
    {
        private readonly int _x, _y, _z;
        private readonly double _distance;

        /// <summary>
        /// 计算点到原点的欧几里得距离。
        /// </summary>
        /// <param name="x">x 轴坐标。</param>
        /// <param name="y">y 轴坐标。</param>
        /// <param name="z">z 轴坐标。</param>
        public EuclideanDistance3D(int x, int y, int z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
            _distance = Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// 比较两个欧几里得距离的大小。
        /// </summary>
        /// <param name="other">另一个欧几里得距离。</param>
        /// <returns></returns>
        public int CompareTo(EuclideanDistance3D other)
        {
            return _distance.CompareTo(other._distance);
        }

        /// <summary>
        /// 以 "(x, y, z)" 形式输出点的坐标。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + _x + ", " + _y + ", " + _z + ")";
        }
    }
}
