﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.DTOs
{
    public class BookDetailDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}
