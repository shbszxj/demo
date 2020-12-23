using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace LearningParallelProgramming.DataSharingNSynchronization
{
    public class CriticalSections : IDemo
    {
        public string Title => "2.1";

        public string Description => "Data Sharing and Synchronization - Critical Sections";

        public void Run()
        {
            var tasks = new List<Task>();
            var ba = new BankAccount();

            for(int i=0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for(int j=0; j< 1000; j++)
                    {
                        ba.Deposit(100);
                    }
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            WriteLine($"Final balance is {ba.Balance}.");
            WriteLine("All done here.");
        }

        class BankAccount
        {
            public object padlock = new object();
            public int Balance { get; private set; }

            public void Deposit(int amount)
            {
                lock (padlock)
                {
                    Balance += amount;
                }
            }

            public void Withdraw(int amount)
            {
                lock (padlock)
                {
                    Balance -= amount;
                }
            }
        }
    }
}
