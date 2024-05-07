using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using THWEB.Models;
namespace THWEB.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext>options):base(options) { }
        
        public DbSet<Authors> authors { get; set; }
        public DbSet<Publishers> publishers { get; set; }
        public DbSet<Books> books { get; set; }
        public DbSet<Book_Author> books_author { get; set;}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book_Author>()
                .HasOne(x => x.Authors)
                .WithMany(x => x.Book_Authors)
                .HasForeignKey(x=>x.AuthorId);
            builder.Entity<Book_Author>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Book_Authors)
                .HasForeignKey(x => x.BookId);
            builder.Entity<Books>()
                .HasOne(x => x.Publishers)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.PublisherId);
            new DbInitializer(builder).Seed();
            
        }
        
    }
}
