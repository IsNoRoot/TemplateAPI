using TemplateAPI.Application.Constants;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserAuthenticatorService(IUserRepository userRepository, TokenService tokenService)
    : IUserAuthenticatorService
{
    public async Task<string> LogIn(CredentialsRequestDto credentials)
    {
        var user = await userRepository.GetByUserName(credentials.UserName);
        if (user is null)
        {
            throw new UnauthorizedException(ErrorMessages.InvalidUserCredentials);
        }

        if (user.Password.Value != credentials.Password)
        {
            throw new UnauthorizedException(ErrorMessages.InvalidUserCredentials);
        }

        var token = tokenService.GenerateToken(user.Id, user.UserName);

        return token;
    }
}