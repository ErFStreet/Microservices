namespace Microservice.Domain.Entities.Accounting;

public class User : BaseEntity<Guid>
{
    public string Phone { get; init; } = default!;

    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public Guid RoleId { get; set; } = default!;

    public Role Role { get; set; } = default!;
}