using Shared.DTO;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<Owner> CreateAsync(UserCreationDto userToCreate);

    Task<IEnumerable<Owner>> GetAsync(SearchUserParametersDto searchParameters);

    Task<Owner?> GetByIdAsync(int id);
}