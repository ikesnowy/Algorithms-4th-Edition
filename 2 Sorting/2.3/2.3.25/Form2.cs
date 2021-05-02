using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Quick;

namespace _2._3._25
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// 测试数组大小。
        /// </summary>
        public readonly int N;

        public Form2(int n)
        {
            InitializeComponent();
            N = n;
        }

        /// <summary>
        /// 启动页面时启动后台测试。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Shown(object sender, EventArgs e)
        {
            Text = @"正在绘图";
            backgroundWorker1.RunWorkerAsync();
        }

        /// <summary>
        /// 后台测试方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var quickSortInsertion = new QuickSortInsertion();
            var timeRecord = new double[31];
            for (var i = 0; i <= 30; i++)
            {
                Debug.Assert(worker != null, nameof(worker) + " != null");
                worker.ReportProgress(i * 3);
                quickSortInsertion.M = i;
                var data = SortCompare.GetRandomArrayInt(N);
                timeRecord[i] = SortCompare.Time(quickSortInsertion, data);
            }
            e.Result = timeRecord;
        }

        /// <summary>
        /// 更新后台进度方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Text = @"正在绘图，已完成 " + e.ProgressPercentage + @" %";
        }

        /// <summary>
        /// 测试完毕，进行绘图的方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            var result = e.Result as double[];

            var graphics = CreateGraphics();

            // 获得绘图区矩形。
            RectangleF rect = ClientRectangle;
            var unitX = rect.Width / 10;
            var unitY = rect.Width / 10;

            // 添加 10% 边距作为文字区域。
            var center = new RectangleF
                (rect.X + unitX, rect.Y + unitY,
                rect.Width - 2 * unitX, rect.Height - 2 * unitY);

            // 绘制坐标系。
            graphics.DrawLine(Pens.Black, center.Left, center.Top, center.Left, center.Bottom);
            graphics.DrawLine(Pens.Black, center.Left, center.Bottom, center.Right, center.Bottom);
            graphics.DrawString(result!.Max().ToString(CultureInfo.CurrentCulture), Font, Brushes.Black, rect.Location);
            graphics.DrawString(result.Length.ToString(), Font, Brushes.Black, center.Right, center.Bottom);
            graphics.DrawString("0", Font, Brushes.Black, rect.Left, center.Bottom);

            // 初始化点。
            var bluePoints = new PointF[result.Length];
            unitX = center.Width / result.Length;
            unitY = center.Height / (float)result.Max();

            for (var i = 0; i < result.Length; i++)
            {
                bluePoints[i] = new PointF(center.Left + unitX * (i + 1), center.Bottom - (float)(result[i] * unitY) - 10);
            }

            // 绘制点。
            for (var i = 0; i < result.Length; i++)
            {
                graphics.FillEllipse(Brushes.Blue, new RectangleF(bluePoints[i], new Size(10, 10)));
            }

            graphics.Dispose();

            Text = @"绘图结果";
            var min = 0;
            for (var i = 0; i < result.Length; i++)
            {
                if (result[i] < result[min])
                    min = i;
            }
            var report = "M " + min + "\r\ntime " + result[min];
            MessageBox.Show(report, @"最优结果");
        }
    }
}
