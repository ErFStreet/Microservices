namespace Microservice.Application.Features.UserFeatures.CommandHandlers;

public class AddRoleHandler : IRequestHandler<AddRoleRequest, Result<Guid>>
{
    private readonly IRepository<Role, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public AddRoleHandler(IRepository<Role,
        Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>>
        Handle(AddRoleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var role = request.Adapt<Role>();

            await _repository.AddAsync(role, cancellationToken);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return Result<Guid>.Success(StatusMessage.Added, role.Id);

            return Result<Guid>.Error(StatusMessage.ServerError, 500);
        }
        catch (Exception)
        {
            return Result<Guid>.Error(StatusMessage.ServerError, 500);
        }
    }
}