using EA_Chat.Application.Services.Interfaces.IUserServices;
using EA_Chat.Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace EA_Chat.Controllers;


public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("[action]")]
    public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
    {
        return await _userService.GetAllAsync(cancellationToken);
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<User?> GetUserById(int id, CancellationToken cancellationToken)
    {
        return await _userService.GetByIdAsync(id, cancellationToken);
    }
}