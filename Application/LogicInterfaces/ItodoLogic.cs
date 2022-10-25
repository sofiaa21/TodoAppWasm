﻿namespace Application.LogicInterfaces;

using Shared.DTOs;
using Shared.Models;

public interface ITodoLogic
{
    Task<Todo> CreateAsync(TodoCreationDto dto);
    Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters);
    
    Task UpdateAsync(TodoUpdateDto todo);
    Task DeleteAsync(int id);
}