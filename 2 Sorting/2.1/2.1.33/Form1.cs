using System;
using System.Windows.Forms;
using Sort;

namespace _2._1._33
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
                if (selectionSortRadio.Checked)
                {
                    new Form2(new SelectionSort(), n).Show();
                }
                else if (insertionSortRadio.Checked)
                {
                    new Form2(new InsertionSort(), n).Show();
                }
                else if (shellSortRadio.Checked)
                {
                    new Form2(new ShellSort(), n).Show();
                }
                else
                {
                    ErrorLabel.Text = "请至少选择一项排序算法。";
                }
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
