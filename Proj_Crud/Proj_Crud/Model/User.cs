namespace Proj_Crud.Model;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = String.Empty;
    public int Age { get; set; }
    public List<string> Hobbies { get; set; } = new();

    public User()
    {
        Id = Guid.NewGuid();
    }
}