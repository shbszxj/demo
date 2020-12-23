using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.DTOs;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Models;
using Microsoft.Owin.Hosting;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console
{
    class Program
    {
        private const string BaseAddress = "http://localhost:4000";

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(BaseAddress))
            {
                System.Console.WriteLine("=======================================");
                GetBooks();

                System.Console.WriteLine("=======================================");
                GetBook(Guid.Empty.ToString());

                System.Console.WriteLine("=======================================");
                CreateBook("Test book 2");

                System.Console.WriteLine("=======================================");
                UpdateBook("77777777");

                System.Console.ReadLine();
            }
        }

        private static void GetBooks()
        {
            string api = "api/books";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync($"{BaseAddress}/{api}").Result;
            }
        }

        private static void GetBook(string id)
        {
            string api = $"api/books/{id}";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync($"{BaseAddress}/{api}").Result;
            }
        }

        private static void CreateBook(string name)
        {
            string api = $"api/books";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsJsonAsync($"{BaseAddress}/{api}", new BookInfo
                {
                    Name = name
                }).Result;
            }
        }

        private static void UpdateBook(string name)
        {
            string api = $"api/books";

            using (var httpClient = new HttpClient())
            {
                var bookCreated = httpClient.PostAsJsonAsync($"{BaseAddress}/{api}", new BookInfo
                {
                    Name = "6666"
                }).Result.Content.ReadAsAsync<BookInfoDto>();

                var client = new HttpClient();
                var response = client.PutAsJsonAsync($"{BaseAddress}/{api}/{bookCreated.Result.Id}", new BookInfo
                {
                    Name = name
                });
                System.Console.WriteLine(response.Result);
            }
        }
    }
}
