using BookCatalogue.Models;
using System.Data.Entity;

namespace BookCatalogue.DAL
{
    public class BookContext : DbContext
    {
        public BookContext():base("BookDB")
        {}

        public DbSet<Book> Books { get; set; }
    }
}