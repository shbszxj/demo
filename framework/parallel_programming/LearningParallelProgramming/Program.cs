using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LearningParallelProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var objs = new List<IDemo>();
            foreach (var demo in Assembly.GetEntryAssembly().DefinedTypes.Where(o => o.ImplementedInterfaces.Contains(typeof(IDemo))))
            {
                objs.Add(Activator.CreateInstance(demo) as IDemo);
            }
            objs = new List<IDemo>(objs.OrderBy(o => double.Parse(o.Title)));
            objs.ForEach(o => WriteLine($"{o.Title} : {o.Description}"));
            WriteLine("Please enter the number that you want to run ?");
            var input = ReadLine();
            foreach (var want in objs.OrderBy(o => double.Parse(o.Title)).Where(o => o.Title == input))
            {
                want.Run();
            }
            Read();
        }
    }
}
