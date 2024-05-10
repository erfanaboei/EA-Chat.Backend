using EA_Chat.Domain.Models.Users;

namespace EA_Chat.Domain.Interfaces.IUserRepositories;

public interface IUserRepository:IRepository<User, int>
{
    
}