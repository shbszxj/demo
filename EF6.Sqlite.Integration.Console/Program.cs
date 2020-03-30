using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6.Sqlite.Integration.Console.Models;

namespace EF6.Sqlite.Integration.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CompanyContext())
            {
                context.Departments.Add(new Department()
                {
                    DeptName = "test"
                });
                context.SaveChanges();

                System.Console.WriteLine("done");
                System.Console.ReadLine();
            }
        }
    }
}
