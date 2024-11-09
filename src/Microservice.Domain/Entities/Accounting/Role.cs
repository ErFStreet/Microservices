namespace Microservice.Domain.Entities.Accounting;

public class Role : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;

    public ICollection<User> Users { get; set; } = [];
}