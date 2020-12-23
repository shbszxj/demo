using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace LearningParallelProgramming.TaskProgramming
{
    public class CompositeCancelation : IDemo
    {
        public string Title => "1.4";

        public string Description => "Task Programming - Composite Cancelation Token";

        public void Run()
        {
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            var paraniod = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, preventative.Token, emergency.Token);

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    paraniod.Token.ThrowIfCancellationRequested();
                    Write($"{i++}\t");
                    Thread.Sleep(100);
                }
            }, paraniod.Token);

            paraniod.Token.Register(() =>
            {
                WriteLine("Cancelation requested");
            });

            ReadKey();

            emergency.Cancel();
        }
    }
}
