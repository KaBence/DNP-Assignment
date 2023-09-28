using Shared.DTO;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    Task<Post?> GetByIdAsync(int id);

    Task UpdateAsync(Post post);
    
    Task DeleteAsync(int id);
}