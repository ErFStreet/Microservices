namespace Microservice.Application.Features.UserFeatures.Commands;

public class DeleteUserRequest : BaseRequest<Guid>, IRequest<Result> { }