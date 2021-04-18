using System;
using System.Windows.Forms;
using System.Drawing;
using Merge;

namespace _2._2._6
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
            Compute();
            Application.Run(new Form1());
        }

        static void Compute()
        {
            var mergeSort = new MergeSort();
            var mergeSortBu = new MergeSortBu();
            var mergeResult = new int[10];
            var mergeResultBu = new int[10];
            var upperBound = new int[10];

            // 进行计算
            var dataSize = 1;
            for (var i = 0; i < 10; i++)
            {
                var dataMerge = SortCompare.GetRandomArrayInt(dataSize);
                var dataMergeBu = new int[dataSize];
                dataMerge.CopyTo(dataMergeBu, 0);

                mergeSort.ClearArrayVisitCount();
                mergeSortBu.ClearArrayVisitCount();
                mergeSort.Sort(dataMerge);
                mergeSortBu.Sort(dataMergeBu);

                mergeResult[i] = mergeSort.GetArrayVisitCount();
                mergeResultBu[i] = mergeSortBu.GetArrayVisitCount();
                upperBound[i] = (int)(6 * dataSize * Math.Log(dataSize, 2));

                dataSize *= 2;
            }

            // 绘图
            var plot = new Form2();
            plot.Show();
            var graphics = plot.CreateGraphics();

            // 获得绘图区矩形。
            RectangleF rect = plot.ClientRectangle;
            var unitX = rect.Width / 10;
            var unitY = rect.Width / 10;

            // 添加 10% 边距作为文字区域。
            var center = new RectangleF
                (rect.X + unitX, rect.Y + unitY,
                rect.Width - 2 * unitX, rect.Height - 2 * unitY);

            // 绘制坐标系。
            graphics.DrawLine(Pens.Black, center.Left, center.Top, center.Left, center.Bottom);
            graphics.DrawLine(Pens.Black, center.Left, center.Bottom, center.Right, center.Bottom);
            graphics.DrawString("28000", plot.Font, Brushes.Black, rect.Location);
            graphics.DrawString("1024", plot.Font, Brushes.Black, center.Right, center.Bottom);
            graphics.DrawString("0", plot.Font, Brushes.Black, rect.Left, center.Bottom);

            // 初始化点。
            var grayPoints = new PointF[10]; // 上限
            var redPoints = new PointF[10];  // 自顶向下
            var bluePoints = new PointF[10]; // 自底向上
            unitX = center.Width / 11.0f;
            unitY = center.Height / 28000.0f;

            for (var i = 0; i < 10; i++)
            {
                grayPoints[i] = new PointF(center.Left + unitX * (i + 1), center.Bottom - (upperBound[i] * unitY) - 10);
                redPoints[i] = new PointF(center.Left + unitX * (i + 1), center.Bottom - (mergeResult[i] * unitY) - 10);
                bluePoints[i] = new PointF(center.Left + unitX * (i + 1), center.Bottom - (mergeResultBu[i] * unitY) - 10);
            }

            // 绘制点。
            for (var i = 0; i < 10; i++)
            {
                graphics.FillEllipse(Brushes.Gray, new RectangleF(grayPoints[i], new SizeF(10, 10)));
                graphics.FillEllipse(Brushes.Red, new RectangleF(redPoints[i], new SizeF(10, 10)));
                graphics.FillEllipse(Brushes.Blue, new RectangleF(bluePoints[i], new Size(10, 10)));
            }

            graphics.Dispose();
        }
    }
}
