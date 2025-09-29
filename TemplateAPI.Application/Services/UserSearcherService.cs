using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserSearcherService : IUserSearcherService
{
    private readonly IUserRepository _userRepository;

    public UserSearcherService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultDto<IEnumerable<UserResponseDto>>> SearchAsync()
    {
        var response = await _userRepository.GetAsync();

        var data = response.Select<UserEntity, UserResponseDto>(user =>
        {
            var dto = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age.Value,
                Email = user.Email.Value,
                UserName = user.UserName,
                Password = user.Password.Value
            };

            return dto;
        });

        return new ResultDto<IEnumerable<UserResponseDto>>().Success(data);
    }
}