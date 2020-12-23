using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace DesignPattern.SOLID
{
    public class SingleResponsibilityPrinciple : IDesignPatternDemo
    {
        public string Title => "1.1";

        public string Description => "Single Responsibility Principle Demo";

        public void Run()
        {
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            WriteLine(j);

            new Persistence().SaveToFile(j, @"C:\\Temp\\file.txt", true);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }

    public class Journal
    {
        private List<string> entries = new List<string>();
        private int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        /// Not a good idea
        /// Use Persistence instead
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, entries.ToString());
        }

        public void Load(string filename)
        {
            entries = File.ReadAllLines(filename).ToList();
        }
    }
}