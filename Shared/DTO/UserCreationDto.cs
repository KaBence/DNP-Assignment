namespace Shared.DTO;

public class UserCreationDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }

    public UserCreationDto()
    {
        
    }

    public UserCreationDto(string userName, string password, string repeatPassword)
    {
        UserName = userName;
        Password = password;
        RepeatPassword = repeatPassword;
    }
}