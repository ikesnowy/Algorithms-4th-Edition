using System;
using _1._3._39;

var buffer = new RingBuffer<string>(5);

try
{
    for (var i = 0; i < 6; i++) //引发 OutOfMemory 异常
    {
        buffer.Write(i.ToString());
    }
}
catch (OutOfMemoryException)
{
    Console.WriteLine(@"缓冲区已满");
}

while (!buffer.IsEmpty())
{
    Console.WriteLine(buffer.Read());
}

buffer.Write("first");
buffer.Write("second");
Console.WriteLine(buffer.Read());