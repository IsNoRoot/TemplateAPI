using TemplateAPI.Application.DTOs;

namespace TemplateAPI.Application.Services.Interfaces;

public interface IUserSearcherService
{
    public Task<ResultDto<IEnumerable<UserResponseDto>>> SearchAsync();
}