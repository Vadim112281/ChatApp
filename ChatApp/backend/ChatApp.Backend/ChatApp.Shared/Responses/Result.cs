using ChatApp.Shared.Errors;

namespace ChatApp.Shared.Responses;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public List<ErrorItem> Errors { get; set; } = [];
    

    public static Result<T> SuccessResult(T data)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Data = data
        };
    }

    public static Result<T> ErrorsResult(List<ErrorItem> errors)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Errors = errors
        };
    }

    public static Result<T> ErrorResult(ErrorItem error)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Errors = [error]
        };
    }
}