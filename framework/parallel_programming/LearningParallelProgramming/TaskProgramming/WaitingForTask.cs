using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace LearningParallelProgramming.TaskProgramming
{
    public class WaitingForTask : IDemo
    {
        public string Title => "1.6";

        public string Description => "Task Programming - Waiting For Task";

        public void Run()
        {
            var cts = new CancellationTokenSource();
            //cts.CancelAfter(3000);
            var token = cts.Token;

            var t = new Task(() =>
            {
                WriteLine("I take 5 seconds");

                for(int i = 0; i < 5; i ++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                WriteLine("I'm done.");
            });
            t.Start();

            var t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            // t.Wait();
            // t.Wait(3000);

            // Task.WaitAll(t, t2);
            // Task.WaitAny(t, t2);

            try
            {
                // throws on a canceled token
                Task.WaitAll(new[] { t, t2 }, 4000, token);
            }
            catch (Exception e)
            {
                WriteLine("Exception: " + e);
            }

            WriteLine($"Task t  status is {t.Status}.");
            WriteLine($"Task t2 status is {t2.Status}.");

            WriteLine("Main program done, press any key.");
            ReadKey();
        }
    }
}
