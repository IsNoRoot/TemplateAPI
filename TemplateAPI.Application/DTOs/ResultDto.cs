using TemplateAPI.Application.Constants;

namespace TemplateAPI.Application.DTOs;

public class ResultDto
{
    public bool IsSuccess { get; protected set; }
    public string Message { get; protected set; } = string.Empty;

    // El constructor es protegido para forzar el uso de los métodos de fábrica.
    protected ResultDto()
    {
    }

    public static ResultDto Success(string message = "Operación exitosa.")
    {
        return new ResultDto
        {
            IsSuccess = true,
            Message = message
        };
    }

    public static ResultDto Fail(string message)
    {
        return new ResultDto
        {
            IsSuccess = false,
            Message = message
        };
    }
}

public class ResultDto<T> : ResultDto
{
    public T? Data { get; private set; }

    private ResultDto()
    {
    }

    public static ResultDto<T> Success(T data, string message = SuccessMessages.OperationSuccessful)
    {
        return new ResultDto<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message
        };
    }

    public new static ResultDto<T> Fail(string message)
    {
        return new ResultDto<T>
        {
            IsSuccess = false,
            Message = message,
            Data = default(T)
        };
    }

    /// <summary>
    /// Crea un nuevo ResultDto con data diferente, pero manteniendo el estado (IsSuccess y Message).
    /// </summary>
    /// <typeparam name="U">El tipo de la nueva data.</typeparam>
    /// <param name="newData">La nueva data a asignar.</param>
    /// <returns>Un nuevo ResultDto del tipo U.</returns>
    public ResultDto<U> Map<U>(U newData)
    {
        return new ResultDto<U>
        {
            Data = newData,
            IsSuccess = this.IsSuccess,
            Message = this.Message
        };
    }
}