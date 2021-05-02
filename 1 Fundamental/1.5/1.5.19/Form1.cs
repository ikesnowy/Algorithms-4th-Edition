using System;
using System.Windows.Forms;

namespace _1._5._19
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
                var log = new Log(n);
                log.Show();
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
