using Book__Management_Final.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Book__Management_Final.DataAccess.Models.Context
{
    public class BookManagementDbContext : DbContext
    {
        public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<RentedBook> RentedBooks { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Role).HasDefaultValue("User");
        }
    }
}
