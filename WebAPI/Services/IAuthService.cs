using Shared.DTO;
using Shared.Models;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<Owner> GetUser(string username, string password);
    Task RegisterUser(UserCreationDto user);
}