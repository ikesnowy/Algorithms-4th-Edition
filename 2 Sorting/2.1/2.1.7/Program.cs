﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._7
{
    /*
     * 2.1.7
     * 
     * 对于逆序数组，选择排序和插入排序谁更快？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 选择排序更快
            // 选择排序的比较次数为 ~N^2/2 次，交换次数 ~N 次
            // 插入排序的比较次数为 ~N^2/2 次，交换次数 ~N^2/2 次
            // 因此插入排序慢于选择排序
        }
    }
}