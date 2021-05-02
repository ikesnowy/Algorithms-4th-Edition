using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Quick;

namespace _2._3._31
{
    public partial class Form2 : Form
    {
        private readonly int _n;
        private readonly int _;

        public Form2(int n, int t)
        {
            InitializeComponent();
            _n = n;
            _ = t;
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
            var quick = new QuickSort();

            var percentPerTrial = 100.0 / _;
            var totalTime = new double[_];
            for (var i = 0; i < _; i++)
            {
                var data = SortCompare.GetRandomArrayDouble(_n);
                totalTime[i] = SortCompare.Time(quick, data);
                worker?.ReportProgress((int)(percentPerTrial * i));
            }

            e.Result = totalTime;
        }

        /// <summary>
        /// 更新后台进度方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Text = @"正在测试，已完成 " + e.ProgressPercentage + @" %";
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
            //新建画布
            var graphics = CreateGraphics();

            //翻转默认坐标系
            graphics.TranslateTransform(0, Height);
            graphics.ScaleTransform(1, -1);

            var counts = e.Result as double[];

            //获取最大值
            var max = counts!.Max();
            //计算间距
            var unit = Width / (3.0 * counts.Length + 1);
            double marginTop = 100;
            //计算直方图的矩形
            var rects = new Rectangle[counts.Length];
            rects[0].X = (int)unit;
            rects[0].Y = 0;
            rects[0].Width = (int)(2 * unit);
            rects[0].Height = (int)((counts[0] / max) * (Height - marginTop));
            for (var i = 1; i < counts.Length; ++i)
            {
                rects[i].X = (int)(rects[i - 1].X + 3 * unit);
                rects[i].Y = 0;
                rects[i].Width = (int)(2 * unit);
                rects[i].Height = (int)((counts[i] / (max + 1)) * (Height - marginTop));
            }

            //绘图
            graphics.FillRectangles(Brushes.Black, rects);

            //释放资源
            graphics.Dispose();

            Text = @"绘图结果，最高耗时：" + counts.Max() + @" 最低耗时：" + counts.Min();
        }
    }
}
