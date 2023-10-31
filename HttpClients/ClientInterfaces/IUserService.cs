using Shared.DTO;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task Register(UserCreationDto dto);
}