using System;

namespace _1._2._12
{
    class SmartDate
    {
        public int Month { get; }   // 月
        public int Day { get; }     // 日
        public int Year { get; }    // 年

        // 每个月对应的天数，第 0 位空出来
        private static readonly int[] dayOfMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        // 每星期对应的名称。
        private static readonly string[] dayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public SmartDate(int m, int d, int y)
        {
            if (Vaildation(m, d, y) == false)
                throw new FormatException("Invaild Date");
            Month = m;
            Day = d;
            Year = y;
        }

        /// <summary>
        /// 计算当前日期是星期几，返回对应的星期名称。
        /// </summary>
        /// <returns></returns>
        public string DayOfTheWeek()
        {
            var d = Day;
            var m = Month;
            var y = Year;
            
            if (m < 3)
            {
                m += 12;
                y--;
            }

            // 使用蔡勒公式计算，参见 http://www.cnblogs.com/mq0036/p/3534314.html
            var w = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;

            return dayOfWeek[w];
        }

        private bool Vaildation(int m, int d, int y)
        {
            if (y < 0)
                return false;

            var isLeapYear = false;

            if (m > 12 || m < 1)
                return false;
            if (d < 0)
                return false;
            if (m == 2 && d > 29 && isLeapYear)
                return false;
            if (d > dayOfMonth[m])
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
