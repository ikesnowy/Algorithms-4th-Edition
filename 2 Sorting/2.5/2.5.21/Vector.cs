using System;
using System.Text;

namespace _2._5._21
{
    class Vector : IComparable<Vector>
    {
        private readonly int[] _data;
        public int Length { get; set; }

        public Vector(int[] data)
        {
            _data = data;
            Length = data.Length;
        }

        public int CompareTo(Vector other)
        {
            var maxN = Math.Max(Length, other.Length);
            for (var i = 0; i < maxN; i++)
            {
                var comp = _data[i].CompareTo(other._data[i]);
                if (comp != 0)
                    return comp;
            }
            return Length.CompareTo(other.Length);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Length; i++)
            {
                if (i != 0)
                    sb.Append(' ');
                sb.Append(_data[i]);
            }
            return sb.ToString();
        }
    }
}
