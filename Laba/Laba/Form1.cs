using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Laba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static readonly string[] Names =
        {
        "Стабби МакГи", "ЭТОТ ЧЕРТОВ ПРЕДАТЕЛЬ ДЖОРДЖ МЕЛОНС", "Теодор Боль", "Тик МакРанфаст", "Перма Бан", "Сас Импостер",
        "Друг Админа", "Любитель Пива", "Опасный для общества", "Гига Гад",
        "Грей Тайд", "Физик Ядерщик", "Нубас Срочник", "Псих Неуравновешенный", "Убийца Убийцевич",
        "Ради Денег", "Подозрительный Тип", "Пивозавр Подпивасник", "СиДжей",
        "Олег", "Золотой Мажор", "Поклонник Хаоса", "Убиватор Три Тысячи",
        "Какой-то Мужик", "Неопознанный Ходячий Объект", "Борис Хрен Попадёшь", "Вечно Молодой", "Король Качалки",
        "Район Гуслинг", "Жеф Без Ос", "Уолтер Белый", "Гилл Бейтс"
        };

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double.TryParse(txtInputY1.Text, out double y1);
            double.TryParse(txtInputY2.Text, out double y2);
            double.TryParse(txtInputB.Text, out double b);
            double.TryParse(txtInputA.Text, out double a);

            double x1 = (y1 - b) / a;
            double x2 = (y2 - b) / a;
            double otvet = (x1 + x2)/2;

            txtOutput.Text = otvet.ToString("F2");
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            int count = (int)Numer.Value;

            var employees = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                employees.Add(new Employee
                {
                    Names = Names[rnd.Next(Names.Length)],
                    Salary = rnd.Next(5000, 100001)
                });
            }

            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText("output.json", json);

            txtLog.Clear();
            txtLog.AppendText($"Имя Фамилия - ЗП - налог - сумма налога\r\n\r\n");
            foreach (var emp in employees)
                txtLog.AppendText($"{emp.Names} — {emp.Salary}₽ - {emp.Tax}% - {emp.TaxItog}\r\n");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText("output.json");
            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            txtLog.Clear();
            txtLog.AppendText($"Имя Фамилия - ЗП - налог - сумма налога\r\n\r\n");
            foreach (var emp in employees)
                txtLog.AppendText($"{emp.Names} — {emp.Salary}₽ - {emp.Tax}% - {emp.TaxItog}\r\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            txtLog.AppendText($"OK.\r\n");
        }
    }
}
