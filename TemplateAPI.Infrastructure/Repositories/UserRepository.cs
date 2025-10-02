using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TemplateAPI.Application.Constants;
using TemplateAPI.Application.Exceptions;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Repositories;
using TemplateAPI.Infrastructure.Context;

namespace TemplateAPI.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(UserEntity user)
    {
        await dbContext.Users.AddAsync(user);
    }

    public async Task UpdateAsync(UserEntity user)
    {
        var userDb = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
        if (userDb is null)
        {
            throw new NotFoundException(ErrorMessages.UserUpdateNotFound);
        }

        userDb.Name = user.Name;
        userDb.FirstName = user.FirstName;
        userDb.LastName = user.LastName;
        userDb.Age = user.Age;
        userDb.Email = user.Email;
        userDb.UserName = user.UserName;
        userDb.Password = user.Password;
    }

    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<IEnumerable<UserEntity>> GetAsync()
    {
        return await dbContext.Users.ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var userDb = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (userDb is null)
        {
            throw new NotFoundException(ErrorMessages.UserDeletionNotFound);
        }

        dbContext.Users.Remove(userDb);
    }

    public async Task<UserEntity?> GetByUserName(string userName)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        return user;
    }
}