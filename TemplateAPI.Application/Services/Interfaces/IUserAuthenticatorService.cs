using TemplateAPI.Application.DTOs;

namespace TemplateAPI.Application.Services.Interfaces;

public interface IUserAuthenticatorService
{
    public Task<string> LogIn(CredentialsRequestDto credentials);
}