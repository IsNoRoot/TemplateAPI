using Microsoft.AspNetCore.Mvc;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Services.Interfaces;

namespace TemplateAPI.API.Controllers;

[ApiController]
[Route("user")]
public class UserController : Controller
{
    private readonly IUserCreatorService _userCreatorService;
    private readonly IUserUpdaterService _userUpdaterService;
    private readonly IUserDeleterService _userDeleterService;
    private readonly IUserSearcherService _userSearcherService;
    private readonly IUserFinderService _userFinderService;

    public UserController(
        IUserCreatorService userCreatorService,
        IUserUpdaterService userUpdaterService,
        IUserDeleterService userDeleterService,
        IUserSearcherService userSearcherService,
        IUserFinderService userFinderService
    )
    {
        _userCreatorService = userCreatorService;
        _userUpdaterService = userUpdaterService;
        _userDeleterService = userDeleterService;
        _userSearcherService = userSearcherService;
        _userFinderService = userFinderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserCreateRequestDto user)
    {
        var response = await _userCreatorService.CreateAsync(user);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateRequestDto user)
    {
        await _userUpdaterService.UpdateAsync(user);
        return NoContent();
    }


    [HttpGet]
    public async Task<IActionResult> SearchAsync()
    {
        var response = await _userSearcherService.SearchAsync();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> FindByIdAsync([FromRoute] int id)
    {
        var response = await _userFinderService.ById(id);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _userDeleterService.DeleteAsync(id);
        return Ok();
    }
}