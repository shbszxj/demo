using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6.Sqlite.Integration.Console.Models;
using SQLite.CodeFirst;

namespace EF6.Sqlite.Integration.Console
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("CompanyContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteInitializer = new SqliteCreateDatabaseIfNotExists<CompanyContext>(modelBuilder);
            Database.SetInitializer(sqliteInitializer);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
