namespace Microservice.Application.Common.DTOs.User;

public class UserDto : BaseDto<Guid>
{
    [DisplayName("Phone Number")]
    public string Phone { get; set; } = default!;

    [DisplayName("First Name")]
    public string FirstName { get; set; } = default!;

    [DisplayName("Last Name")]
    public string LastName { get; set; } = default!;
}
