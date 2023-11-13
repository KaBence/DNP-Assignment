using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DTO;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly PostContext context;

    public UserEfcDao(PostContext context)
    {
        this.context = context;
    }

    public async Task<Owner> CreateAsync(Owner owner)
    {
        EntityEntry<Owner> newUser = await context.Owners.AddAsync(owner);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<Owner?> GetByUsernameAsync(string userName)
    {
        Owner? existing = await context.Owners.FirstOrDefaultAsync(u =>
            u.UserName.ToLower().Equals(userName.ToLower())
        );
        return existing;
    }

    public async Task<IEnumerable<Owner>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IQueryable<Owner> usersQuery = context.Owners.AsQueryable();
        if (searchParameters.UsernameContains != null)
        {
            usersQuery = usersQuery.Where(u => u.UserName.ToLower().Contains(searchParameters.UsernameContains.ToLower()));
        }

        IEnumerable<Owner> result = await usersQuery.ToListAsync();
        return result;
    }

    public async Task<Owner?> GetByIdAsync(int dtoOwnerId)
    {
        Owner? user = await context.Owners.FindAsync(dtoOwnerId);
        return user;
    }
}