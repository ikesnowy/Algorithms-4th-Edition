using System;
using System.Windows.Forms;

namespace _2._3._31
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
                var T = int.Parse(InputT.Text);
                var panel = new Form2(n, T);
                panel.ShowDialog();
            }
            catch (ArgumentNullException)
            {
                ErrorLabel.Text = "输入值不能为空。";
            }
            catch (FormatException)
            {
                ErrorLabel.Text = "格式错误（是否输入了空值？）";
            }
            catch (OverflowException)
            {
                ErrorLabel.Text = "数据过大";
            }
        }
    }
}
