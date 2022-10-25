namespace Application.Logic;

using DAOInterfaces;
using LogicInterfaces;
using Shared.DTOs;

public class UserLogic:IUserLogic
{
    private readonly IUserDAO userDAO;

    public UserLogic(IUserDAO userDao)
    {
        userDAO = userDao;
    }
    

    public async Task<User> CreateAsync(UserCreationDTO dto)
    {
        User? user = await userDAO.GetByUsernameAsync(dto.UserName);
        if (user != null)
            throw new Exception("Username already taken");
        
        ValidateData(dto);

        User userToBeCreated = new User()
        {
            UserName = dto.UserName
        };

        User createdUser = await userDAO.CreateAsync(userToBeCreated);
        return createdUser;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParameters)
    {
        return userDAO.GetAsync(searchUserParameters);
    }


    private static void ValidateData(UserCreationDTO dto)
    {
        string userName = dto.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
    
    
}