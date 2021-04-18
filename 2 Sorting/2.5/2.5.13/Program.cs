using System;
using System.Collections.Generic;
using System.Text;
using SortApplication;
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

var processorNum = int.Parse(Console.ReadLine());
var jobNum = int.Parse(Console.ReadLine());

var jobs = new Job[jobNum];
for (var i = 0; i < jobNum; i++)
{
    var jobDesc = Console.ReadLine().Split(' ');
    jobs[i] = new Job(jobDesc[0], double.Parse(jobDesc[1]));
}

Array.Sort(jobs);

var processors = new MinPQ<Processor>(processorNum);
for (var i = 0; i < processorNum; i++)
{
    processors.Insert(new Processor());
}

for (var i = jobs.Length - 1; i >= 0; i--)
{
    var min = processors.DelMin();
    min.Add(jobs[i]);
    processors.Insert(min);
}

while (!processors.IsEmpty())
{
    Console.WriteLine(processors.DelMin());
}

internal class Job : IComparable<Job>
{
    public readonly string Name;
    public readonly double Time;

    public Job(string name, double time)
    {
        Name = name;
        Time = time;
    }

    public int CompareTo(Job other)
    {
        return Time.CompareTo(other.Time);
    }
}

class Processor : IComparable<Processor>
{
    private readonly List<Job> _jobs = new();
    private double _busyTime;

    public void Add(Job job)
    {
        _jobs.Add(job);
        _busyTime += job.Time;
    }

    public int CompareTo(Processor other)
    {
        return _busyTime.CompareTo(other._busyTime);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var nowList = _jobs.ToArray();
        for (var i = 0; i < nowList.Length; i++)
        {
            sb.AppendLine(nowList[i].Name + " " + nowList[i].Time);
        }

        return sb.ToString();
    }
}