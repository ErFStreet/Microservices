namespace Microservice.Application.Features.Base;

public class BaseRequest<TKey> where TKey : notnull
{
    public TKey Id { get; set; } = default!;
}
