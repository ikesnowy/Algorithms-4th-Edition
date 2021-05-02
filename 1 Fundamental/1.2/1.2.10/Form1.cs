using System;
using System.Windows.Forms;

namespace _1._2._10
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
                var max = int.Parse(InputMax.Text);

                if (n < 0)
                {
                    ErrorLabel.Text = @"操作数不可小于 0";
                    return;
                }
                var drawPad = new Form2(n, max);
                drawPad.Show();
            }
            catch (ArgumentNullException)
            {
                ErrorLabel.Text = @"不能输入空值";
            }
            catch (FormatException)
            {
                ErrorLabel.Text = @"格式错误（是否输入了空值？）";
            }
            catch (OverflowException)
            {
                ErrorLabel.Text = @"输入值过大";
            }
        }
    }
}
