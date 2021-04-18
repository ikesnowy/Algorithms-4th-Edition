using System;
using System.Text;
// ReSharper disable StringCompareToIsCultureSpecific

namespace _2._5._15
{
    /// <summary>
    /// 域名类。
    /// </summary>
    class Domain : IComparable<Domain>
    {
        private readonly string[] _fields;
        private readonly int _n;

        /// <summary>
        /// 构造一个域名。
        /// </summary>
        /// <param name="url">域名的 url。</param>
        public Domain(string url)
        {
            _fields = url.Split('.');
            _n = _fields.Length;
        }

        public int CompareTo(Domain other)
        {
            var minLength = Math.Min(_n, other._n);
            for (var i = 0; i < minLength; i++)
            {
                var c = _fields[minLength - i - 1].CompareTo(other._fields[minLength - i - 1]);
                if (c != 0)
                    return c;
            }

            return _n.CompareTo(other._n);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _fields.Length; i++)
            {
                if (i != 0)
                    sb.Append('.');
                sb.Append(_fields[i]);
            }
            return sb.ToString();
        }
    }
}
