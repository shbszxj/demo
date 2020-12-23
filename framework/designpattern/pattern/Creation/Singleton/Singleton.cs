using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPattern.Creation.Singleton.Singleton
{
    public class Singleton : IDesignPatternDemo
    {
        public string Title => "5.1";

        public string Description => "Singleton - Singleton";

        public void Run()
        {
            var db = SingletonDatabase.Instance;
        }
    }

    interface IDatabase
    {
        int GetPopulation(string name);
    }

    class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private SingletonDatabase()
        {
            WriteLine("Initializing database");
            capitals = new Dictionary<string, int>();
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        // laziness + thread safety
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
        {
            return new SingletonDatabase();
        });

        public static IDatabase Instance => instance.Value;
    }
}