using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// ReSharper disable PossibleLossOfFraction

namespace _3._1._38
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        public void Draw(int[] data)
        {
            var panel = CreateGraphics();
            var unitX = (float)ClientRectangle.Width / data.Length;
            var unitY = (float)ClientRectangle.Height / data.Max();

            var accumulation = 0;
            for (var i = 0; i < data.Length; i++)
            {
                // Gray
                panel.FillEllipse(Brushes.Gray, (i + 1) * unitX, ClientRectangle.Bottom - data[i] * unitY, 2, 2);
                // Red
                panel.FillEllipse(Brushes.Red, (i + 1) * unitX, ClientRectangle.Bottom - accumulation / (i + 1) * unitY, 2, 2);
                accumulation += data[i];
            }
        }
    }
}
