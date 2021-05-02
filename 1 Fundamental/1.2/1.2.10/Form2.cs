using System;
using System.Drawing;
using System.Windows.Forms;

namespace _1._2._10
{
    public partial class Form2 : Form
    {
        readonly VisualCounter _counter;
        readonly Graphics _graphics;
        public Form2(int n, int max)
        {
            InitializeComponent();
            _counter = new VisualCounter("count", max, n);
            _graphics = PaintArea.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_counter.Increment())
            {
                ErrorLabel.Text = @"操作数不足";
            }
            else
            {
                ErrorLabel.Text = "";
                _counter.Draw(_graphics,PaintArea.Width, PaintArea.Height, Font);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!_counter.Decreasement())
            {
                ErrorLabel.Text = @"操作数不足";
            }
            else
            {
                ErrorLabel.Text = "";
                _counter.Draw(_graphics, PaintArea.Width, PaintArea.Height, Font);
            }
        }
    }
}
