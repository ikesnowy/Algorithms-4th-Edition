using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace _2._1._18
{
    public partial class Form3 : Form
    {
        readonly double[] randomDoubles;
        int sortI;
        int sortJ;

        public Form3(int N)
        {
            InitializeComponent();
            randomDoubles = new double[N];
            var random = new Random();
            for (var i = 0; i < N; i++)
            {
                randomDoubles[i] = random.NextDouble() * 0.8 + 0.2;
            }
        }

        /// <summary>
        /// 插入排序。
        /// </summary>
        private void InsertionSort()
        {
            for (sortI = 0; sortI < randomDoubles.Length; sortI++)
            {
                for (sortJ = sortI; sortJ > 0 && randomDoubles[sortJ] < randomDoubles[sortJ - 1]; sortJ--)
                {
                    var temp = randomDoubles[sortJ];
                    randomDoubles[sortJ] = randomDoubles[sortJ - 1];
                    randomDoubles[sortJ - 1] = temp;
                }
                drawPanel();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 绘制柱形图。
        /// </summary>
        private void drawPanel()
        {
            var graphics = CreateGraphics();
            graphics.Clear(BackColor);
            graphics.TranslateTransform(0, Height);
            graphics.ScaleTransform(1, -1);
            var clientRect = ClientRectangle;
            var drawRect = new Rectangle(clientRect.X + 10, clientRect.Y + 10, clientRect.Width - 10, clientRect.Height - 10);

            var barX = new PointF[randomDoubles.Length];
            var unitX = (float)drawRect.Width / randomDoubles.Length;
            unitX -= 4;

            barX[0] = new PointF(4, drawRect.Top);
            for (var i = 1; i < randomDoubles.Length; i++)
            {
                barX[i] = new PointF(2 + unitX + barX[i - 1].X, drawRect.Top);
            }

            var bars = new RectangleF[randomDoubles.Length];
            for (var i = 0; i < randomDoubles.Length; i++)
            {
                var size = new SizeF(unitX, (float)randomDoubles[i] * drawRect.Height);
                bars[i] = new RectangleF(barX[i], size);
            }

            for (var i = 0; i < bars.Length; i++)
            {
                if (i == sortJ)
                {
                    graphics.FillRectangle(Brushes.Red, bars[i]);
                }
                else if (i <= sortI && i > sortJ)
                {
                    graphics.FillRectangle(Brushes.Black, bars[i]);
                }
                else
                {
                    graphics.FillRectangle(Brushes.Gray, bars[i]);
                }
            }
            graphics.Dispose();
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            InsertionSort();
        }
    }
}
