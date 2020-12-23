using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace CQRSLite.Integration.Console
{
    class Program
    {
        private const string BaseAddress = "http://localhost:4000";

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(BaseAddress))
            {

                System.Console.WriteLine("Press enter to exit...");
                System.Console.ReadLine();
            }
        }
    }
}
