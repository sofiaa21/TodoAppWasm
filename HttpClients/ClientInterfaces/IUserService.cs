namespace HttpClients.ClientInterfaces;

using Shared.DTOs;

public interface IUserService
{
    Task<User> Create(UserCreationDTO dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
}