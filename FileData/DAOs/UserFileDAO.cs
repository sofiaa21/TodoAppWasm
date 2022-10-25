namespace FileData.DAOs;

using System.Collections;
using System.Reflection.Metadata;
using Application.DAOInterfaces;
using Shared.DTOs;

public class UserFileDAO : IUserDAO
{
    private readonly FileContext context;

    public UserFileDAO(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }


    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existingUser =
            context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        //the StringComparison just checks for uppercase
        return Task.FromResult(existingUser);
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();

            users = context.Users.Where(u =>
                u.UserName.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        
        return Task.FromResult(users);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Id == id
        );
        return Task.FromResult(existing);
    }
    //We then check if the search parameter is not null, in which case we want to apply it.
    // We do that in line 6 with the Where() method, which goes through all the users,
    // and selects those that matches the criteria specified by the lambda expression.
}