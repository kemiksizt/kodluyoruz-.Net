using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{

    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set;}

        public string title { get; set; }

        public int genreId { get; set; }

        public int pageCount { get; set; }

        public DateTime publishDate  { get; set; }
    }
}