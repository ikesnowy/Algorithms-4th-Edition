using System;
using System.IO;
using System.Windows.Forms;

namespace _1._1._32
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //新建一个文件选取窗口
            var openfiledialog = new OpenFileDialog();
            //设置要读取的文件类型
            openfiledialog.Filter = "文本文档(*.txt)|*.txt";
            //设置初始位置为“我的文档”
            openfiledialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //不允许多选
            openfiledialog.Multiselect = false;

            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //选择文件
                    openfiledialog.OpenFile();
                    //修改路径框显示
                    InputFilePath.Text = openfiledialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //打开文件并读取全部数字
                var stringNums = File.ReadAllLines(InputFilePath.Text);
                //建立 double 数组
                var numbers = new double[stringNums.Length];
                //将数字从 string 转换为 double
                for (var i = 0; i < stringNums.Length; i++)
                {
                    numbers[i] = double.Parse(stringNums[i]);
                }

                try
                {
                    var n = int.Parse(InputN.Text);
                    if (n <= 0)
                    {
                        ErrorLabel.Text = "N 必须大于 0";
                        return;
                    }
                    var l = double.Parse(InputL.Text);
                    var r = double.Parse(InputR.Text);
                    Program.StartDrawing(numbers, n, l, r);
                }
                catch (FormatException fex)
                {
                    ErrorLabel.Text = "格式有误（是否漏填了某项？）" + fex.Message;
                }
                catch (OverflowException oex)
                {
                    ErrorLabel.Text = "数据过大（输入的内容太多）" + oex.Message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
