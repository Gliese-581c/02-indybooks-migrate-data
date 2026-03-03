using Microsoft.EntityFrameworkCore;
using IndyBooks.Models;

namespace IndyBooks.Services
{
    public class IndyBooksDataContext:DbContext
    {
        public IndyBooksDataContext(DbContextOptions<IndyBooksDataContext> options) : base(options)
        {
        }

        //Access to Collections representing DB tables
        public DbSet<Book> Books { get; set; }
        //TODO: Add the Writers DbSet
        public DbSet<Writer> Writers { get; set; }

        // Used to fine tune certain aspects of the Data model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Uncomment this code - it will makes sure each Book always loads its Writer data
            /*
            modelBuilder.Entity<Book>()
                .Navigation(b=>b.Author)
                .AutoInclude();
            */

        }
    }
}
