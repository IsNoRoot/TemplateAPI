using TemplateAPI.Application.DTOs;
using TemplateAPI.Application.Services.Interfaces;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Repositories;

namespace TemplateAPI.Application.Services;

public class UserSearcherService(IUserRepository userRepository) : IUserSearcherService
{
    public async Task<ResultDto<IEnumerable<UserResponseDto>>> SearchAsync()
    {
        var response = await userRepository.GetAsync();

        var data = response.Select<UserEntity, UserResponseDto>(user =>
        {
            var dto = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age.Value,
                Email = user.Email.Value,
                UserName = user.UserName,
                Password = user.Password.Value
            };

            return dto;
        });

        return ResultDto<IEnumerable<UserResponseDto>>.Success(data);
    }

    public async Task<ResultDto<(IEnumerable<UserResponseDto> Data, PagingMetadataDto PagingMetadata)>> SearchAsync(
        PagingParametersDto pagingParameters)
    {
        var userResponse = await userRepository.GetAsync(pagingParameters.PageNumber, pagingParameters.PageSize);

        var data = userResponse.Data.Select<UserEntity, UserResponseDto>(user =>
        {
            var dto = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age.Value,
                Email = user.Email.Value,
                UserName = user.UserName,
                Password = user.Password.Value
            };

            return dto;
        });

        var pagingMetadata = new PagingMetadataDto(userResponse.TotalItems, pagingParameters.PageSize);

        return ResultDto<(IEnumerable<UserResponseDto> Data, PagingMetadataDto PagingMetadata)>.Success((data,
            pagingMetadata));
    }
}