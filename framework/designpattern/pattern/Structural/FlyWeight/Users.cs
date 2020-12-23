using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Structural.FlyWeight.Users
{
    public class Users : IDesignPatternDemo
    {
        public string Title => "11.1";

        public string Description => "FlyWeight - Users";

        public void Run()
        {
            var users = new List<User2>();

            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            foreach (var firstName in firstNames)
                foreach (var lastName in lastNames)
                    users.Add(new User2($"{firstName} {lastName}"));

            users.ForEach(u => Console.WriteLine(u.FullName));
        }

        public static string RandomString()
        {
            Random rand = new Random();
            return new string(
              Enumerable.Range(0, 10).Select(i => (char)('a' + rand.Next(26))).ToArray());
        }
    }

    public class User
    {
        private string _fullName;

        public User(string fullName)
        {
            _fullName = fullName;
        }
    }

    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;

        public User2(string fullName)
        {
            int getOrAdd(string s)
            {
                int idx = strings.IndexOf(s);
                if (idx != -1) return idx;
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", names);
    }

}
