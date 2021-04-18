using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace _2._1._18
{
    public partial class Form2 : Form
    {
        readonly double[] randomDoubles;
        int sortI;
        int sortJ;
        int sortMin;
        public Form2(int N)
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
        /// 选择排序。
        /// </summary>
        private void SelectionSort()
        {
            for (sortI = 0; sortI < randomDoubles.Length; sortI++)
            {
                sortMin = sortI;
                for (sortJ = sortI; sortJ < randomDoubles.Length; sortJ++)
                {
                    if (randomDoubles[sortMin] > randomDoubles[sortJ])
                    {
                        sortMin = sortJ;
                    }
                }
                drawPanel();
                var temp = randomDoubles[sortI];
                randomDoubles[sortI] = randomDoubles[sortMin];
                randomDoubles[sortMin] = temp;
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
                if (i == sortMin)
                {
                    graphics.FillRectangle(Brushes.Red, bars[i]);
                }
                else if (i < sortI)
                {
                    graphics.FillRectangle(Brushes.Gray, bars[i]);
                }
                else
                {
                    graphics.FillRectangle(Brushes.Black, bars[i]);
                }
            }
            graphics.Dispose();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            SelectionSort();
        }
    }
}
