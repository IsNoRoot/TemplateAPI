using TemplateAPI.Domain.Entities;

namespace TemplateAPI.Domain.Repositories;

public interface IUserRepository
{
    public Task AddAsync(UserEntity user);
    public Task UpdateAsync(UserEntity user);
    public Task<UserEntity?> GetByIdAsync(int id);
    public Task<IEnumerable<UserEntity>> GetAsync();
    public Task DeleteAsync(int id);
    public Task<UserEntity?> GetByUserName(string userName);
}