using Application.DaoInterfaces;
using Shared.DTO;
using Shared.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;
        
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IEnumerable<Post> todos = context.Posts.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            todos = context.Posts.Where(todo => todo.Owner.UserName.Equals(searchParameters.Username));
        }

        if (searchParameters.UserId!=null)
        {
            todos = todos.Where(todo => todo.Id == searchParameters.UserId);
        }

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            todos = todos.Where(todo => todo.Title.Contains(searchParameters.TitleContains));
        }

        return Task.FromResult(todos);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? post = context.Posts.FirstOrDefault(post => post.Id == id);
        return Task.FromResult(post);
    }

    public Task UpdateAsync(Post post)
    {
        Post? existing = context.Posts.FirstOrDefault(x => x.Id == post.Id);
        if (existing==null)
        {
            throw new Exception($"There is no post with this Id {post.Id}");
        }

        context.Posts.Remove(existing);
        context.Posts.Add(post);
        context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(x => x.Id == id);
        if (existing==null)
        {
            throw new Exception($"There is no post with this Id {id}");
        }

        context.Posts.Remove(existing);
        context.SaveChanges();
        return Task.CompletedTask;
    }
}