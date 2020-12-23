using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace LearningParallelProgramming.TaskProgramming
{
    public class CancelableTasks : IDemo
    {
        public string Title => "1.2";

        public string Description => "Task Programming - Cancel Task";

        public void Run()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Task t = new Task(() =>
            {
                int i = 0;
                while(true)
                {
                    token.ThrowIfCancellationRequested();
                    WriteLine($"{i++}\t");
                }
            });
            t.Start();

            ReadKey();
            cts.Cancel();
            WriteLine("Task has been canceled");
        }
    }
}
