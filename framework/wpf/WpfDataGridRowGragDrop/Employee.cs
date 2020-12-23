using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataGridRowGragDrop
{
    public class Employee
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public Employee(string number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}
