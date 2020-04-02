using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSLite.Integration.Console.Employee.WriteModel.Domain;

namespace CQRSLite.Integration.Console.Employee.WriteModel.Commands
{
    public class CreateEmployee : ICommand
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public Address Address { get; set; }
    }
}
