using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace LearningParallelProgramming.TaskProgramming
{
    public class MonitoringCancelation : IDemo
    {
        public string Title => "1.3";

        public string Description => "Task Programming - Monitoring Cancelation";

        public void Run()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            token.Register(()=>
            {
                WriteLine("Cancelation has been requested.");
            });

            Task t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    else
                    {
                        Write($"{i++}\t");
                        Thread.Sleep(100);
                    }
                }
            });
            t.Start();

            Task t2 = Task.Factory.StartNew(() =>
            {
                char c = 'a';
                while(true)
                {
                    token.ThrowIfCancellationRequested();
                    Write($"{c++}\t");
                    Thread.Sleep(200);
                }
            }, token);

            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                WriteLine("Wait handle released, thus cancelation was requested");
            });

            ReadKey();
            cts.Cancel();
            Thread.Sleep(1000);

            Console.WriteLine($"Task has been canceled. The status of the canceled task 't' is {t.Status}.");
            Console.WriteLine($"Task has been canceled. The status of the canceled task 't2' is {t2.Status}.");
            Console.WriteLine($"t.IsCanceled = {t.IsCanceled}, t2.IsCanceled = {t2.IsCanceled}");
        }
    }
}
