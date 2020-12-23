using System.ComponentModel.DataAnnotations;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Models
{
    public class BookInfo
    {
        [Required]
        public string Name { get; set; }
    }
}
