using TemplateAPI.Application.Contracts;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Exceptions;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserCreatorService : IUserCreatorService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserCreatorService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto<UserCreateResponseDto>> CreateAsync(UserCreateRequestDto user)
    {
        try
        {
            var userToCreate = new UserEntity(user.Name, user.FirstName, user.LastName, user.Age, user.Email,
                user.UserName, user.Password);

            await _userRepository.AddAsync(userToCreate);
            await _unitOfWork.SaveChangesAsync();

            var data = new UserCreateResponseDto()
            {
                Id = userToCreate.Id,
                Name = userToCreate.Name,
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Age = userToCreate.Age.Value,
                Email = userToCreate.Email.Value,
                UserName = userToCreate.UserName,
                Password = userToCreate.Password.Value
            };

            return new ResultDto<UserCreateResponseDto>().Success(data);
        }
        catch (DomainException ex)
        {
            throw new ValidationException(ex.Message);
        }
    }
}