using Shared.DTO;
using Shared.Models;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> GetUser(string username, string password);
    Task RegisterUser(UserCreationDto user);
}