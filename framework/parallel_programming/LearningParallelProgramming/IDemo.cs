using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningParallelProgramming
{
    interface IDemo
    {
        string Title { get; }
        string Description { get; }
        void Run();
    }
}
