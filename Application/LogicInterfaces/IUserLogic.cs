﻿using Shared.DTO;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);

    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);

    Task<User?> GetByIdAsync(int id);
}