using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Shared.DTO;
using Shared.Models;

namespace WebAPI.Services;

public class AuthService:IAuthService
{
    private readonly IUserDao userDao;
    

    public AuthService(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<Owner> GetUser(string username, string password)
    {
        Owner? existingUser = await userDao.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }
        //because the return type is Task<User>, but the method is not marked async. In that case, we need to take the return variable and put into a Task manually.
        return existingUser;
    }

    public async Task RegisterUser(UserCreationDto user)
    {
        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        Owner? temp = await userDao.GetByUsernameAsync(user.UserName);
        if (!string.IsNullOrEmpty(temp?.UserName))
        {
            throw new ValidationException("Username already exists");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        if (!user.Password.Equals(user.RepeatPassword))
        {
            throw new ValidationException("The Passwords doesn't match");
        }
        
        
        // Do more user info validation here
        
        // save to persistence instead of list

        await userDao.CreateAsync(new Owner(user.UserName,user.Password));
        //Then Task.CompletedTask is return, the equivalent of void, when working with Task return types.
    }
}