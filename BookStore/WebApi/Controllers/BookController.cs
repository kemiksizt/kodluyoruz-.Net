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

        //GET
        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.id == id).SingleOrDefault();
            return book;
        }
/*
        // ...Books?id=3
        [HttpGet]
        public Book GetById([FromQuery] string id)
        {
            var book = BookList.Where(book => book.id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
*/

        //POST
        [HttpPost]
        
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.title == newBook.title);

            if(book != null)
                return BadRequest();


            BookList.Add(newBook);
            return Ok();
        }

        //PUT
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.id == id);

            if(book == null)
                return BadRequest();

            book.genreId = updatedBook.genreId != default ? updatedBook.genreId : book.genreId;
            book.pageCount = updatedBook.pageCount != default ? updatedBook.pageCount : book.pageCount;
            book.publishDate = updatedBook.publishDate != default ? updatedBook.publishDate : book.publishDate;
            book.title = updatedBook.title != default ? updatedBook.title : book.title;

            return Ok();    
        }

        //DELETE
        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.id == id);

            if(book == null)
                return BadRequest();


            BookList.Remove(book);
            return Ok();
        }



    }
}