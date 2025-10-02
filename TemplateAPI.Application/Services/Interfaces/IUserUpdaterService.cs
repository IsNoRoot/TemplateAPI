using TemplateAPI.Application.DTOs;

namespace TemplateAPI.Application.Services.Interfaces;

public interface IUserUpdaterService
{
    public Task<ResultDto> UpdateAsync(UserUpdateRequestDto user);
}