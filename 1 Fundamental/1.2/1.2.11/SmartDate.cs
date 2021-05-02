using System;

namespace _1._2._11
{
    class SmartDate
    {
        public int Month { get; }   // 月
        public int Day { get; }     // 日
        public int Year { get; }    // 年

        // 每个月对应的天数，第 0 位空出来
        private static readonly int[] DayOfMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public SmartDate(int m, int d, int y)
        {
            if (Vaildation(m, d, y) == false)
                throw new FormatException("Invaild Date");
            Month = m;
            Day = d;
            Year = y;
        }

        private bool Vaildation(int m, int d, int y)
        {
            if (y < 0)
                return false;

            var isLeapYear = IsLeapYear(y);

            if (m > 12 || m < 1)
                return false;
            if (d < 0)
                return false;
            if (m == 2 && d > 29 && isLeapYear)
                return false;
            if (d > DayOfMonth[m])
                return false;

            return true;
        }

        private bool IsLeapYear(int y)
        {
            if (y % 400 == 0)
                return true;
            if (y % 100 != 0 && y % 4 == 0)
                return true;

            return false;
        }

        public override string ToString()
        {
            return Month + "/" + Day + "/" + Year;
        }
    }
}
