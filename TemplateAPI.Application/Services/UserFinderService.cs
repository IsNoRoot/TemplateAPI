using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserFinderService : IUserFinderService
{
    private readonly IUserRepository _userRepository;

    public UserFinderService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultDto<UserResponseDto>> ById(int id)
    {
        var response = await _userRepository.GetByIdAsync(id);

        if (response is null)
        {
            throw new NotFoundException("Usuario no encontrado");
        }

        var data = new UserResponseDto()
        {
            Id = response!.Id,
            Name = response.Name,
            FirstName = response.FirstName,
            LastName = response.LastName,
            Age = response.Age.Value,
            Email = response.Email.Value,
            UserName = response.UserName,
            Password = response.Password.Value
        };

        return new ResultDto<UserResponseDto>().Success(data);
    }
}