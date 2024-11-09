namespace Microservice.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(current => current.Id);

        builder.Property(current => current.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasQueryFilter(current => !current.IsSoftDeleted);
    }
}