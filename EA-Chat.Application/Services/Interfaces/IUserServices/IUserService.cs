using EA_Chat.Application.Utilities;
using EA_Chat.Domain.DTOs.AccountDTOs;
using EA_Chat.Domain.DTOs.UserDTOs;
using EA_Chat.Domain.Models.Users;

namespace EA_Chat.Application.Services.Interfaces.IUserServices;

public interface IUserService
{
    #region Account

    Task<RequestResult<User>> Register(RegisterDto dto, CancellationToken cancellationToken);
    Task<RequestResult<UserDto>> Login(LoginDto dto, CancellationToken cancellationToken);
    
    #endregion
    
    #region User
    
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<User> UpdateAsync(User model, CancellationToken cancellationToken);
    Task<User?> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken);

    #endregion
}