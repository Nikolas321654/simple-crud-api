namespace Proj_Crud.Interfaces;
using Proj_Crud.Model;

public interface IUserService
{
    public void AddUser(User user);
    public User GetUserByID(Guid id);
    public void DeleteUser(Guid id);
}
