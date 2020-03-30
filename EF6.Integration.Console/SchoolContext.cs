using EF6.Integration.Console.Configurations;
using EF6.Integration.Console.Models;
using System.Data.Entity;

namespace EF6.Integration.Console
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {
            Database.SetInitializer<SchoolContext>(new SchoolDbInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfigurations());

            modelBuilder.Entity<Teacher>()
                .ToTable("TeacherInfo");

            modelBuilder.Entity<Teacher>()
                .MapToStoredProcedures();
        }
    }
}
