using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Models
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql("User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=postgres;Integrated Security=true;Pooling=true;");
        }

    }
}