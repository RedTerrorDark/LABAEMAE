using System.Data;
using System.Linq.Expressions;
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
            double a, b, c;
            try
            {
                a = Eval(textBox3.Text);
            }
            catch
            {
                textBox3.Text = "Введите число";
                return;
            }
            try
            {
                b = Eval(textBox2.Text);
            }
            catch
            {
                textBox2.Text = "Введите число";
                return;
            }
            try
            {
                c = Eval(textBox1.Text);
            }
            catch
            {
                textBox1.Text = "Введите число";
                return;
            }
            if (a == 0)
            {
                textBox3.Text = "A не должно быть равным 0";
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
                label2.Text ="X равен" + SchetX(dis, a, b);
            }
            else if (dis > 0)
            {
                label2.Text = "X1 равен " + SchetX(dis, a, b).ToString() + ", X2 равен " + SchetX2(dis, a, b).ToString();
                Vieta(a, b, c);
            }

        }
        private double Eval(string expression)
        {
            var dt = new DataTable();

            expression = Regex.Replace(expression, @"sin\(([^)]+)\)", "Math.Sin(($1) * Math.PI / 180)");
            expression = Regex.Replace(expression, @"cos\(([^)]+)\)", "Math.Cos(($1) * Math.PI / 180)");
            expression = Regex.Replace(expression, @"tan\(([^)]+)\)", "Math.Tan(($1) * Math.PI / 180)");
            expression = expression.Replace("sqrt", "Math.Sqrt");

            var result = dt.Compute(expression, "");
            return Convert.ToDouble(result);
        }
        private double SchetX(double dis, double a, double b)
        {
            double x;
            x = ((-b + Math.Sqrt(dis)) / (2 * a));
            return x;
        }
        private double SchetX2(double dis, double a, double b)
        {
            double x;
            return x = ((-b - Math.Sqrt(dis)) / (2 * a));
        }
        private double Vieta(double a, double b, double c)
        {
            double x1 = SchetX(dis, a, b);
            double x2 = SchetX2(dis, a, b);
            if (x1 + x2 == -b / a)
            {
                label7.Text = x1 + " + " + x2 + " = " + (-b / a) + "; ";
            }
            else
            {
                label7.Text = "Тиорема Вието выдала False";
                return x1;
            }
            if (x1 * x2 == c / a)
            {
                label8.Text = x1 + " * " + x2 + " = " + (c / a) + "; ";
            }
            else
            {
                label8.Text = "Тиорема Вието выдала False";
                return x1;
            }
            return x1;
        }
    }
}
