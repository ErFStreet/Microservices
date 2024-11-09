namespace Microservice.Application.Common.Responses;

public class Result
{
    public List<string> Messages { get; set; } = [];

    public int StatusCode { get; set; }

    public bool IsSuccess { get; set; }

    public void AddMessage(string message) => Messages.Add(message);

    public void RemoveMessage(string message) => Messages.Remove(message);

    public static Result Success(string message)
      => new Result
      {
          Messages = [message],
          StatusCode = 200,
          IsSuccess = true
      };

    public static Result NotFound(string message)
        => new Result
        {
            Messages = [message],
            StatusCode = 404,
        };

    public static Result Error(string message, int statusCode)
        => new Result
        {
            Messages = [message],
            StatusCode = statusCode,
        };

    public static Result BadRequest(string message)
        => new Result
        {
            Messages = [message],
            StatusCode = 400,
        };
}

public class Result<TData> : Result
{
    public TData Data { get; set; } = default!;

    public static Result<TData> Success(string message, TData data)
      => new Result<TData>
      {
          Messages = [message],
          StatusCode = 200,
          IsSuccess = true,
          Data = data
      };

    public new static Result<TData> NotFound(string message)
        => new Result<TData>
        {
            Messages = [message],
            StatusCode = 404,
        };

    public new static Result<TData> Error(string message, int statusCode)
        => new Result<TData>
        {
            Messages = [message],
            StatusCode = statusCode,
        };

    public new static Result<TData> BadRequest(string message)
        => new Result<TData>
        {
            Messages = [message],
            StatusCode = 400,
        };
}