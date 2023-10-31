using Shared.DTO;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    
    Task<ICollection<Post>> GetAsync(
        string? userName, 
        int? userId, 
        string? titleContains
    );
    
    Task UpdateAsync(PostUpdateDto dto);
    
    Task<Post> GetByIdAsync(int id);
}