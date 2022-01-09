using ApiAspNetCoreServer.DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiAspNetCoreServer.DataModel
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Book>().HasOne(x => x.BookImage).WithOne().OnDelete(DeleteBehavior.Cascade);
            //base.OnModelCreating(builder);
        }
    }
}