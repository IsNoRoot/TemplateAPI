using TemplateAPI.Application.Contracts;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserDeleterService : IUserDeleterService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserDeleterService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto<object>> DeleteAsync(int id)
    {
        var userDb = await _userRepository.GetByIdAsync(id);
        if (userDb is null)
        {
            throw new NotFoundException("El usuario a eliminar no fue encontrado");
        }

        await _userRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return new ResultDto<object>().Success();
    }
}