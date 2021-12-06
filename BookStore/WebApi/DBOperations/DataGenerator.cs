using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange
                (
                    new Book
                    {
                        //id  = 1,
                        title = "Lean Startup",
                        genreId = 1, // Personal Growth
                        pageCount = 200,
                        publishDate = new DateTime(1997,04,21)
                    },
                    new Book
                    {
                        //id  = 2,
                        title = "Herland",
                        genreId = 1, // Science Fiction
                        pageCount = 250,
                        publishDate = new DateTime(2010,05,11)
                    },
                    new Book
                    {
                        //id  = 3,
                        title = "Duned",
                        genreId = 2, // Science Fiction
                        pageCount = 500,
                        publishDate = new DateTime(2001,12,25)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}