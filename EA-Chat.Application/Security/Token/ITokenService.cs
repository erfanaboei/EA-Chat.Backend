using EA_Chat.Domain.Models.Users;

namespace EA_Chat.Application.Security.Token;

public interface ITokenService
{
    string CreateToken(User user);
}