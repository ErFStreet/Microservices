namespace Microservice.Application.Features.UserFeatures.CommandHandlers;

public class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, Result>
{
    private readonly IRepository<Role, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleHandler(IRepository<Role,
        Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRoleRequest request,
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