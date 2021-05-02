using System;
using _2._5._21;

int[] data1 = { 1, 2, 3, 4 };
int[] data2 = { 2, 2, 3, 4 };
int[] data3 = { 1, 3, 2, 4 };
int[] data4 = { 1, 2, 3, 3 };
var vectors = new Vector[4];
vectors[0] = new Vector(data1);
vectors[1] = new Vector(data2);
vectors[2] = new Vector(data3);
vectors[3] = new Vector(data4);

Array.Sort(vectors);

for (var i = 0; i < vectors.Length; i++)
{
    Console.WriteLine(vectors[i]);
}