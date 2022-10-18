using BookStoreApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Data
{
    public class BooksDbContext : IdentityDbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }  
    }
}
