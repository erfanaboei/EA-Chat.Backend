using System.Security.Cryptography;
using System.Text;

namespace EA_Chat.Application.Security.PasswordHelper;

public class PasswordHelper: IPasswordHelper
{
    [Obsolete("Obsolete")]
    public string EncodePasswordMd5(string password)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        var originalBytes = Encoding.Default.GetBytes(password);
        var encodedBytes = md5.ComputeHash(originalBytes);
        return BitConverter.ToString(encodedBytes);
    }
}