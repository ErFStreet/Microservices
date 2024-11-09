namespace Microservice.Infrastructure.Databases;

public class BlogDbContext : DbContext
{
    public BlogDbContext
        (DbContextOptions<BlogDbContext> options)
        : base(options) { }
    
    public DbSet<Blog> Blogs { get; set; }
}