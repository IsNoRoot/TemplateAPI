using Microsoft.EntityFrameworkCore;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Repositories;
using TemplateAPI.Infrastructure.Context;

namespace TemplateAPI.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(UserEntity user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task UpdateAsync(UserEntity user)
    {
        var userDb = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
        if (userDb is null)
        {
            throw new Exception("El usuario a actualizar no existe");
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
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<IEnumerable<UserEntity>> GetAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var userDb = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (userDb is null)
        {
            throw new Exception("El usuario a actualizar no existe");
        }

        _dbContext.Users.Remove(userDb);
    }

    public async Task<UserEntity?> GetByUserName(string userName)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        return user;
    }

    public async Task SaveChangueAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}