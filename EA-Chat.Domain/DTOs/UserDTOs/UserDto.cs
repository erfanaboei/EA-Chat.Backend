namespace EA_Chat.Domain.DTOs.UserDTOs;

public class UserDto
{
    public string Token { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public bool IsActivate { get; set; }
    public string RegisterData { get; set; }
}
