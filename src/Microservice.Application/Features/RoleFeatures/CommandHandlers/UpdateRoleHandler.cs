namespace Microservice.Application.Features.UserFeatures.CommandHandlers;

public class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, Result>
{
    private readonly IRepository<Role, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleHandler(IRepository<Role,
        Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRoleRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var role =
                request.Adapt<Role>();

            if (role is null)
                return Result.BadRequest(StatusMessage.CheckFields);

            _repository.Update(role);

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