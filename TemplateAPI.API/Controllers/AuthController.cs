using Microsoft.AspNetCore.Mvc;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Services.Interfaces;

namespace TemplateAPI.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{
    private readonly IUserAuthenticatorService _userAuthenticatorService;

    public AuthController(IUserAuthenticatorService userAuthenticatorService)
    {
        _userAuthenticatorService = userAuthenticatorService;
    }
    [HttpPost]
    public async Task<IActionResult> LogIn([FromBody]CredentialsRequestDto credentials)
    {
        var response=await _userAuthenticatorService.LogIn(credentials);
        return Ok(response);
    }
}