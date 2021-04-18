using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace _2._1._18
{
    public partial class Form3 : Form
    {
        readonly double[] _randomDoubles;
        int _sortI;
        int _sortJ;

        public Form3(int n)
        {
            InitializeComponent();
            _randomDoubles = new double[n];
            var random = new Random();
            for (var i = 0; i < n; i++)
            {
                _randomDoubles[i] = random.NextDouble() * 0.8 + 0.2;
            }
        }

        /// <summary>
        /// 插入排序。
        /// </summary>
        private void InsertionSort()
        {
            for (_sortI = 0; _sortI < _randomDoubles.Length; _sortI++)
            {
                for (_sortJ = _sortI; _sortJ > 0 && _randomDoubles[_sortJ] < _randomDoubles[_sortJ - 1]; _sortJ--)
                {
                    var temp = _randomDoubles[_sortJ];
                    _randomDoubles[_sortJ] = _randomDoubles[_sortJ - 1];
                    _randomDoubles[_sortJ - 1] = temp;
                }
                DrawPanel();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 绘制柱形图。
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

            for (var i = 0; i < bars.Length; i++)
            {
                if (i == _sortJ)
                {
                    graphics.FillRectangle(Brushes.Red, bars[i]);
                }
                else if (i <= _sortI && i > _sortJ)
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
