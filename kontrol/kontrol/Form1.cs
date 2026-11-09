using System.Data;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kontrol
{
    public partial class Form1 : Form
    {
        private double dis = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string func = textBox1.Text.Trim();
            if (!double.TryParse(textBox1.Text.Replace('.', ','), out double a))
            {
                textBox1.Text = "Введите число";
                return;
            }
            if (a == 0)
            {
                textBox1.Text = "A не должно быть равным 0";
                return;
            }
            if (!double.TryParse(textBox2.Text.Replace('.', ','), out double b))
            {
                textBox2.Text = "Введите число";
                return;
            }
            if (!double.TryParse(textBox3.Text.Replace('.', ','), out double c))
            {
                textBox3.Text = "Введите число";
                return;
            }
            dis = (b * b) - (4 * a * c);
            label6.Text = "Дискриминант равен:" + dis;
            if (dis < 0)
            {
                label2.Text = "Дискриминант меньше 0, корней нет";
            }
            else if (dis == 0)
            {
                label2.Text ="X равен" + SchetX(dis, a, b, c);
            }
            else if (dis > 0)
            {
                label2.Text = "X1 равен " + SchetX(dis, a, b, c).ToString() + ", X2 равен " + SchetX2(dis, a, b, c).ToString();
                Vieta(a, b, c);
            }

        }
        private double SchetX(double dis, double a, double b, double c)
        {
            double x;
            return x = ((-b + Math.Sqrt(dis)) / (2 * a));
        }
        private double SchetX2(double dis, double a, double b, double c)
        {
            double x;
            return x = ((-b - Math.Sqrt(dis)) / (2 * a));
        }
        private double Vieta(double a, double b, double c)
        {
            double x1 = SchetX(dis, a, b, c);
            double x2 = SchetX2(dis, a, b, c);
            label7.Text = x1 + " + " + x2 + " = " + -b + "; " + x1 + " * " + x2 + " = " + -c;
            return x1;
        }
    }
}
