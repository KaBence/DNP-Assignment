using Application.DaoInterfaces;
using Shared.DTO;
using Shared.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Owner> CreateAsync(Owner owner)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        owner.Id = userId;

        context.Users.Add(owner);
        context.SaveChanges();

        return Task.FromResult(owner);
    }

    public Task<Owner?> GetByUsernameAsync(string userName)
    {
        Owner? existing = context.Users.FirstOrDefault(u =>
            u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Owner>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IEnumerable<Owner> users = context.Users.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            users = context.Users.Where(u => u.UserName.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(users);
    }

    public Task<Owner?> GetByIdAsync(int dtoOwnerId)
    {
        Owner? user = context.Users.FirstOrDefault(u => u.Id == dtoOwnerId);
        return Task.FromResult(user);
    }
}