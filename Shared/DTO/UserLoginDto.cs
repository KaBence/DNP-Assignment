namespace Shared.DTO;

public class UserLoginDto
{
    public string Username { get; init; }
    public string Password { get; init; }
    
    //init :  you can only set this values, when the object is created, but not later modify it.
}