﻿namespace Application.DAOInterfaces;

using Shared.DTOs;
using Shared.Models;

public interface ITodoDao
{
    Task<Todo> CreateAsync(Todo todo);
    Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters);
    
     Task UpdateAsync(Todo todo);
    Task<Todo> GetByIdAsync(int id);

    Task DeleteAsync(int id);
}