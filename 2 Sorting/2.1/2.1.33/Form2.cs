using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sort;

namespace _2._1._33
{
    public partial class Form2 : Form
    {
        readonly List<double> resultList;
        readonly List<float> resultYList;
        readonly Rectangle clientRect;
        readonly Rectangle drawRect;

        readonly BaseSort sort;
        readonly int n;

        /// <summary>
        /// 构造一个绘制结果窗口。
        /// </summary>
        /// <param name="sort">用于测试的排序算法。</param>
        /// <param name="n">测试算法是生成的数据量。</param>
        public Form2(BaseSort sort, int n)
        {
            InitializeComponent();
            resultList = new List<double>();
            resultYList = new List<float>();
            clientRect = ClientRectangle;
            drawRect = new Rectangle(clientRect.X + 10, clientRect.Y + 10, clientRect.Width - 10, clientRect.Height - 10);
            this.sort = sort;
            this.n = n;
            timer1.Interval = 500;
            timer1.Start();
        }

        /// <summary>
        /// 执行一次测试并绘制图像。
        /// </summary>
        public void Test()
        {
            var random = new Random();
            var array = SortCompare.GetRandomArrayDouble(n);
            var time = SortCompare.Time(sort, array);
            resultList.Add(time);
            resultYList.Add((float)(random.NextDouble() * drawRect.Height));
            DrawPanel(resultList.ToArray(), resultYList.ToArray());
        }

        /// <summary>
        /// 根据已有的数据绘制图像。
        /// </summary>
        /// <param name="result">耗时数据（X 轴）</param>
        /// <param name="resultY">Y 轴数据</param>
        public void DrawPanel(double[] result, float[] resultY)
        {
            var graphics = CreateGraphics();
            graphics.Clear(BackColor);
            graphics.TranslateTransform(0, ClientRectangle.Height);
            graphics.ScaleTransform(1, -1);

            var dataPoints = new PointF[result.Length];
            var unitX = (float)(drawRect.Width / (result.Max() - result.Min()));
            var min = result.Min();
            var pointSize = new SizeF(8, 8);
            for (var i = 0; i < result.Length; i++)
            {
                dataPoints[i] = new PointF((float)(unitX * (result[i] - min)), resultY[i]);
                graphics.FillEllipse(Brushes.Black, new RectangleF(dataPoints[i], pointSize));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Test();
        }
    }
}
