using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sort;

namespace _2._1._32
{
    public partial class Form2 : Form
    {
        readonly BaseSort _sort;
        int _n;
        readonly double[] _result;

        /// <summary>
        /// 构造一个绘图结果窗口。
        /// </summary>
        /// <param name="sort">用于做测试的排序算法。</param>
        /// <param name="n">用于测试的初始数据量。</param>
        public Form2(BaseSort sort, int n)
        {
            InitializeComponent();
            this._sort = sort;
            this._n = n;
            _result = Test(n);
            timer1.Interval = 1000;
            timer1.Start();
        }

        /// <summary>
        /// 执行八次耗时测试，每次数据量翻倍。
        /// </summary>
        /// <param name="n">初始数据量。</param>
        /// <returns>测试结果数据。</returns>
        public double[] Test(int n)
        {
            var result = new double[8];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = SortCompare.TimeRandomInput(_sort, n, 3);
                n *= 2;
            }
            return result;
        }

        /// <summary>
        /// 绘制曲线图。
        /// </summary>
        /// <param name="result">结果数组。</param>
        public void DrawPanel(double[] result)
        {
            var graphics = CreateGraphics();
            graphics.TranslateTransform(0, ClientRectangle.Height);
            graphics.ScaleTransform(1, -1);
            var clientRect = ClientRectangle;
            var drawRect = new Rectangle(clientRect.X + 10, clientRect.Y + 10, clientRect.Width - 10, clientRect.Height - 10);

            var dataPoints = new PointF[result.Length];
            var unitX = (float)drawRect.Width / result.Length;
            var unitY = (float)(drawRect.Height / result.Max());
            var pointSize = new SizeF(8, 8);
            for (var i = 0; i < result.Length; i++)
            {
                dataPoints[i] = new PointF(drawRect.Left + unitX * i, (float)(unitY * result[i]));
                graphics.FillEllipse(Brushes.Black, new RectangleF(dataPoints[i], pointSize));

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawPanel(_result);
            timer1.Stop();
        }
    }
}
