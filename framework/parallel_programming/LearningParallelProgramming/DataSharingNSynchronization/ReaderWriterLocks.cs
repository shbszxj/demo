using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningParallelProgramming.DataSharingNSynchronization
{
    public class ReaderWriterLocks : IDemo
    {
        public string Title => "2.5";

        public string Description => "Reader Writer Lock";

        private ReaderWriterLockSlim _padlock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        public void Run()
        {
            int x = 0;

            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    _padlock.EnterReadLock();
                    //_padlock.EnterUpgradeableReadLock();

                    //if (i % 2 == 0)
                    //{
                    //    _padlock.EnterWriteLock();
                    //    x++;
                    //    _padlock.ExitWriteLock();
                    //}

                    // can now read
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Entered read lock, x = {x}, pausing for 5sec");
                    Thread.Sleep(5000);

                    _padlock.ExitReadLock();
                    //_padlock.ExitUpgradeableReadLock();

                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Exited read lock, x = {x}.");
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e);
                    return true;
                });
            }

            Random random = new Random();

            while (true)
            {
                Console.ReadKey();
                _padlock.EnterWriteLock();
                Console.WriteLine("Write lock acquired");
                int newValue = random.Next(10);
                x = newValue;
                Console.WriteLine($"Set x = {x}");
                _padlock.ExitWriteLock();
                Console.WriteLine("Write lock released");
            }
        }
    }
}
