using System;
using System.Windows.Forms;
using BinarySearchTree;

namespace _3._2._44
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out var n))
            {
                var result = Test(n);
                var drawPad = new Form2();
                drawPad.Show();
                drawPad.Draw(result);
            }
            else
            {
                label2.Text = @"请输入正确格式的数字！";
            }
        }

        private long[] Test(int n)
        {
            var testCases = new long[n];
            var testResult = new long[n];
            for (var i = 0; i < n; i++)
            {
                testCases[i] = i;
            }
            Shuffle(testCases);

            var bst = new BstAnalysis<long, int>();
            for (var i = 0; i < n; i++)
            {
                bst.CompareTimes = 0;
                bst.Put(testCases[i], 1);
                testResult[i] = bst.CompareTimes;
            }

            return testResult;
        }

        static void Shuffle<T>(T[] a)
        {
            var random = new Random();
            for (var i = 0; i < a.Length; i++)
            {
                var r = i + random.Next(a.Length - i);
                var temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}
