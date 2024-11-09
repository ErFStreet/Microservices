namespace Microservice.Application.Common.DTOs.Role;

public class RoleDto : BaseDto<Guid>
{
    public string Name { get; set; } = default!;
}
