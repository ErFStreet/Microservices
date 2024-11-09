namespace Microservice.Application.Features.UserFeatures.Queries;

public class GetUserByIdRequest : BaseRequest<Guid>, IRequest<Result<UserDto>> { }