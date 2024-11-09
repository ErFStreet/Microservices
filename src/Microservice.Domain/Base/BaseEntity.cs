namespace Microservice.Domain.Base;

public class BaseEntity<TKey> : IEntity<TKey> where TKey : notnull
{
    public TKey Id { get; set; } = default!;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public bool IsSoftDeleted { get; set; }
}
