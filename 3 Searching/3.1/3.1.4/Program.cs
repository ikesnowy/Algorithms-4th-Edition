using System;
using SymbolTable;

namespace _3._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new OrderedSequentialSearchST<Time, Event>();
            Time[] times =
            {
                new Time() { Hour = 9, Minute = 0, Second = 0},
                new Time() { Hour = 9, Minute = 0, Second = 3 },
                new Time() { Hour = 9, Minute = 0, Second = 13 },
                new Time() { Hour = 9, Minute = 0, Second = 59 },
                new Time() { Hour = 9, Minute = 1, Second = 10 },
                new Time() { Hour = 9, Minute = 3, Second = 13 },
                new Time() { Hour = 9, Minute = 10, Second = 11 },
                new Time() { Hour = 9, Minute = 10, Second = 25 },
                new Time() { Hour = 9, Minute = 14, Second = 25 },
                new Time() { Hour = 9, Minute = 19, Second = 32 },
                new Time() { Hour = 9, Minute = 19, Second = 46 },
                new Time() { Hour = 9, Minute = 21, Second = 5 },
                new Time() { Hour = 9, Minute = 22, Second = 43 },
                new Time() { Hour = 9, Minute = 22, Second = 54 },
                new Time() { Hour = 9, Minute = 25, Second = 52 },
                new Time() { Hour = 9, Minute = 35, Second = 21 },
                new Time() { Hour = 9, Minute = 36, Second = 14 },
                new Time() { Hour = 9, Minute = 37, Second = 44 }
            };

            Event[] events =
            {
                new Event() { EventMessage = "Chicago" },
                new Event() { EventMessage = "Phoenix" },
                new Event() { EventMessage = "Houston" },
                new Event() { EventMessage = "Chicago" },
                new Event() { EventMessage = "Houston" },
                new Event() { EventMessage = "Chicago" },
                new Event() { EventMessage = "Seattle" },
                new Event() { EventMessage = "Seattle" },
                new Event() { EventMessage = "Phoenix" },
                new Event() { EventMessage = "Chicago" },
                new Event() { EventMessage = "Chicago" },
                new Event() { EventMessage = "Chicago" },
                new Event() { EventMessage = "Seattle" },
                new Event() { EventMessage = "Seattle" },
                new Event() { EventMessage = "Chicago" },
                new Event() { EventMessage = "Chicago" },
                new Event() { EventMessage = "Seattle" },
                new Event() { EventMessage = "Phoenix" }
            };

            for (var i = 0; i < times.Length; i++)
            {
                st.Put(times[i], events[i]);
            }

            Console.WriteLine("Min()=" + st.Min());

            Console.WriteLine(
                "Get(09:00:13)=" +
                st.Get(new Time() { Hour = 9, Minute = 0, Second = 13 }));

            Console.WriteLine(
                "Floor(09:05:00)=" +
                st.Floor(new Time() { Hour = 9, Minute = 5, Second = 0 }));

            Console.WriteLine("Select(7)=" + st.Select(7));

            Console.WriteLine(@"Keys(09:15:00, 09:25:00)");
            foreach (var t in 
                st.Keys(new Time() { Hour = 9, Minute = 15, Second = 0}, 
                    new Time() { Hour = 9, Minute = 25, Second = 0}))
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("Ceiling(09:30:00)=" + 
                st.Ceiling(new Time() { Hour = 9, Minute = 30, Second = 0 }));

            Console.WriteLine("Max()=" + st.Max());

            Console.WriteLine("Size(09:15:00, 09:25:00)=" +
                st.Size(new Time() { Hour = 9, Minute = 15, Second = 0 },
                new Time() { Hour = 9, Minute = 25, Second = 0 }));

            Console.WriteLine("Rank(09:10:25)=" + 
                st.Rank(new Time() { Hour = 9, Minute = 10, Second = 25 }));
        }
    }
}
