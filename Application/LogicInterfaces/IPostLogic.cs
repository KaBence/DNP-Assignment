using Shared.DTO;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    Task<Post?> GetByIdAsync(int id);

    
    Task DeleteAsync(int id);
}