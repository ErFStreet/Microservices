namespace Microservice.Application.Features.UserFeatures.Queries;

public class GetRoleByIdRequest : BaseRequest<Guid>, IRequest<Result<RoleDto>> 
{ }