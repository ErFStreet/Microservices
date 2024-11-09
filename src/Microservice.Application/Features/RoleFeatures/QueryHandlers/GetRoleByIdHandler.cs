namespace Microservice.Application.Features.UserFeatures.QueryHandlers;

public class GetRoleByIdHandler :
    IRequestHandler<GetRoleByIdRequest, Result<RoleDto>>
{
    private readonly IRepository<Role, Guid> _repository;

    public GetRoleByIdHandler(IRepository<Role,
        Guid> repository)
    {
        _repository = repository;
    }

    public async Task<Result<RoleDto>> Handle(GetRoleByIdRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result =
                await _repository.QueryNoTracking
                .Where(current => current.Id == request.Id)
                .Select(current => new RoleDto
                {
                    Id = current.Id,
                    Name = current.Name,
                }).FirstOrDefaultAsync(cancellationToken);

            if (result is null) return Result<RoleDto>
                    .NotFound(StatusMessage.NotFound);

            return Result<RoleDto>.Success(StatusMessage.Added,
                result);
        }
        catch (Exception)
        {
            return Result<RoleDto>.Error(StatusMessage.ServerError, 500);
        }
    }
}