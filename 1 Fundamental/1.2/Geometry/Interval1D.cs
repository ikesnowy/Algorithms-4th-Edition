using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Geometry
{
    /// <summary>
    /// 一维闭区间。
    /// </summary>
    public class Interval1D
    {
        /// <summary>
        /// 优先以起点升序排序，起点相同时按照终点升序排序。
        /// </summary>
        /// <value>优先以起点升序排序，起点相同时按照终点升序排序。</value>
        public static readonly Comparer<Interval1D> MinOrder = new MinEndpointComparer();
        /// <summary>
        /// 优先以终点升序排序，起点相同时按照起点升序排序。
        /// </summary>
        /// <value>优先以终点升序排序，起点相同时按照起点升序排序。</value>
        public static readonly Comparer<Interval1D> MaxOrder = new MaxEndpointComparer();
        /// <summary>
        /// 以区间长度升序排序。
        /// </summary>
        /// <value>以区间长度升序排序。</value>
        public static readonly Comparer<Interval1D> LengthOrder = new LengthComparer();

        /// <summary>
        /// 区间起点。
        /// </summary>
        /// <value>区间起点。</value>
        /// <remarks>这个属性是只读的。</remarks>
        public double Min { get; }
        /// <summary>
        /// 区间终点。
        /// </summary>
        /// <value>区间终点。</value>
        /// <remarks>这个属性是只读的。</remarks>
        public double Max { get; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="lo">一维区域的下界。</param>
        /// <param name="hi">一维区域的上界。</param>
        public Interval1D(double lo, double hi)
        {
            if (double.IsInfinity(lo) || double.IsInfinity(hi))
            {
                throw new ArgumentException("Endpoints must be finite");
            }
            if (double.IsNaN(lo) || double.IsNaN(hi))
            {
                throw new ArgumentException("Endpoints cannot be NaN");
            }

            if (lo <= hi)
            {
                Min = lo;
                Max = hi;
            }
            else
            {
                throw new ArgumentException("Illegal interval");
            }
        }

        /// <summary>
        /// 一维区域的长度。
        /// </summary>
        /// <returns>返回长度。</returns>
        public double Length()
        {
            return Max - Min;
        }

        /// <summary>
        /// 判断目标区间是否被本区间包含。
        /// </summary>
        /// <param name="that">需要判断是否被包含的区间。</param>
        /// <returns>若 <paramref name="that"/> 被本区间包含则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(Interval1D that)
        {
            return Min < that.Min && Max > that.Max;
        }

        /// <summary>
        /// 目标值是否处在区域内。如果目标值在区域内则返回 True，否则返回 False。
        /// </summary>
        /// <param name="x">需要判断的值。</param>
        /// <returns>若 <paramref name="x"/> 被本区间包含则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(double x)
        {
            return x >= Min && x <= Max;
        }

        /// <summary>
        /// 判断两个区域是否相交。
        /// </summary>
        /// <param name="that">需要判断相交的另一个区域。</param>
        /// <returns>如果相交则返回 True，否则返回 False。</returns>
        public bool Intersect(Interval1D that)
        {
            if (Max < that.Min || that.Max < Min)
                return false;

            return true;
        }

        /// <summary>
        /// 绘制一维区间。
        /// </summary>
        /// <param name="g">原点在左下方，y轴向上，x轴向右的画布。</param>
        /// <param name="y">绘制一维区间的 y轴 坐标。</param>
        public void Draw(Graphics g, int y)
        {
            var a = new Point((int)Min, y);
            var b = new Point((int)Max, y);
            g.DrawLine(Pens.Black, a, b);
        }

        /// <summary>
        /// 将区域转换为 string，返回形如 "[lo, hi]" 的字符串。
        /// </summary>
        /// <returns>形如 "[<see cref="Min"/>, <see cref="Max"/>]" 的字符串。</returns>
        public override string ToString()
        {
            var s = "[" + Min + ", " + Max + "]";
            return s;
        }

        /// <summary>
        /// 判断两个区间是否相等。
        /// </summary>
        /// <param name="obj">相比较的区间。</param>
        /// <returns>如果区间相等则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            var that = (Interval1D)obj;
            return Math.Abs(Min - that.Min) < double.Epsilon * 5 && Math.Abs(Max - that.Max) < double.Epsilon * 5;
        }

        /// <summary>
        /// 返回区间的哈希代码。
        /// </summary>
        /// <returns>返回区间的哈希代码。</returns>
        public override int GetHashCode()
        {
            var hash1 = Min.GetHashCode();
            var hash2 = Max.GetHashCode();
            return 31 * hash1 + hash2;
        }

        private class MinEndpointComparer : Comparer<Interval1D>
        {
            public override int Compare(Interval1D a, Interval1D b)
            {
                Debug.Assert(a != null, nameof(a) + " != null");
                Debug.Assert(b != null, nameof(b) + " != null");
                if (a.Min < b.Min)
                {
                    return -1;
                }
                else if (a.Min > b.Min)
                {
                    return 1;
                }
                else if (a.Max < b.Max)
                {
                    return -1;
                }
                else if (a.Max > b.Max)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private class MaxEndpointComparer : Comparer<Interval1D>
        {
            public override int Compare(Interval1D a, Interval1D b)
            {
                Debug.Assert(a != null, nameof(a) + " != null");
                Debug.Assert(b != null, nameof(b) + " != null");
                if (a.Max < b.Max)
                {
                    return -1;
                }
                else if (a.Max > b.Max)
                {
                    return 1;
                }
                else if (a.Min < b.Min)
                {
                    return -1;
                }
                else if (a.Min > b.Min)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private class LengthComparer : Comparer<Interval1D>
        {
            public override int Compare(Interval1D a, Interval1D b)
            {
                Debug.Assert(a != null, nameof(a) + " != null");
                var alen = a.Length();
                Debug.Assert(b != null, nameof(b) + " != null");
                var blen = b.Length();

                if (alen < blen)
                {
                    return -1;
                }
                else if (alen > blen)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
