namespace Backend.Models;


public class User
{
    public readonly ulong Id;

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
}