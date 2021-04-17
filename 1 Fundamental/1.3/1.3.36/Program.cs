using System;
using _1._3._36;

var queue = new RandomQueue<Card>();

// 建立牌组
for (var i = 0; i < 4; i++)
{
    for (var j = 1; j <= 13; j++)
    {
        var card = new Card((Suit)i, j);
        queue.Enqueue(card);
    }
}

// 随机输出
foreach (var c in queue)
{
    Console.WriteLine(c.ToString());
}