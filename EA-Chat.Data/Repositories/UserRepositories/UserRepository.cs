using EA_Chat.Data.Context;
using EA_Chat.Domain.Interfaces.IUserRepositories;
using EA_Chat.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EA_Chat.Data.Repositories.UserRepositories;

public class UserRepository: Repository<User, int>, IUserRepository
{
    private readonly EAChatContext _context;
    
    public UserRepository(EAChatContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsExistUsername(string username, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(r => r.UserName == username, cancellationToken);
    }

    public async Task<bool> IsExistEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(r => r.Email == email, cancellationToken);
    }

    public async Task<bool> IsExistMobile(string mobile, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(r => r.Mobile == mobile, cancellationToken);
    }

    public async Task<User?> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken)
    {
        return await _context.Users.SingleOrDefaultAsync(r => r.UserName == username && r.Password == password, cancellationToken);
    }
}