namespace HttpClients.ClientInterfaces;

using Shared.DTOs;
using Shared.Models;

public interface ITodoService
{
    Task CreateAsync(TodoCreationDto dto);
}