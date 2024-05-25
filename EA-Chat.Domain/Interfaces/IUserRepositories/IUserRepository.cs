using EA_Chat.Domain.Models.Users;

namespace EA_Chat.Domain.Interfaces.IUserRepositories;

public interface IUserRepository:IRepository<User, int>
{
    Task<bool> IsExistUsername(string username, CancellationToken cancellationToken);
    Task<bool> IsExistEmail(string email, CancellationToken cancellationToken);
    Task<bool> IsExistMobile(string mobile, CancellationToken cancellationToken);
    Task<User?> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken);
}