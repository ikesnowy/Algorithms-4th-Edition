using System.Windows.Forms;
using SymbolTable;

namespace _3._1._38
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test();
        }

        static void Test()
        {
            var bst = new BinarySearchStAnalysis<string, int>();
            var dataBinary = FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, bst);
            var resultBinary = new Form2();
            resultBinary.Text = "BinarySearch";
            resultBinary.Show();
            resultBinary.Draw(dataBinary);

            var sst = new SequentialSearchStAnalysis<string, int>();
            var dataSequential = FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, sst);
            var resultSequential = new Form2();
            resultSequential.Text = "Sequential";
            resultSequential.Show();
            resultSequential.Draw(dataSequential);
        }
    }
}
