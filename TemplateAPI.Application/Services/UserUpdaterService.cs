using TemplateAPI.Application.Constants;
using TemplateAPI.Application.Contracts;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Exceptions;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserUpdaterService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserUpdaterService
{
    public async Task<ResultDto<object>> UpdateAsync(UserUpdateRequestDto user)
    {
        try
        {
            var userDb = await userRepository.GetByIdAsync(user.Id);

            if (userDb is null)
            {
                throw new NotFoundException(ErrorMessages.UserUpdateNotFound);
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

            await userRepository.UpdateAsync(userToUpdate);
            await unitOfWork.SaveChangesAsync();

            return new ResultDto<object>().Success();
        }
        catch (DomainException e)
        {
            throw new UnprocessableEntityException(e.Message);
        }
    }
}