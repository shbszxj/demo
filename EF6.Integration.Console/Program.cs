using EF6.Integration.Console.Models;

namespace EF6.Integration.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var student = new Student() { StudentName = "Bill" };

                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
            System.Console.WriteLine("Demo completed.");
            System.Console.ReadLine();
        }
    }
}
