using TemplateAPI.Application.Contracts;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Exceptions;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserUpdaterService : IUserUpdaterService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserUpdaterService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto<object>> UpdateAsync(UserUpdateRequestDto user)
    {
        try
        {
            var userDb = await _userRepository.GetByIdAsync(user.Id);

            if (userDb is null)
            {
                throw new NotFoundException("El usuario a actualizar no fue encontrado");
            }

            var userToUpdate = new UserEntity(user.Name,
                user.FirstName,
                user.LastName,
                user.Age,
                user.Email,
                user.UserName,
                user.Password,
                user.Id
            );

            await _userRepository.UpdateAsync(userToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return new ResultDto<object>().Success();
        }
        catch (DomainException e)
        {
            throw new ValidationException(e.Message);
        }
    }
}