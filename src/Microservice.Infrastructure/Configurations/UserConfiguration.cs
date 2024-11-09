namespace Microservice.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(current => current.Id);

        builder.Property(current => current.FirstName)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(current => current.LastName)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(current => current.Phone)
            .IsRequired()
            .HasMaxLength(11);

        builder.HasQueryFilter(current => !current.IsSoftDeleted);

        builder.HasOne(current => current.Role)
            .WithMany()
            .HasForeignKey(current=>current.RoleId);
    }
}