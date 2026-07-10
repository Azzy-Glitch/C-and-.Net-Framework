using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using BookStoreAPI.Models;

namespace BookStoreApi.Data
{
    public class BookStoreApiContext : DbContext
    {
        public BookStoreApiContext(DbContextOptions<BookStoreApiContext> options)
            : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "C# Basics", Author = "John", Price = 500, Stock = 10 },
                new Book { Id = 2, Title = "ASP.NET Guide", Author = "Smith", Price = 700, Stock = 5 },
                new Book { Id = 3, Title = "Clean Code", Author = "Robert Martin", Price = 1200, Stock = 8 },
                new Book { Id = 4, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Price = 1500, Stock = 6 },
                new Book { Id = 5, Title = "Design Patterns", Author = "Erich Gamma", Price = 1800, Stock = 4 },
                new Book { Id = 6, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Price = 2000, Stock = 3 },
                new Book { Id = 7, Title = "Head First C#", Author = "Andrew Stellman", Price = 900, Stock = 7 }
            );
        }
            public DbSet<Book> Books { get; set; } 
    }
}
