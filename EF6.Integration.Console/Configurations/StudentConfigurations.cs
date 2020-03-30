using EF6.Integration.Console.Models;
using System.Data.Entity.ModelConfiguration;

namespace EF6.Integration.Console.Configurations
{
    public class StudentConfigurations : EntityTypeConfiguration<Student>
    {
        public StudentConfigurations()
        {
            Property(s => s.StudentName)
                .IsRequired()
                .HasMaxLength(50);

            Property(s => s.StudentName)
                .IsConcurrencyToken();

            // Configure a one-to-one relationship between Student & StudentAddress
            HasOptional(s => s.Address) // Make Student.Address property optional (nullable)
                .WithRequired(ad => ad.Student); // Make StudentAddress.Student property as required (not null)
        }
    }
}
