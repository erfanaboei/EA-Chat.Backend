using EA_Chat.Application.Security.PasswordHelper;
using EA_Chat.Application.Security.Token;
using EA_Chat.Application.Senders.Mail;
using EA_Chat.Application.Services.Interfaces.IUserServices;
using EA_Chat.Application.Utilities;
using EA_Chat.Domain.DTOs.AccountDTOs;
using EA_Chat.Domain.DTOs.UserDTOs;
using EA_Chat.Domain.Interfaces.IUserRepositories;
using EA_Chat.Domain.Models.Users;

namespace EA_Chat.Application.Services.Implementations.UserServices;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHelper _passwordHelper;
    private readonly ISendMail _sendMail;
    private readonly ITokenService _tokenService;
    
    public UserService(IUserRepository userRepository, IPasswordHelper passwordHelper, ISendMail sendMail, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordHelper = passwordHelper;
        _sendMail = sendMail;
        _tokenService = tokenService;
    }

    #region Account
    
    public async Task<RequestResult<User>> Register(RegisterDto dto, CancellationToken cancellationToken)
    {
        if (await _userRepository.IsExistUsername(dto.UserName, cancellationToken))
            return new RequestResult<User>(false, RequestResultStatusCode.Conflict, null, "نام کاربری وارد شده از قبل موجود است");

        if (await _userRepository.IsExistEmail(dto.Email, cancellationToken)) 
            return new RequestResult<User>(false, RequestResultStatusCode.Conflict, null, "ایمیل وارد شده از قبل موجود است");

        if (await _userRepository.IsExistMobile(dto.Mobile, cancellationToken)) 
            return new RequestResult<User>(false, RequestResultStatusCode.Conflict, null, "موبایل وارد شده از قبل موجود است");

        var user = new User()
        {
            UserName = dto.UserName.ToLower().Trim(),
            Email = dto.Email.ToLower().Trim(),
            Mobile = dto.Mobile,
            Password = _passwordHelper.EncodePasswordMd5(dto.Password),
            IsActive = false,
            RegisterDate = DateTime.Now
        };

        user = await _userRepository.AddAsync(user, cancellationToken);

        // _sendMail.Send(user.Email, "فعالسازی حساب کاربری", "حساب کاربری خود را فعال کنید");
        
        return user;
    }

    public async Task<RequestResult<UserDto>> Login(LoginDto dto, CancellationToken cancellationToken)
    {
        var user = await GetByUsernameAndPassword(dto.Username.ToLower().Trim(), _passwordHelper.EncodePasswordMd5(dto.Password), cancellationToken);
        if (user == null)
            return new RequestResult<UserDto>(false, RequestResultStatusCode.NotFound, null, "کاربری با مشخصات وارد شده یافت نشد!");

        if (!user.IsActive)
            return new RequestResult<UserDto>(false, RequestResultStatusCode.UnAuthorized, null, "حساب کاربری شما فعال نیست!");
        
        return new RequestResult<UserDto>(
            true,
            RequestResultStatusCode.Success,
            new UserDto()
            {
                Username = user.UserName,
                Email = user.Email,
                Mobile = user.Mobile,
                Token = _tokenService.CreateToken(user),
                IsActivate = user.IsActive,
                RegisterData = user.RegisterDate.ToShortDateString()
            },
            "شما با موفقیت وارد حساب کاربری خود شدید.");
    }

    #endregion
    
    #region User

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _userRepository.GetAllAsync(cancellationToken);
    }

    public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _userRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<User> UpdateAsync(User model, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByUsernameAndPassword(username, password, cancellationToken);
    }

    #endregion
}