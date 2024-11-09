namespace Microservice.Application.Features.UserFeatures.Commands;

public class UpdateRoleRequest : BaseRequest<Guid>, IRequest<Result>
{
    public string Name { get; set; } = default!;
}

public class UpdateRoleValidator : AbstractValidator<UpdateRoleRequest>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(StatusMessage.CheckFields)
            .Length(10, 30).WithMessage
            (string.Format("{0} must be between {1} and {2}", 10, 30));
    }
}