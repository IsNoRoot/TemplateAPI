using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserAuthenticatorService:IUserAuthenticatorService
{
    private readonly IUserRepository _userRepository;
    private readonly TokenService _tokenService;

    public UserAuthenticatorService(IUserRepository userRepository,TokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    public async Task<string> LogIn(CredentialsRequestDto credentials)
    {
        var user = await _userRepository.GetByUserName(credentials.UserName);
        if (user is null)
        {
            throw new UnauthorizedException("Credenciales invalidas");
        }

        if (user.Password.Value == credentials.Password)
        {
            throw new UnauthorizedException("Credenciales invalidas");
        }

        var token = _tokenService.GenerateToken(user.Id, user.UserName);

        return token;
    }
}