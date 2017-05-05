using BookCoreAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace BookCoreAPI.Data
{
    public class DbAPIContext : DbContext
    {
        public DbAPIContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BookModel> Books { get; set; }
    }
}