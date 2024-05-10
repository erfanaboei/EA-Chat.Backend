using EA_Chat.Application.Services.Interfaces.IUserServices;
using EA_Chat.Domain.Interfaces.IUserRepositories;
using EA_Chat.Domain.Models.Users;

namespace EA_Chat.Application.Services.Implementations.UserServices;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _userRepository.GetAllAsync(cancellationToken);
    }

    public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _userRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<User> AddAsync(User model, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User model, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}