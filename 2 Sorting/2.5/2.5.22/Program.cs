using System;
using SortApplication;
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

// 输入格式： buy 20.05 100
var buyer = new MaxPq<Ticket>();
var seller = new MinPq<Ticket>();

var n = int.Parse(Console.ReadLine());
for (var i = 0; i < n; i++)
{
    var ticket = new Ticket();
    var item = Console.ReadLine().Split(' ');

    ticket.Price = double.Parse(item[1]);
    ticket.Share = int.Parse(item[2]);
    if (item[0] == "buy")
        buyer.Insert(ticket);
    else
        seller.Insert(ticket);
}

while (!buyer.IsEmpty() && !seller.IsEmpty())
{
    if (buyer.Max().Price < seller.Min().Price)
        break;
    var buy = buyer.DelMax();
    var sell = seller.DelMin();
    Console.Write("sell $" + sell.Price + " * " + sell.Share);
    if (buy.Share > sell.Share)
    {
        Console.WriteLine(" -> " + sell.Share + " -> $" + buy.Price + " * " + buy.Share + " buy");
        buy.Share -= sell.Share;
        buyer.Insert(buy);

    }
    else if (buy.Share < sell.Share)
    {
        sell.Share -= buy.Share;
        seller.Insert(sell);
        Console.WriteLine(" -> " + buy.Share + " -> $" + buy.Price + " * " + buy.Share + " buy");
    }
    else
    {
        Console.WriteLine(" -> " + sell.Share + " -> $" + buy.Price + " * " + buy.Share + " buy");
    }

}

class Ticket : IComparable<Ticket>
{
    public double Price;
    public int Share;

    public int CompareTo(Ticket other)
    {
        return Price.CompareTo(other.Price);
    }
}