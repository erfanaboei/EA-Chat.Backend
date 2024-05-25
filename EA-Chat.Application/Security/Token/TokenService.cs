using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EA_Chat.Domain.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EA_Chat.Application.Security.Token;

public class TokenService: ITokenService
{
    private readonly SymmetricSecurityKey _key;
    
    public TokenService(IConfiguration configuration)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
    }
    
    public string CreateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        var signingCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = signingCredentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}