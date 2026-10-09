using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba
{
    public class Employee
    {
        public string Names { get; set; }
        public decimal Salary { get; set; }
        public decimal Tax => Salary < 20000 ? 12m : Salary < 40000 ? 20m: 35m;
        public decimal TaxItog => Salary < 20000 ? Salary * 0.12m : Salary < 40000 ? Salary * 0.2m : Salary * 0.35m;
    }
}
