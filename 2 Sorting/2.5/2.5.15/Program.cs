using System;
using _2._5._15;

// 利用上一题的逆域名排序，将相同的域名放在一起。
var emails = new Domain[5];
emails[0] = new Domain("wayne@cs.princeton.edu");
emails[1] = new Domain("windy@apple.com");
emails[2] = new Domain("rs@cs.princeton.edu");
emails[3] = new Domain("ike@ee.princeton.edu");
emails[4] = new Domain("admin@princeton.edu");
Array.Sort(emails);
for (var i = 0; i < emails.Length; i++)
{
    Console.WriteLine(emails[i]);
}