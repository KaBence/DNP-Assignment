using Shared.DTO;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<Owner> CreateAsync(Owner owner);

    Task<Owner?> GetByUsernameAsync(string userName);

    Task<IEnumerable<Owner>> GetAsync(SearchUserParametersDto searchParameters);
    Task<Owner?> GetByIdAsync(int dtoOwnerId);
}