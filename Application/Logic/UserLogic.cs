using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTO;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<Owner> CreateAsync(UserCreationDto userToCreate)
    {
        Owner? existing = await userDao.GetByUsernameAsync(userToCreate.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(userToCreate);

        Owner toCreate = new Owner(userToCreate.UserName, userToCreate.Password);

        Owner created = await userDao.CreateAsync(toCreate);

        return created;
    }

    public Task<IEnumerable<Owner>> GetAsync(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }

    public Task<Owner?> GetByIdAsync(int id)
    {
        return userDao.GetByIdAsync(id);
    }
    
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}