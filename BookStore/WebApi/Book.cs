using System;
namespace WebApi
{

    public class Book
    {
        public int id { get; set;}

        public string title { get; set; }

        public int genreId { get; set; }

        public int pageCount { get; set; }

        public DateTime publishDate  { get; set; }
    }
}