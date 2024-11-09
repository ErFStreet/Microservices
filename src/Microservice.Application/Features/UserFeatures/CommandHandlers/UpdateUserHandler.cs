namespace Microservice.Application.Features.UserFeatures.CommandHandlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Result>
{
    private readonly IRepository<User, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IRepository<User,
        Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var user =
                request.Adapt<User>();

            if (user is null)
                return Result.BadRequest(StatusMessage.CheckFields);

            _repository.Update(user);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return Result.Success(StatusMessage.Updated);

            return Result.Error(StatusMessage.ServerError, 500);
        }
        catch (Exception)
        {
            return Result.Error(StatusMessage.ServerError, 500);
        }
    }
}