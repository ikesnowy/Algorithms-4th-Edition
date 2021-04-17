using System;
using _1._3._35;

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

// 发牌
for (var i = 1; i <= 4; i++)
{
    Console.WriteLine("Player " + i);
    for (var j = 1; j <= 13; j++)
    {
        Console.WriteLine(queue.Dequeue().ToString());
    }

    Console.WriteLine();
}