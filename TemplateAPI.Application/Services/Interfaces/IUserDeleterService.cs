using TemplateAPI.Application.DTOs;

namespace TemplateAPI.Application.Services.Interfaces;

public interface IUserDeleterService
{
    public Task<ResultDto<object>> DeleteAsync(int id);
}