using System.Text.Json;

namespace Proj_Crud.Service;
using Proj_Crud.Model;
using Proj_Crud.Interfaces;
using Proj_Crud.Helpers;

public class UserService : IUserService 
{
    private readonly UsersStorage _usersStorage;

    public UserService(UsersStorage usersStorage)
    {
        _usersStorage = usersStorage;
    }

    public User AddUser(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new Exception("Username is null or empty");
        }
        if (user.Age <= 0)
        {
            throw new Exception("Age cannot be less or equal 0");
        }
        
        _usersStorage.Users.Add(user);
        return user;
    }
    
    public User GetUserByID(Guid id)
    {
        var user = _usersStorage.Users.FirstOrDefault(x => x.Id == id);
        if (user == null) throw new NotFoundException("User not found");
        
        return user;
    }
}
