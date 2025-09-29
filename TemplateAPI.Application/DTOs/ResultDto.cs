namespace TemplateAPI.Application.DTOs;

public class ResultDto<T>
{
    private const string SuccessMessage = "Operación exitosa";
    public T? Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = SuccessMessage;

    public  ResultDto<T> Success()
    {
        return new ResultDto<T>()
        {
            Data = default(T),
            Message = SuccessMessage,
            IsSuccess = true
        };
    }
    
    public  ResultDto<T> Success(T data)
    {
        return new ResultDto<T>()
        {
            Data = data,
            Message = SuccessMessage,
            IsSuccess = true
        };
    }
}
