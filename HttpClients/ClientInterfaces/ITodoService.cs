namespace HttpClients.ClientInterfaces;

using Shared.DTOs;
using Shared.Models;

public interface ITodoService
{
    Task CreateAsync(TodoCreationDto dto);

    Task<ICollection<Todo>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains);
}