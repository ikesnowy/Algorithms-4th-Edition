using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using UnionFind;

namespace _1._5._26
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
            var size = 200;
            var quickFind = new QuickFindUf(size);
            var quickUnion = new QuickUnionUf(size);
            var weightedQuickUnion = new WeightedQuickUnionUf(size);
            var connections = ErdosRenyi.Generate(size);

            var quickFindResult = new int[size];
            var quickUnionResult = new int[size];
            var weightedQuickUnionResult = new int[size];
            int p, q;
            for (var i = 0; i < size; i++)
            {
                p = connections[i].P;
                q = connections[i].Q;

                quickFind.Union(p, q);
                quickUnion.Union(p, q);
                weightedQuickUnion.Union(p, q);
                quickFindResult[i] = quickFind.ArrayVisitCount;
                quickUnionResult[i] = quickUnion.ArrayVisitCount;
                weightedQuickUnionResult[i] = weightedQuickUnion.ArrayParentVisitCount + weightedQuickUnion.ArraySizeVisitCount;

                quickFind.ResetArrayCount();
                quickUnion.ResetArrayCount();
                weightedQuickUnion.ResetArrayCount();
            }

            Draw(quickFindResult, "Quick-Find");
            Draw(quickUnionResult, "Quick-Union");
            Draw(weightedQuickUnionResult, "Weighted Quick-Union");
        }

        static void Draw(int[] cost, string title)
        {
            // 构建 total 数组。
            var total = new int[cost.Length];
            total[0] = cost[0];
            for (var i = 1; i < cost.Length; i++)
            {
                total[i] = total[i - 1] + cost[i];
            }

            // 获得最大值。
            var costMax = cost.Max();

            // 新建绘图窗口。
            var plot = new Form2();
            plot.Text = title;
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
            graphics.DrawString(costMax.ToString(), plot.Font, Brushes.Black, rect.Location);
            graphics.DrawString(cost.Length.ToString(), plot.Font, Brushes.Black, center.Right, center.Bottom);
            graphics.DrawString("0", plot.Font, Brushes.Black, rect.Left, center.Bottom);

            // 初始化点。
            var grayPoints = new PointF[cost.Length];
            var redPoints = new PointF[cost.Length];
            unitX = center.Width / cost.Length;
            unitY = center.Width / costMax;

            for (var i = 0; i < cost.Length; i++)
            {
                grayPoints[i] = new PointF(center.Left + unitX * (i + 1), center.Bottom - (cost[i] * unitY));
                redPoints[i] = new PointF(center.Left + unitX * (i + 1), center.Bottom - ((total[i] / (i + 1)) * unitY));
            }

            // 绘制点。
            for (var i = 0; i < cost.Length; i++)
            {
                graphics.FillEllipse(Brushes.Gray, new RectangleF(grayPoints[i], new SizeF(5, 5)));
                graphics.FillEllipse(Brushes.Red, new RectangleF(redPoints[i], new SizeF(5, 5)));
            }

            graphics.Dispose();
        }
    }
}
