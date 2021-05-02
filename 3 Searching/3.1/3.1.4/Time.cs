using System;
using System.Text;

namespace _3._1._4
{
    /// <summary>
    /// 时间类。
    /// </summary>
    public class Time : IComparable<Time>
    {
        public int Hour { get; init; }
        public int Minute { get; init; }
        public int Second { get; init; }

        public Time() : this(0, 0, 0) { }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int CompareTo(Time other)
        {
            var result = Hour.CompareTo(other.Hour);
            if (result == 0)
                result = Minute.CompareTo(other.Minute);
            if (result == 0)
                result = Second.CompareTo(other.Second);
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            return CompareTo((Time)obj) == 0;
        }

        public override int GetHashCode()
        {
            var result = 1;
            result += Hour;
            result *= 31;
            result += Minute;
            result *= 31;
            result += Second;
            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Hour < 10 ? "0" + Hour : Hour.ToString());
            sb.Append(':');
            sb.Append(Minute < 10 ? "0" + Minute : Minute.ToString());
            sb.Append(':');
            sb.Append(Second < 10 ? "0" + Second : Second.ToString());
            return sb.ToString();
        }
    }
}
