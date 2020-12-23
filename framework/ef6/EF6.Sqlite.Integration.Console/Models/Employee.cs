using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6.Sqlite.Integration.Console.Models
{
    public class Employee
    {
        public string DeptName { get; set; }
        public string EmployName { get; set; }
        public string Gender { get; set; }
        [Key]
        public string UserCode { get; set; }
        public int RuleCode { get; set; }
        public int OrderCode { get; set; }
    }
}
