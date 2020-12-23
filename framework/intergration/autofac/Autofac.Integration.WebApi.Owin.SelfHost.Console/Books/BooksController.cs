using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Domain;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.DTOs;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Models;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Books
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly ILogger _logger;

        private SimpleMemoryCache<Book> _cache;

        private readonly IRepository<Book> _repository;

        public BooksController(ILogger logger, SimpleMemoryCache<Book> cache, IRepository<Book> repository)
        {
            _logger = logger;
            _cache = cache;
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<BookInfoDto>))]
        public IHttpActionResult Get()
        {
            return Ok(_repository.All());
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(BookDetailDto))]
        public IHttpActionResult GetBook(string id)
        {
            return Ok(_repository.Fetch(id));
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BookInfoDto))]
        public IHttpActionResult CreateBook([FromBody]BookInfo book)
        {
            var id = Guid.NewGuid().ToString();
            _repository.Create(new Book
            {
                Id = id,
                Name = book.Name
            });

            return GetBook(id);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateBook(string id, [FromBody] BookInfo book)
        {
            System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            var item = _repository.Fetch(id);
            if (item == null)
                return NotFound();

            item.Name = book.Name;

            _repository.Update(item);

            return GetBook(id);
        }
    }
}
