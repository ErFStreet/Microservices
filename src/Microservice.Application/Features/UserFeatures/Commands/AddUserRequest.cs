namespace Microservice.Application.Features.UserFeatures.Commands;

public class AddUserRequest : IRequest<Result<Guid>>
{
    public string Phone { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}

public class AddUserValidator : AbstractValidator<AddUserRequest>
{
    public AddUserValidator()
    {
        RuleFor(current => current.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(10, 40).WithMessage(string.Format("{0} must be between {1} and {2} " +
            "characters",
            "FirstName", 10, 40));

        RuleFor(current => current.LastName)
           .NotEmpty().WithMessage("Last name is required.")
           .Length(10, 40).WithMessage(string.Format("{0} must be between {1} and {2} " +
           "characters", "Last Name", 10, 40));

        RuleFor(current => current.Phone)
           .NotEmpty().WithMessage("Phone is required.")
           .Length(11).WithMessage(string.Format("{0} must be {1}", "Phone", 11));
    }
}