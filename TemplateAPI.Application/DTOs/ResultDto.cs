using TemplateAPI.Application.Constants;

namespace TemplateAPI.Application.DTOs;

public class ResultDto<T>
{
    private const string OperationSuccessful = SuccessMessages.OperationSuccessful;
    public T? Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = OperationSuccessful;

    public  ResultDto<T> Success()
    {
        return new ResultDto<T>()
        {
            Data = default(T),
            Message = OperationSuccessful,
            IsSuccess = true
        };
    }
    
    public  ResultDto<T> Success(T data)
    {
        return new ResultDto<T>()
        {
            Data = data,
            Message = OperationSuccessful,
            IsSuccess = true
        };
    }
}
