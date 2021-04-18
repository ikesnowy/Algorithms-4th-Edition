using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace _2._1._17
{
    public partial class Form2 : Form
    {
        readonly double[] _randomDoubles;
        public Form2(int n)
        {
            InitializeComponent();
            _randomDoubles = new double[n];
            var random = new Random();
            for (var i = 0; i < n; i++)
            {
                _randomDoubles[i] = random.NextDouble() * 0.8 + 0.2;
            }
            DrawPanel();

            timer1.Interval = 60;
            timer1.Start();

            var thread = new Thread(new ThreadStart(SelectionSort));
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 选择排序。
        /// </summary>
        private void SelectionSort()
        {
            for (var i = 0; i < _randomDoubles.Length; i++)
            {
                var min = i;
                for (var j = i; j < _randomDoubles.Length; j++)
                {
                    if (_randomDoubles[min] > _randomDoubles[j])
                    {
                        min = j;
                    }
                }
                var temp = _randomDoubles[i];
                _randomDoubles[i] = _randomDoubles[min];
                _randomDoubles[min] = temp;
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 在屏幕上用柱形图绘制数组。
        /// </summary>
        private void DrawPanel()
        {
            var graphics = CreateGraphics();
            graphics.Clear(BackColor);
            graphics.TranslateTransform(0, Height);
            graphics.ScaleTransform(1, -1);
            var clientRect = ClientRectangle;
            var drawRect = new Rectangle(clientRect.X + 10, clientRect.Y + 10, clientRect.Width - 10, clientRect.Height - 10);

            var barX = new PointF[_randomDoubles.Length];
            var unitX = (float)drawRect.Width / _randomDoubles.Length;
            unitX -= 4;

            barX[0] = new PointF(4, drawRect.Top);
            for (var i = 1; i < _randomDoubles.Length; i++)
            {
                barX[i] = new PointF(2 + unitX + barX[i - 1].X, drawRect.Top);
            }

            var bars = new RectangleF[_randomDoubles.Length];
            for (var i = 0; i < _randomDoubles.Length; i++)
            {
                var size = new SizeF(unitX, (float)_randomDoubles[i] * drawRect.Height);
                bars[i] = new RectangleF(barX[i], size);
            }

            graphics.FillRectangles(Brushes.Black, bars);
            graphics.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawPanel();
        }
    }
}
