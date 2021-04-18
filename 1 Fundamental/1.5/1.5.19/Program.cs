using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using UnionFind;

namespace _1._5._19
{
    
    static class Program
    {
        static RandomBag<Connection> _bag;
        static Graphics _graphics;
        static TextBox _logBox;
        static PointF[] _points;
        static Timer _timer;
        static List<Connection> _connections;
        static int _count;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// 绘制连接图像。
        /// </summary>
        /// <param name="n">矩阵边长。</param>
        public static void Draw(int n, TextBox log, Log winBox)
        {
            _logBox = log;

            // 生成路径。
            log.AppendText("\r\n开始生成连接……");
            _bag = RandomGrid.Generate(n);
            log.AppendText("\r\n生成连接完成");

            // 新建画布窗口。
            log.AppendText("\r\n启动画布……");
            var matrix = new Form2();
            matrix.StartPosition = FormStartPosition.Manual;
            matrix.Location = new Point(winBox.Left - matrix.ClientRectangle.Width, winBox.Top);
            matrix.Show();
            log.AppendText("\r\n画布已启动，开始绘图……");
            _graphics = matrix.CreateGraphics();

            // 获取绘图区域。
            RectangleF rect = matrix.ClientRectangle;
            var unitX = rect.Width / (n + 1);
            var unitY = rect.Height / (n + 1);

            // 绘制点。
            log.AppendText("\r\n绘制点……");
            _points = new PointF[n * n];
            for (var row = 0; row < n; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    _points[row * n + col] = new PointF(unitX * (col + 1), unitY * (row + 1));
                    _graphics.FillEllipse(Brushes.Black, unitX * (col + 1), unitY * (row + 1), 5, 5);
                }
            }
            log.AppendText("\r\n绘制点完成");

            // 绘制连接。
            log.AppendText("\r\n开始绘制连接……");
            _connections = new List<Connection>();
            foreach (var c in _bag)
            {
                _connections.Add(c);
            }
            _timer = new Timer
            {
                Interval = 500
            };
            _timer.Tick += DrawOneLine;
            _timer.Start();              
        }

        private static void DrawOneLine(object sender, EventArgs e)
        {
            var c = _connections[_count];
            _count++;
            _graphics.DrawLine(Pens.Black, _points[c.P], _points[c.Q]);
            _logBox.AppendText("\r\n绘制" + "(" + c.P + ", " + c.Q + ")");
            if (_count == _bag.Size())
            {
                _timer.Stop();
                _logBox.AppendText("\r\n绘制结束");
                _count = 0;
            }
        }
    }
}
