namespace Microservice.Application.Features.UserFeatures.CommandHandlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Result>
{
    private readonly IRepository<User, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(IRepository<User,
        Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            _repository.Delete(request.Id);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return Result.Success(StatusMessage.Deleted);

            return Result.BadRequest(StatusMessage.CheckFields);
        }
        catch (Exception)
        {
            return Result.Error(StatusMessage.ServerError, 500);
        }
    }
}