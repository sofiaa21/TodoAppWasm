namespace Application.LogicInterfaces;

using Shared.DTOs;
using Shared.Models;

public interface IUserLogic
{
    //type is Task because we may want to do some stuff asynchornously
    Task<User> CreateAsync(UserCreationDTO userToCreate);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParametersDto);
}