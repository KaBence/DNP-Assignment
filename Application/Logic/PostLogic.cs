using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTO;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }


    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.OwnerId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OwnerId} was not found.");
        }

        ValidatePost(dto);
        Post todo = new Post(user, dto.Title,dto.Body);
        Post created = await postDao.CreateAsync(todo);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        return postDao.GetByIdAsync(id);
    }

    public async Task DeleteAsync(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post==null)
        {
            throw new Exception($"Post with ID {id} was not found!");
        }

        await postDao.DeleteAsync(id);
    }
    
    private void ValidatePost(Post dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }
}