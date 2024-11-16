namespace Microservice.AccountingService.Controllers.V1;

public class RoleController : GenericController
    <AddRoleRequest, Result<Guid>,
    UpdateRoleRequest, Result,
    DeleteRoleRequest, Result,
    GetRoleByIdRequest, Result<RoleDto>,
    GetAllRoleRequest, Result<List<RoleDto>>>
{
    public RoleController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<ActionResult<Result<Guid>>> Add(
        AddRoleRequest request, CancellationToken cancellation)
        => await AddAsync(request, cancellation);

    [HttpPut]
    public async Task<ActionResult<Result>> Update(
        UpdateRoleRequest request, CancellationToken cancellation)
        => await UpdateAsync(request, cancellation);

    [HttpDelete]
    public async Task<ActionResult<Result>> Delete(
        DeleteRoleRequest request, CancellationToken cancellation)
        => await DeleteAsync(request, cancellation);

    [HttpGet("Role")]
    public async Task<ActionResult<Result<RoleDto>>> GetById(
        GetRoleByIdRequest request, CancellationToken cancellation)
        => await GetByIdAsync(request, cancellation);

    [HttpGet("Roles")]
    public async Task<ActionResult<Result<List<RoleDto>>>> GetAll(
          CancellationToken cancellation)
        => await GetAllAsync(new GetAllRoleRequest(), cancellation);
}
