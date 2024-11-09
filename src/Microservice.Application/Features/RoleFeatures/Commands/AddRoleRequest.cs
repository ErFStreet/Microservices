namespace Microservice.Application.Features.UserFeatures.Commands;

public class AddRoleRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
}

public class AddRoleValidator : AbstractValidator<AddRoleRequest>
{
    public AddRoleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(StatusMessage.CheckFields)
            .Length(10, 30).WithMessage
            (string.Format("{0} must be between {1} and {2}", 10, 30));
    }
}