using System;
using System.Drawing;
using System.Windows.Forms;

namespace _1._2._10
{
    public partial class Form2 : Form
    {
        readonly VisualCounter counter;
        readonly Graphics graphics;
        public Form2(int N, int max)
        {
            InitializeComponent();
            counter = new VisualCounter("count", max, N);
            graphics = PaintArea.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!counter.Increment())
            {
                ErrorLabel.Text = "操作数不足";
            }
            else
            {
                ErrorLabel.Text = "";
                counter.Draw(graphics,PaintArea.Width, PaintArea.Height, Font);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!counter.Decreasement())
            {
                ErrorLabel.Text = "操作数不足";
            }
            else
            {
                ErrorLabel.Text = "";
                counter.Draw(graphics, PaintArea.Width, PaintArea.Height, Font);
            }
        }
    }
}
