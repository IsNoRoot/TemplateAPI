using TemplateAPI.Application.DTOs;

namespace TemplateAPI.Application.Services.Interfaces;

public interface IUserCreatorService
{
    public Task<ResultDto<UserCreateResponseDto>> CreateAsync(UserCreateRequestDto user);
}