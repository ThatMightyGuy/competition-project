namespace Backend.Models;

public class User
{
    public readonly ulong Id;

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public LoginInfo LoginInfo { get; private set; } = new();
}