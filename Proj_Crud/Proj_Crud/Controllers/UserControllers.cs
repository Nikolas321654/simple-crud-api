using Microsoft.AspNetCore.Mvc;
using Proj_Crud.Model;

namespace Proj_Crud.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly UsersStorage _usersStorage;

  public UserController(UsersStorage usersStorage)
  {
    _usersStorage = usersStorage;
  }
  
  [HttpGet]
  public IActionResult GetAllUsers()
  {
    return Ok(_usersStorage.Users);
  }
}