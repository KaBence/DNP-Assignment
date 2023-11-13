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
        Owner? user = await userDao.GetByUsernameAsync(dto.Owner);
        if (user == null)
        {
            throw new Exception($"User with {dto.Owner} was not found.");
        }

        ValidatePost(dto);
        Post todo = new Post(user.Id, dto.Title,dto.Body);
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

    public async Task UpdateAsync(PostUpdateDto dto)
    {
        
        Post? existing = await postDao.GetByIdAsync(dto.Id);

        if (existing == null)
        {
            throw new Exception($"Post with ID {dto.Id} not found!");
        }

        if (dto.Comment.Body==null)
        {
            throw new Exception("If you want to leave a comment say something!");
        }
        
        existing.Comments.Add(dto.Comment);

        Post updated = new(existing.Owner.Id, existing.Title,existing.Body)
        {
            Id = existing.Id,
            Comments=existing.Comments
        };

        ValidatePost(updated);

        await postDao.UpdateAsync(updated);
    }

    private void ValidatePost(Post dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Body cannot be empty");
        // other validation stuff
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Body cannot be empty");
        // other validation stuff
    }
}