using System.Drawing;

namespace Geometry
{
    /// <summary>
    /// 二维闭合区间。
    /// </summary>
    public class Interval2D
    {
        private readonly Interval1D _x;
        private readonly Interval1D _y;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="x">x 轴上的范围。</param>
        /// <param name="y">y 轴上的范围。</param>
        public Interval2D(Interval1D x, Interval1D y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// 判断两个平面是否相交。
        /// </summary>
        /// <param name="that">需要判断的另一个平面。</param>
        /// <returns>相交则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Intersects(Interval2D that)
        {
            if (!_x.Intersect(that._x))
            {
                return false;
            }

            if (!_y.Intersect(that._y))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 判断目标区间是否被本区间包含。
        /// </summary>
        /// <param name="that">需要判断是否被包含的区间。</param>
        /// <returns>如果 <paramref name="that"/> 被包含，则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(Interval2D that)
        {
            return _x.Contains(that._x) && _y.Contains(that._y);
        }

        /// <summary>
        /// 判断一个二维点是否在该平面范围内。
        /// </summary>
        /// <param name="p">需要判断的二维点。</param>
        /// <returns>如果 <paramref name="p"/> 被包含，则返回 <c>true</c>，否则 <c>false</c>。</returns>
        public bool Contains(Point2D p)
        {
            return (_x.Contains(p.X) && _y.Contains(p.Y));
        }

        /// <summary>
        /// 计算平面范围的面积。
        /// </summary>
        /// <returns>平面范围的面积。</returns>
        public double Area()
        {
            return _x.Length() * _y.Length();
        }

        /// <summary>
        /// 在画布上绘制二维区间。
        /// </summary>
        /// <param name="g">原点在左下方，x轴向右，y轴向上的画布。</param>
        public void Draw(Graphics g)
        {
            var rect = new Rectangle((int)_x.Min, (int)_y.Min, (int)_x.Length(), (int)_y.Length());
            g.DrawRectangle(Pens.White, rect);
            g.FillRectangle(Brushes.Black, rect);
        }

        /// <summary>
        /// 返回形如“[xmin, xmax] x [ymin, ymax]”的字符串。
        /// </summary>
        /// <returns>形如 "[xmin, xmax] x [ymin, ymax]" 的字符串。</returns>
        public override string ToString()
        {
            return _x + "x" + _y;
        }

        /// <summary>
        /// 判断两个二维区间是否相等。
        /// </summary>
        /// <param name="obj">需要比较的另一个区间。</param>
        /// <returns>相等则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj  == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            var that = (Interval2D)obj;

            return _x.Equals(that._x) && _y.Equals(that._y);
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <returns>2D 区间的哈希值。</returns>
        public override int GetHashCode()
        {
            var hash1 = _x.GetHashCode();
            var hash2 = _y.GetHashCode();

            return 31 * hash1 + hash2;
        }
    }
}
