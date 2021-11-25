using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]

    public class BookController : ControllerBase 
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book{
                id  = 1,
                title = "Lean Startup",
                genreId = 1, // Personal Growth
                pageCount = 200,
                publishDate = new DateTime(1997,04,21)
            },
            new Book{
                id  = 2,
                title = "Herland",
                genreId = 1, // Science Fiction
                pageCount = 250,
                publishDate = new DateTime(2010,05,11)
            },
            new Book{
                id  = 3,
                title = "Duned",
                genreId = 2, // Science Fiction
                pageCount = 500,
                publishDate = new DateTime(2001,12,25)
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.id).ToList<Book>();
            return bookList;
        }

    }
}