namespace Proj_Crud.Model;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int Age { get; set; }
    public List<string> Hobbies { get; set; }
}