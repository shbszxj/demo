using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningParallelProgramming.DataSharingNSynchronization
{
    public class SpinLocking : IDemo
    {
        public string Title => "2.3";

        public string Description => "Data Sharing and Synchronization - Spin Lock";

        public void Run()
        {
            var tasks = new List<Task>();
            var ba = new BankAccount();

            // spinning avoid overhead of resheduling
            // useful if you expect the wait time to be very short

            SpinLock sl = new SpinLock();

            // owner tracking keeps a record of which thread acquired it to improve debugging

            for (int i = 0; i < 10; ++i)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; ++j)
                    {
                        bool lockTaken = false;
                        try
                        {
                            // sl.IsHeld
                            // sl.IsHeldByCurrentThread
                            sl.Enter(ref lockTaken);
                            ba.Deposit(100);
                        }
                        catch(LockRecursionException e)
                        {
                            Console.WriteLine($"Exception: {e}");
                        }
                        finally
                        {
                            if (lockTaken) sl.Exit();
                        }
                    }
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; ++j)
                    {
                        bool lockTaken = false;
                        try
                        {
                            sl.Enter(ref lockTaken);
                            ba.Withdraw(100);
                        }
                        catch (LockRecursionException e)
                        {
                            Console.WriteLine($"Exception: {e}");
                        }
                        finally
                        {
                            if (lockTaken) sl.Exit();
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance is {ba.Balance}.");
        }

        class BankAccount
        {
            public int Balance { get; private set; }

            public void Deposit(int amount)
            {
                Balance += amount;
            }

            public void Withdraw(int amount)
            {
                Balance -= amount;
            }
        }
    }
}
