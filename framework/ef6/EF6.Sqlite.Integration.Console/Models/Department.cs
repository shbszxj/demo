using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6.Sqlite.Integration.Console.Models
{
    public class Department
    {
        public string SubDept { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
        public string RuleCode { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
    }
}
