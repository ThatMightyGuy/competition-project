namespace Backend.Models;

public class LoginInfo
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}