using EA_Chat.Data.Context;
using EA_Chat.Domain.Interfaces.IUserRepositories;
using EA_Chat.Domain.Models.Users;

namespace EA_Chat.Data.Repositories.UserRepositories;

public class UserRepository: Repository<User, int>, IUserRepository
{
    private readonly EAChatContext _context;
    
    public UserRepository(EAChatContext context) : base(context)
    {
        _context = context;
    }
}