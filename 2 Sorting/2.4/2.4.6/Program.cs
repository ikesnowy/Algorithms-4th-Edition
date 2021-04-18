using System;
using PriorityQueue;

// P
// R P
// R P I
// R P I O
// P O I
// R P I O
// P O I
// O I
// O I I
// I I
// T I I
// I I
// Y I I
// I I
// I
// 
// Q
// U Q
// U Q E
// Q E
// E
// 
// U
// 
// E

var pq = new MaxPQ<char>();
var input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
foreach (var c in input)
{
    if (c == ' ')
        continue;
    else if (c == '*')
        pq.DelMax();
    else
        pq.Insert(c);

    Console.WriteLine(pq);
}