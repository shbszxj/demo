using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace LearningParallelProgramming.TaskProgramming
{
    public class ExceptionHandling : IDemo
    {
        public string Title => "1.7";

        public string Description => "Task Programming - Exception Handling";

        public void Run()
        {
            BasicHandling();

            TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs args) =>
            {
                // this exception got handled
                args.SetObserved();

                var ae = args.Exception as AggregateException;
                ae?.Handle(ex =>
                {
                    Console.WriteLine($"Policy handled {ex.GetType()}.");
                    return true;
                });
            };

            IterativeHandling();
        }

        private void BasicHandling()
        {
            var t = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Can't do this!") { Source = "t" };
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Can't access this!") { Source = "t2" };
            });

            try
            {
                Task.WaitAll(t, t2);
            }
            catch(AggregateException ae)
            {
                foreach(var e in ae.InnerExceptions)
                {
                    WriteLine($"Exception {e.GetType()} from {e.Source}");
                }
            }
        }

        private void IterativeHandling()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = Task.Factory.StartNew(() =>
            {
                while(true)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(100);
                }
            }, token);

            var t2 = Task.Factory.StartNew(() =>
            {
                throw null;
            });

            cts.Cancel();

            try
            {
                Task.WaitAll(t, t2);
            }
            catch(AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is OperationCanceledException)
                    {
                        WriteLine("Whoops, tasks were canceled.");
                        return true;
                    }
                    else
                    {
                        WriteLine($"Something went wrong:");
                        return false;
                    }
                });
            }
            finally
            {
                WriteLine("\tfaulted\tcompleted\tcancelled");
                WriteLine($"t\t{t.IsFaulted}\t{t.IsCompleted}\t{t.IsCanceled}");
                WriteLine($"t1\t{t2.IsFaulted}\t{t2.IsCompleted}\t{t2.IsCanceled}");
            }
        }
    }
}
