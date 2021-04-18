using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinarySearchTree;

namespace _3._2._47
{
    public partial class Form1 : Form
    {
        private readonly Random _random = new();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            const int trialCount = 1000;
            var lo = (int)numericUpDown1.Value;
            var hi = (int)numericUpDown2.Value;

            if (lo > hi)
            {
                label2.Text = "最大值不能小于最小值！";
                return;
            }

            var averages = new Dictionary<int, double>();
            var standardDeviations = new Dictionary<int, double>();
            for (var i = lo; i < hi; i++)
            {
                var trialResult = new int[trialCount];
                var trialAverage = 0d;
                var trialStandardDeviation = 0d;
                for (var j = 0; j < trialCount; j++)
                {
                    trialResult[j] = await Task.Run(() => Test(i));
                    trialAverage += trialResult[j];
                    label2.Text = $"Testing... n={i}";
                }

                trialAverage /= trialCount;

                foreach (var data in trialResult)
                {
                    trialStandardDeviation += (data - trialAverage) * (data - trialAverage);
                }

                trialStandardDeviation /= trialCount;
                trialStandardDeviation = Math.Sqrt(trialStandardDeviation);
                averages.Add(i, trialAverage);
                standardDeviations.Add(i, trialStandardDeviation);
            }

            var displayAverage = new Form2
            {
                Text = "Average"
            };
            displayAverage.Show();
            displayAverage.Draw(averages);

            var displayStandardDeviation = new Form2
            {
                Text = "StandardDeviation"
            };
            displayStandardDeviation.Show();
            displayStandardDeviation.Draw(standardDeviations);
            button1.Enabled = true;
        }

        private int Test(int n)
        {
            var data = GetRandomInt(n);
            var bst = new Bst<int, int>();
            foreach (var d in data)
            {
                bst.Put(d, d);
            }

            return bst.AverageInternalPathLength();
        }

        private int[] GetRandomInt(int n)
        {
            var numbers = new int[n];
            for (var i = 0; i < n; i++)
            {
                numbers[i] = _random.Next();
            }

            return numbers;
        }
    }
}
