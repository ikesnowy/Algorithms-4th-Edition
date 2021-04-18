using System;
using System.Windows.Forms;

namespace _1._2._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var n = int.Parse(InputN.Text);
                if (n <= 0)
                {
                    throw new FormatException();
                }
                var max = double.Parse(InputMax.Text);
                var min = double.Parse(InputMin.Text);

                if (max > 1 || max < 0)
                {
                    ErrorLabel.Text = "Max 应大于等于 0 且小于 1";
                    return;
                }

                if (min > 1 || min < 0)
                {
                    ErrorLabel.Text = "Min 应大于等于 0 且小于 1";
                    return;
                }

                if (min >= max)
                {
                    ErrorLabel.Text = "Min 应小于 Max。";
                    return;
                }

                Program.StartDrawing(n, min, max);
            }
            catch (ArgumentNullException)
            {
                ErrorLabel.Text = "输入值不能为空。";
            }
            catch (FormatException)
            {
                ErrorLabel.Text = "格式错误，确保输入的是大于零的数字。";
            }
            catch (OverflowException)
            {
                ErrorLabel.Text = "数据过大。";
            }
        }
        
    }
}
