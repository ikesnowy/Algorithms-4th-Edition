using System;

namespace _2._5._20
{
    class Program
    {
        /// <summary>
        /// 任务变化事件。
        /// </summary>
        class JobEvent : IComparable<JobEvent>
        {
            public string JobName;
            public int Time;
            public bool IsFinished = false;     // false = 开始，true = 结束

            public int CompareTo(JobEvent other)
            {
                return Time.CompareTo(other.Time);
            }
        }

        static void Main(string[] args)
        {
            // 输入格式： JobName 15:02 17:02
            var nowRunning = 0;     // 正在运行的程序数量
            var maxIdle = 0;
            var maxBusy = 0;

            var items = int.Parse(Console.ReadLine());
            var jobs = new JobEvent[items * 2];
            for (var i = 0; i < jobs.Length; i += 2)
            {
                jobs[i] = new JobEvent();
                jobs[i + 1] = new JobEvent();

                jobs[i].IsFinished = false;     // 开始事件
                jobs[i + 1].IsFinished = true;  // 停止事件

                var record = Console.ReadLine().Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                jobs[i].JobName = record[0];
                jobs[i + 1].JobName = record[0];

                jobs[i].Time = int.Parse(record[1]) * 60 + int.Parse(record[2]);
                jobs[i + 1].Time = int.Parse(record[3]) * 60 + int.Parse(record[4]);
            }

            Array.Sort(jobs);

            // 事件处理
            var idleStart = 0;
            var busyStart = 0;
            for (var i = 0; i < jobs.Length; i++)
            {
                // 启动事件
                if (!jobs[i].IsFinished)
                {
                    // 空闲状态结束
                    if (nowRunning == 0)
                    {
                        var idle = jobs[i].Time - idleStart;
                        if (idle > maxIdle)
                            maxIdle = idle;

                        // 开始忙碌
                        busyStart = jobs[i].Time;
                    }
                    nowRunning++;
                }
                else
                {
                    nowRunning--;
                    // 忙碌状态结束
                    if (nowRunning == 0)
                    {
                        var busy = jobs[i].Time - busyStart;
                        if (busy > maxBusy)
                            maxBusy = busy;

                        // 开始空闲
                        idleStart = jobs[i].Time;
                    }
                }
            }

            Console.WriteLine("Max Idle: " + maxIdle);
            Console.WriteLine("Max Busy: " + maxBusy);
        }
    }
}
