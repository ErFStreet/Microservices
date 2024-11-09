namespace Microservice.Application.Features.UserFeatures.Commands;

public class UpdateUserRequest : BaseRequest<Guid>, IRequest<Result>
{
    [DisplayName("Phone Number")]
    [StringLength(11, ErrorMessage = "{0} are more than {1}")]
    public string Phone { get; set; } = default!;

    [DisplayName("First Name")]
    [StringLength(30, ErrorMessage = "{0} are more than {1}")]
    public string FirstName { get; set; } = default!;

    [DisplayName("Last Name")]
    [StringLength(30, ErrorMessage = "{0} are more than {1}")]
    public string LastName { get; set; } = default!;
}

public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
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