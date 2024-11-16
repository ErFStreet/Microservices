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
            .Length(5, 30).WithMessage
            (string.Format("Name must be between {0} and {1}", 10, 30));
    }
}