using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Domain;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.DTOs;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Models;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Books
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private ICollection<Book> _books;
        

        public BooksController()
        {
            _books = new List<Book>()
            {
                new Book()
                {
                    Id = Guid.Empty.ToString(),
                    Name = "Book 1",
                    Author = "Jack",
                    Description = "A test book"
                },
                new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Book 2",
                    Author = "Jack",
                    Description = "A test book too"
                }
            };
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<BookInfoDto>))]
        public IHttpActionResult Get()
        {
            return Ok(_books);
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(BookDetailDto))]
        public IHttpActionResult GetBook(string id)
        {
            return Ok(_books.FirstOrDefault(b => b.Id == id));
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BookInfoDto))]
        public IHttpActionResult CreateBook([FromBody]BookInfo book)
        {
            var id = Guid.NewGuid().ToString();
            _books.Add(new Book
            {
                Id = id,
                Name = book.Name
            });

            System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            return GetBook(id);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateBook(string id, [FromBody] BookInfo book)
        {
            System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            var item = _books.FirstOrDefault(b => b.Id == id);
            if (item == null)
                return NotFound();

            item.Name = book.Name;
            return GetBook(id);
        }
    }
}
