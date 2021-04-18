using System;
using System.Windows.Forms;
using SortApplication;

namespace _2._5._26
{
    public partial class Form1 : Form
    {
        private readonly Form2 _panel;
        private readonly Random _random = new();

        public Form1()
        {
            InitializeComponent();
            _panel = new Form2();
            _panel.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var x = int.Parse(InputX.Text);
                var y = int.Parse(InputY.Text);
                _panel.Add(new Point2D(x, y));
            }
            catch (ArgumentNullException)
            {
                ErrorLabel.Text = @"输入值不能为空。";
            }
            catch (FormatException)
            {
                ErrorLabel.Text = @"格式错误（是否输入了空值？）";
            }
            catch (OverflowException)
            {
                ErrorLabel.Text = @"数据过大";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _panel.Add(new Point2D(
                _random.NextDouble() * _panel.ClientRectangle.Width + 1,
                _random.NextDouble() * _panel.ClientRectangle.Height + 1));
        }
    }
}
