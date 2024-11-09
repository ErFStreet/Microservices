namespace Microservice.AccountingService.Controllers.Base;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:version}/[controller]")]
public class GenericController<AddRequest, AddRequestResult,
    UpdateRequest, UpdateRequestResult,
    DeleteRequest, DeleteRequestResult,
    GetByIdRequest, GetByIdRequestResult,
    GetAllRequest, GetAllRequestResult> : ControllerBase
{
    private readonly IMediator _mediator;

    public GenericController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<AddRequestResult> AddAsync(AddRequest request,
        CancellationToken cancellation)
    {
        var response =
            await _mediator.Send(request!, cancellation);

        if (response is AddRequestResult result)
        {
            return result;
        }

        throw new Exception(StatusMessage.ServerError);
    }

    public async Task<UpdateRequestResult> UpdateAsync(
        UpdateRequest request,
        CancellationToken cancellation)
    {
        var response =
            await _mediator.Send(request!, cancellation);

        if (response is UpdateRequestResult result)
        {
            return result;
        }

        throw new Exception(StatusMessage.ServerError);
    }

    public async Task<DeleteRequestResult> DeleteAsync(
        DeleteRequest request,
        CancellationToken cancellation)
    {
        var response =
            await _mediator.Send(request!, cancellation);

        if (response is DeleteRequestResult result)
        {
            return result;
        }

        throw new Exception(StatusMessage.ServerError);
    }

    public async Task<GetByIdRequestResult> GetByIdAsync(
        GetByIdRequest request,
        CancellationToken cancellation)
    {
        var response =
            await _mediator.Send(request!, cancellation);

        if (response is GetByIdRequestResult result)
        {
            return result;
        }

        throw new Exception(StatusMessage.ServerError);
    }

    public async Task<GetAllRequestResult> GetAllAsync(
        GetAllRequest request,
        CancellationToken cancellation)
    {
        var response =
            await _mediator.Send(request!, cancellation);

        if (response is GetAllRequestResult result)
        {
            return result;
        }

        throw new Exception(StatusMessage.ServerError);
    }
}
