using TemplateAPI.Application.DTOs;

namespace TemplateAPI.Application.Services.Interfaces;

public interface IUserFinderService
{
    public Task<ResultDto<UserResponseDto>> ById(int id);
}