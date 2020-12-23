using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace LearningParallelProgramming.TaskProgramming
{
    public class WaitingForTimeToPass : IDemo
    {
        public string Title => "1.5";

        public string Description => "Task Programming - Waiting For Time To Pass";

        public void Run()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                WriteLine("You have 5 seconds to disarm this bomb by pressing a key");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                WriteLine(cancelled ? "Bomb disarmed." : "BOOM!!!!");
            }, token);
            t.Start();

            Thread.SpinWait(10000);
            SpinWait.SpinUntil(() => true);
            WriteLine("Are you still here?");

            ReadKey();
            cts.Cancel();
        }
    }
}
