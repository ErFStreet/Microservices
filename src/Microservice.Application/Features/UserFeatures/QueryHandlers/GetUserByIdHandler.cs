namespace Microservice.Application.Features.UserFeatures.QueryHandlers;

public class GetUserByIdHandler :
    IRequestHandler<GetUserByIdRequest, Result<UserDto>>
{
    private readonly IRepository<User, Guid> _repository;

    public GetUserByIdHandler(IRepository<User,
        Guid> repository)
    {
        _repository = repository;
    }

    public async Task<Result<UserDto>> Handle(GetUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result =
                await _repository.QueryNoTracking
                .Where(current => current.Id == request.Id)
                .Select(current => new UserDto
                {
                    Id = current.Id,
                    FirstName = current.FirstName,
                    LastName = current.LastName,
                    Phone = current.Phone,
                }).FirstOrDefaultAsync(cancellationToken);

            if (result is null) return Result<UserDto>
                    .NotFound(StatusMessage.NotFound);

            return Result<UserDto>.Success(StatusMessage.Added,
                result);
        }
        catch (Exception)
        {
            return Result<UserDto>.Error(StatusMessage.ServerError, 500);
        }
    }
}