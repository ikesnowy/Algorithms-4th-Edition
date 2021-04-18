using System;

namespace Measurement
{
    /// <summary>
    /// 计时器类。
    /// </summary>
    public class Stopwatch
    {
        private DateTime _start;

        /// <summary>
        /// 新建并开始一个计时器。
        /// </summary>
        public Stopwatch()
        {
            _start = DateTime.Now;
        }

        /// <summary>
        /// 重置计时器。
        /// </summary>
        public void Restart()
        {
            _start = DateTime.Now;
        }

        /// <summary>
        /// 获取计时器的计数值（秒）。
        /// </summary>
        /// <returns>计时器的计数值（秒）。</returns>
        public double ElapsedTime()
        {
            var now = DateTime.Now;
            return (now - _start).TotalMilliseconds / 1000.0;
        }

        /// <summary>
        /// 获取计时器的计数值（毫秒）。
        /// </summary>
        /// <returns>计时器的计数值（毫秒）。</returns>
        public double ElapsedTimeMillionSeconds()
        {
            var now = DateTime.Now;
            return (now - _start).TotalMilliseconds;
        }
    }
}
