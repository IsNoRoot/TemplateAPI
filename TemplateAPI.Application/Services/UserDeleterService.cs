using TemplateAPI.Application.Constants;
using TemplateAPI.Application.Contracts;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserDeleterService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserDeleterService
{
    public async Task<ResultDto> DeleteAsync(int id)
    {
        var userDb = await userRepository.GetByIdAsync(id);
        if (userDb is null)
        {
            throw new NotFoundException(ErrorMessages.UserDeletionNotFound);
        }

        await userRepository.DeleteAsync(id);
        await unitOfWork.SaveChangesAsync();

        return ResultDto.Success();
    }
}