﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.Owin.SelfHost.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://localhost:4000"))
            {
                System.Console.WriteLine("Press [enter] to quit...");
                System.Console.ReadLine();
            }
        }
    }
}
