namespace Microservice.Application.Common.DTOs.Base;

public class BaseDto<TKey> where TKey : notnull
{
    [DisplayName("Key")]
    public TKey Id { get; set; } = default!;
}
