using EA_Chat.Domain.Models.Users;

namespace EA_Chat.Application.Services.Interfaces.IUserServices;

public interface IUserService
{
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<User> AddAsync(User model, CancellationToken cancellationToken);
    Task<User> UpdateAsync(User model, CancellationToken cancellationToken);
}