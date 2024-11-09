
namespace Microservice.Infrastructure.Databases;

public class AccountingDbContext : DbContext
{
    public AccountingDbContext
        (DbContextOptions<AccountingDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}