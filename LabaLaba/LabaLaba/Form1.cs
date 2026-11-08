using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LabaLaba
{
    public partial class Form1 : Form
    {
        private double graphMinX, graphMaxX, graphMinY, graphMaxY;
        private string currentFunction = "";
        private double foundMinX = 0, foundMinY = 0;
        private bool hasMinimum = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text.Replace('.', ','), out double a))
            {
                textBox1.Text = "Введите число";
                return;
            }
            if (!double.TryParse(textBox2.Text.Replace('.', ','), out double b))
            {
                textBox2.Text = "Введите число";
                return;
            }
            if (a >= b)
            {
                textBox1.Text = "a должна быть меньше b";
                return;
            }
            if (!double.TryParse(textBox3.Text.Replace('.', ','), out double eps))
            {
                textBox3.Text = "Введите число";
                return;
            }
            if (eps <= 0)
            {
                textBox3.Text = "e должна быть больше 0";
                return;
            }

            string func = textBox4.Text.Trim();
            if (string.IsNullOrEmpty(func))
            {
                textBox4.Text = "Введите Формулу функции";
                return;
            }

            try
            {
                EvaluateFunction(func, 0);
                EvaluateFunction(func, 1);
            }
            catch (Exception ex)
            {
                textBox4.Text = ex.Message;
                return;
            }

            try
            {
                var (minX, minY) = Dichotomy(a, b, eps, func);

                currentFunction = func;
                graphMinX = a;
                graphMaxX = b;
                foundMinX = minX;
                foundMinY = minY;
                hasMinimum = true;

                ComputeYRange(a, b, func);

                pictureBox1.Invalidate();
                pictureBox1.Update();

                label6.Text = $"Минимум: x = {minX:F6},  f(x) = {minY:F6}";
            }
            catch (Exception ex)
            {
                textBox4.Text = ex.Message;
            }
        }
        private double EvaluateFunction(string function, double x)
        {
            string expr = PrepareExpression(function, x);
            var dt = new DataTable();
            object result = dt.Compute(expr, "");
            return Convert.ToDouble(result);
        }
        private string PrepareExpression(string function, double x)
        {
            string expr = function.ToLower().Trim();

            expr = Regex.Replace(expr, @"\bpi\b", Math.PI.ToString("R"));
            expr = Regex.Replace(expr, @"\be\b", Math.E.ToString("R"));
            expr = Regex.Replace(expr, @"\bsin\b", "Math.Sin");
            expr = Regex.Replace(expr, @"\bcos\b", "Math.Cos");
            expr = Regex.Replace(expr, @"\btan\b", "Math.Tan");
            expr = Regex.Replace(expr, @"\bctg\b", "(1.0/Math.Tan");
            expr = Regex.Replace(expr, @"\basin\b", "Math.Asin");
            expr = Regex.Replace(expr, @"\bacos\b", "Math.Acos");
            expr = Regex.Replace(expr, @"\batan\b", "Math.Atan");

            expr = Regex.Replace(expr, @"\bx\b", $"({x.ToString("R").Replace(',', '.')})");

            return expr;
        }
        private (double minX, double minY) Dichotomy(double a, double b, double eps, string f)
        {
            double delta = eps / 100;
            int maxIter = 10000;
            int iter = 0;

            while ((b - a) > eps && iter < maxIter)
            {
                double c = (a + b) / 2.0;
                double x1 = c - delta;
                double x2 = c + delta;

                double f1 = EvaluateFunction(f, x1);
                double f2 = EvaluateFunction(f, x2);

                if (f1 < f2)
                    b = x2;
                else
                    a = x1;

                iter++;
            }

            double minX = (a + b) / 2.0;
            double minY = EvaluateFunction(f, minX);
            return (minX, minY);
        }
        private void ComputeYRange(double a, double b, string f)
        {
            graphMinY = double.MaxValue;
            graphMaxY = double.MinValue;
            int n = 500;
            double step = (b - a) / n;

            for (int i = 0; i <= n; i++)
            {
                double x = a + i * step;
                try
                {
                    double y = EvaluateFunction(f, x);
                    if (double.IsNaN(y) || double.IsInfinity(y)) continue;
                    if (y < graphMinY) graphMinY = y;
                    if (y > graphMaxY) graphMaxY = y;
                }
                catch { }
            }

            double pad = (graphMaxY - graphMinY) * 0.1;
            if (pad < 1e-6) pad = 1;
            graphMinY -= pad;
            graphMaxY += pad;
        }
        private void Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int W = pictureBox1.ClientSize.Width;
            int H = pictureBox1.ClientSize.Height;
            int margin = 50;

            double MapX(double x) => margin + (x - graphMinX) / (graphMaxX - graphMinX) * (W - 2 * margin);
            double MapY(double y) => (H - margin) - (y - graphMinY) / (graphMaxY - graphMinY) * (H - 2 * margin);

            using (var gridPen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                int gridCount = 10;
                for (int i = 0; i <= gridCount; i++)
                {
                    double x = graphMinX + i * (graphMaxX - graphMinX) / gridCount;
                    double y = graphMinY + i * (graphMaxY - graphMinY) / gridCount;
                    g.DrawLine(gridPen, (float)MapX(x), margin, (float)MapX(x), H - margin);
                    g.DrawLine(gridPen, margin, (float)MapY(y), W - margin, (float)MapY(y));
                }
            }
            using (var axisPen = new Pen(Color.Black, 1.5f))
            {
                if (graphMinY <= 0 && graphMaxY >= 0)
                    g.DrawLine(axisPen, margin, (float)MapY(0), W - margin, (float)MapY(0));
                if (graphMinX <= 0 && graphMaxX >= 0)
                    g.DrawLine(axisPen, (float)MapX(0), margin, (float)MapX(0), H - margin);
            }

            using (var borderPen = new Pen(Color.Black, 1))
                g.DrawRectangle(borderPen, margin, margin, W - 2 * margin, H - 2 * margin);

            using (var font = new Font(FontFamily.GenericSansSerif, 8))
            {
                g.DrawString(graphMinX.ToString("F2"), font, Brushes.Black, margin - 10, H - margin + 5);
                g.DrawString(graphMaxX.ToString("F2"), font, Brushes.Black, W - margin - 30, H - margin + 5);
                g.DrawString(graphMaxY.ToString("F2"), font, Brushes.Black, 5, margin - 5);
                g.DrawString(graphMinY.ToString("F2"), font, Brushes.Black, 5, H - margin - 15);
            }

            using (var funcPen = new Pen(Color.Blue, 2))
            {
                int steps = W - 2 * margin;
                double? prevY = null;
                double prevScreenX = 0, prevScreenY = 0;

                for (int i = 0; i <= steps; i++)
                {
                    double x = graphMinX + i * (graphMaxX - graphMinX) / steps;
                    double? y;
                    try { y = EvaluateFunction(currentFunction, x); }
                    catch { y = null; }

                    if (y == null || double.IsNaN(y.Value) || double.IsInfinity(y.Value))
                    {
                        prevY = null;
                        continue;
                    }

                    double sx = MapX(x);
                    double sy = MapY(y.Value);

                    if (prevY.HasValue)
                    {
                        if (Math.Abs(sy - prevScreenY) < H)
                            g.DrawLine(funcPen, (float)prevScreenX, (float)prevScreenY, (float)sx, (float)sy);
                    }
                    prevY = y;
                    prevScreenX = sx;
                    prevScreenY = sy;
                }
            }

            if (hasMinimum)
            {
                float mx = (float)MapX(foundMinX);
                float my = (float)MapY(foundMinY);

                using (var brush = new SolidBrush(Color.Red))
                    g.FillEllipse(brush, mx - 6, my - 6, 12, 12);
                using (var pen = new Pen(Color.DarkRed, 2))
                    g.DrawEllipse(pen, mx - 6, my - 6, 12, 12);

                using (var font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold))
                {
                    string label = $"min ({foundMinX:F3}; {foundMinY:F3})";
                    g.DrawString(label, font, Brushes.DarkRed, mx + 10, my - 20);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Text = "0.001";
            textBox4.Text = "x*x - 4*x + 4";
            hasMinimum = false;
            currentFunction = "";

            pictureBox1.Invalidate();
            pictureBox1.Update();

            label6.Text = "";
        }
    }
}
