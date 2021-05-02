using System.Windows.Forms;
using SymbolTable;

namespace _3._1._39
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test();
        }

        void Test()
        {
            var bst = new BinarySearchStAnalysis<string, int>();
            FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, bst, out var callIndexBinary, out var timeRecordBinary);
            var resultBinary = new Form2();
            resultBinary.Text = @"BinarySearch";
            resultBinary.Show();
            resultBinary.Draw(callIndexBinary, timeRecordBinary);

            var sst = new SequentialSearchStAnalysis<string, int>();
            FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, sst, out var callIndexSequential, out var timeRecordSequential);
            var resultSequential = new Form2();
            resultSequential.Text = @"Sequential";
            resultSequential.Show();
            resultSequential.Draw(callIndexSequential, timeRecordSequential);
        }
    }
}
