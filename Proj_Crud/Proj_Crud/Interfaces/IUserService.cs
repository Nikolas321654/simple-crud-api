namespace Proj_Crud.Interfaces;

using Proj_Crud.Model;

public interface IUserService
{
    public List<User> GetAllUsers();
    public void AddUser(User user);
    public User GetUserById(Guid id);
    public void DeleteUser(Guid id);
    public void UpdateUser(User newUserData, Guid id);
}