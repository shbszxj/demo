using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningParallelProgramming.TaskProgramming
{
    public class CreatingAndStartingTask : IDemo
    {
        public string Title => "1.1";

        public string Description => "Task Programming - Creating And Starting Task";

        public void Run()
        {
            //Task.Factory.StartNew(Write, "hello");

            //var t = new Task(Write, 123);
            //t.Start();

            //Write('-');
            string text1 = "testing", text2 = "this";
            var task1 = new Task<int>(TextLength, text1);
            task1.Start();

            Task<int> task2 = Task.Factory.StartNew(TextLength, text2);

            Console.WriteLine($"Length of '{text1}' is {task1.Result}");
            Console.WriteLine($"Length of '{text2}' is {task2.Result}");
        }

        private void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }

        private void Write(object obj)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(obj);
            }
        }

        private int TextLength(object obj)
        {
            Console.WriteLine($"\nTask with id {Task.CurrentId} processing object {obj}....");
            return obj.ToString().Length;
        }
    }
}
