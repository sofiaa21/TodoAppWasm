﻿namespace Application.DAOInterfaces;

using Shared.DTOs;

public interface IUserDAO
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    Task<User?> GetByIdAsync(int id);
}