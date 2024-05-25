namespace EA_Chat.Application.Security.PasswordHelper;

public interface IPasswordHelper
{
    string EncodePasswordMd5(string password);
}