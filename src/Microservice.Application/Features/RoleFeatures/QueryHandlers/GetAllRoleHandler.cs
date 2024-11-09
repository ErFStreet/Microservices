namespace Microservice.Application.Features.UserFeatures.QueryHandlers;

public class GetAllRoleHandler : IRequestHandler<GetAllRoleRequest,
    Result<List<RoleDto>>>
{
    private readonly IRepository<Role, Guid> _repository;

    public GetAllRoleHandler(IRepository<Role, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<RoleDto>>> Handle(GetAllRoleRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result =
                await _repository.QueryNoTracking
                .Select(current => new RoleDto
                {
                    Id = current.Id,
                    Name = current.Name,
                }).ToListAsync(cancellationToken);

            if (result.Count > 0) return Result<List<RoleDto>>
                    .NotFound(StatusMessage.NotFound);

            return Result<List<RoleDto>>.Success(StatusMessage.Added,
                result);
        }
        catch (Exception)
        {
            return Result<List<RoleDto>>.Error(StatusMessage.ServerError
                , 500);
        }
    }
}