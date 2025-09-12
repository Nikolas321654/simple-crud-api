namespace Proj_Crud.Interfaces;
using Proj_Crud.Model;

public interface IUserService
{
    public User AddUser(User user);
    public User GetUserByID(Guid id);
}