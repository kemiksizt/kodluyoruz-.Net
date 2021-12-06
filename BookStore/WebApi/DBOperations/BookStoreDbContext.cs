using Microsoft.EntityFrameworkCore;
namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        private System.Func<DbContextOptions<BookStoreDbContext>> getRequiredService;

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }

        public BookStoreDbContext(System.Func<DbContextOptions<BookStoreDbContext>> getRequiredService)
        {
            this.getRequiredService = getRequiredService;
        }

        public DbSet<Book> Books { get; set; }
        public System.Func<DbContextOptions<BookStoreDbContext>> GetRequiredService { get; }
    }
}