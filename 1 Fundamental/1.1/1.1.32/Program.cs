using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace _1._1._32
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// 主绘图函数。
        /// </summary>
        /// <param name="array">输入的 double 数组。</param>
        /// <param name="n">分割的段数。</param>
        /// <param name="l">直方图 x 轴范围的下界。</param>
        /// <param name="r">直方图 x 轴范围的上界。</param>
        public static void StartDrawing(double[] array, int n, double l, double r)
        {
            // 创建并显示绘图窗口
            var drawPad = new Form2();
            drawPad.Show();

            // 新建画布
            var graphics = drawPad.CreateGraphics();
            
            // 翻转默认坐标系
            graphics.TranslateTransform(0, drawPad.Height);
            graphics.ScaleTransform(1, -1);

            // 对原始数组排序
            Array.Sort(array);

            // 计算各区域的值
            var counts = new int[n];
            var index = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = index; j < array.Length; j++)
                {
                    if (array[j] <= (r - l) * (i + 1) / n)
                    {
                        counts[i]++;
                        index++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // 获取最大值
            double max = counts.Max();
            // 计算间距
            var unit = drawPad.Width / (3.0 * n + 1);
            // 计算直方图的矩形
            var rects = new Rectangle[n];
            rects[0].X = (int)unit;
            rects[0].Y = 0;
            rects[0].Width = (int)(2 * unit);
            rects[0].Height = (int)((counts[0] / max) * drawPad.Height);
            for (var i = 1; i < n; i++)
            {
                rects[i].X = (int)(rects[i - 1].X + 3 * unit);
                rects[i].Y = 0;
                rects[i].Width = (int)(2 * unit);
                rects[i].Height = (int)((counts[i] / (max + 1)) * drawPad.Height);
            }

            // 绘图
            graphics.FillRectangles(Brushes.Black, rects);

            // 释放资源
            graphics.Dispose();
        }
    }
}
