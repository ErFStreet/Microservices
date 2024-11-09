namespace Microservice.Application.Features.UserFeatures.CommandHandlers;

public class AddUserHandler : IRequestHandler<AddUserRequest, Result<Guid>>
{
    private readonly IRepository<User, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public AddUserHandler(IRepository<User,
        Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>>
        Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = request.Adapt<User>();

            await _repository.AddAsync(user, cancellationToken);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return Result<Guid>.Success(StatusMessage.Added, user.Id);

            return Result<Guid>.Error(StatusMessage.ServerError, 500);
        }
        catch (Exception)
        {
            return Result<Guid>.Error(StatusMessage.ServerError, 500);
        }
    }
}