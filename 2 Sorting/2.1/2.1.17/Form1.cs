using System;
using System.Windows.Forms;

namespace _2._1._17
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
                var selection = new Form2(n);
                selection.Show();
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
            try
            {
                var n = int.Parse(InputN.Text);
                var insertion = new Form3(n);
                insertion.Show();
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
    }
}
