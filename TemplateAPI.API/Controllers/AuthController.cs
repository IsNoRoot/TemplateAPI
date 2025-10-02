using Microsoft.AspNetCore.Mvc;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Services.Interfaces;

namespace TemplateAPI.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IUserAuthenticatorService userAuthenticatorService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> LogIn([FromBody] CredentialsRequestDto credentials)
    {
        var response = await userAuthenticatorService.LogIn(credentials);
        return Ok(new {token=response});
    }
}