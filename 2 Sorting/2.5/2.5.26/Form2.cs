using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SortApplication;

namespace _2._5._26
{
    public partial class Form2 : Form
    {
        private Graphics _panel;
        private List<Point2D> _points;
        private Point2D _startPoint;

        private double _maxX, _maxY;

        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示并初始化绘图窗口。
        /// </summary>
        public void Init()
        {
            Show();
            _panel = CreateGraphics();
            _points = new List<Point2D>();
            _startPoint = null;
        }

        /// <summary>
        /// 向画板中添加一个点。
        /// </summary>
        /// <param name="point"></param>
        public void Add(Point2D point)
        {
            _points.Add(point);
            if (_startPoint == null)
            {
                _startPoint = point;
                _maxX = point.X * 1.1;
                _maxY = point.Y * 1.1;
            }
            else if (_startPoint.Y > point.Y)
                _startPoint = point;
            else if (Math.Abs(_startPoint.Y - point.Y) < 0.1 && _startPoint.X > point.X)
                _startPoint = point;

            if (point.X > _maxX)
                _maxX = point.X * 1.1;
            if (point.Y > _maxY)
                _maxY = point.Y * 1.1;

            _points.Sort(_startPoint.Polor_Order());
            RefreashPoints();
        }

        public void RefreashPoints()
        {
            var unitX = ClientRectangle.Width / _maxX;
            var unitY = ClientRectangle.Height / _maxY;
            double left = ClientRectangle.Left;
            double bottom = ClientRectangle.Bottom;

            _panel.Clear(BackColor);
            var line = (Pen)Pens.Red.Clone();
            line.Width = 6;
            var before = _startPoint;
            foreach (var p in _points)
            {
                _panel.FillEllipse(Brushes.Black, 
                    (float)(left + p.X * unitX - 5.0), 
                    (float)(bottom - p.Y * unitY - 5.0), 
                    (float)10.0, 
                    (float)10.0);
                _panel.DrawLine(line,
                    (float)(left + before.X * unitX),
                    (float)(bottom - before.Y * unitY),
                    (float)(left + p.X * unitX),
                    (float)(bottom - p.Y * unitY));
                before = p;
            }
            _panel.DrawLine(line,
                    (float)(left + before.X * unitX),
                    (float)(bottom - before.Y * unitY),
                    (float)(left + _startPoint.X * unitX),
                    (float)(bottom - _startPoint.Y * unitY));
        }
    }
}
