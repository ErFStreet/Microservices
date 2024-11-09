namespace Microservice.Application.Features.UserFeatures.QueryHandlers;

public class GetAllUserHandler : IRequestHandler<GetAllUserRequest,
    Result<List<UserDto>>>
{
    private readonly IRepository<User, Guid> _repository;

    public GetAllUserHandler(IRepository<User, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<UserDto>>> Handle(GetAllUserRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result =
                await _repository.QueryNoTracking
                .Select(current => new UserDto
                {
                    Id = current.Id,
                    FirstName = current.FirstName,
                    LastName = current.LastName,
                    Phone = current.Phone,
                }).ToListAsync(cancellationToken);

            if (result.Count > 0) return Result<List<UserDto>>
                    .NotFound(StatusMessage.NotFound);

            return Result<List<UserDto>>.Success(StatusMessage.Added,
                result);
        }
        catch (Exception)
        {
            return Result<List<UserDto>>.Error(StatusMessage.ServerError
                , 500);
        }
    }
}