using EA_Chat.Application.Services.Interfaces.IUserServices;
using EA_Chat.Application.Utilities;
using EA_Chat.Domain.DTOs.AccountDTOs;
using EA_Chat.Domain.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EA_Chat.Controllers;

public class AccountController : BaseController
{
    #region Constractor

    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion

    #region Actions

    [HttpPost("[action]")]
    public async Task<RequestResult<UserDto>> Login(LoginDto dto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest();

        return await _userService.Login(dto, cancellationToken);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<RequestResult<UserDto>> Register(RegisterDto dto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return BadRequest();

        var registerResult = await _userService.Register(dto, cancellationToken);

        return new RequestResult<UserDto>(registerResult.IsSuccess, registerResult.StatusCode, null, registerResult.Message);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto, CancellationToken cancellationToken)
    {
        return Ok();
    }

    #endregion
}