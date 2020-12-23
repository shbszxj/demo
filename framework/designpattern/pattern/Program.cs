using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var objs = new List<IDesignPatternDemo>();
            foreach (var demo in Assembly.GetEntryAssembly().DefinedTypes.Where(o => o.ImplementedInterfaces.Contains(typeof(IDesignPatternDemo))))
            {
                objs.Add(Activator.CreateInstance(demo) as IDesignPatternDemo);
            }
            objs = new List<IDesignPatternDemo>(objs.OrderBy(o => double.Parse(o.Title)));
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
