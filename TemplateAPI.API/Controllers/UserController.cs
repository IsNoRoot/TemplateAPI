using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TemplateAPI.API.Constants;
using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Services.Interfaces;

namespace TemplateAPI.API.Controllers;

[ApiController]
[Route("user")]
public class UserController(
    IUserCreatorService userCreatorService,
    IUserUpdaterService userUpdaterService,
    IUserDeleterService userDeleterService,
    IUserSearcherService userSearcherService,
    IUserFinderService userFinderService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserCreateRequestDto user)
    {
        var response = await userCreatorService.CreateAsync(user);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateRequestDto user, [FromRoute] int id)
    {
        if (user.Id != id)
        {
            return BadRequest();
        }

        var response=await userUpdaterService.UpdateAsync(user);
        return Ok(response);
    }


    [HttpGet("all")]
    public async Task<IActionResult> SearchAsync()
    {
        var response = await userSearcherService.SearchAsync();
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> SearchAsync([FromQuery] PagingParametersDto parametersDto)
    {
        var response = await userSearcherService.SearchAsync(parametersDto);
        Response.Headers.Append(HeaderKeys.Pagination, JsonSerializer.Serialize(response.Data.PagingMetadata));
        return Ok(response.Map(response.Data.Data));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> FindByIdAsync([FromRoute] int id)
    {
        var response = await userFinderService.ById(id);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var response=await userDeleterService.DeleteAsync(id);
        return Ok(response);
    }
}