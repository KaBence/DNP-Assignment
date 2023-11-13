using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Owner
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    
    public Owner(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
    
    private Owner(){}
}