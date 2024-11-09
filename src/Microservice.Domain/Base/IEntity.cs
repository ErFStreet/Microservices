namespace Microservice.Domain.Base;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}
