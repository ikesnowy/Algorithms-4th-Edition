using System;

namespace _2._5._10
{
    /// <summary>
    /// 版本号。
    /// </summary>
    class Version : IComparable<Version>
    {
        private readonly int[] _versionNumber;

        public Version(string version)
        {
            var versions = version.Split('.');
            _versionNumber = new int[versions.Length];
            for (var i = 0; i < versions.Length; i++)
            {
                _versionNumber[i] = int.Parse(versions[i]);
            }
        }

        public int CompareTo(Version other)
        {
            for (var i = 0; i < _versionNumber.Length && i < other._versionNumber.Length; i++)
            {
                if (_versionNumber[i].CompareTo(other._versionNumber[i]) != 0)
                    return _versionNumber[i].CompareTo(other._versionNumber[i]);
            }
            return _versionNumber.Length.CompareTo(other._versionNumber.Length);
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < _versionNumber.Length - 1; i++)
            {
                result += _versionNumber[i] + ".";
            }
            result += _versionNumber[_versionNumber.Length - 1].ToString();
            return result;
        }
    }
}
