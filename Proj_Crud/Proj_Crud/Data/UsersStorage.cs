namespace Proj_Crud.Model;

public class UsersStorage
{
    public List<User> Users { get; }

    public UsersStorage()
    {
        Users = new List<User>(){ };
    }
}
