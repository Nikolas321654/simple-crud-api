using System.Net;
using Microsoft.AspNetCore.Mvc;
using Proj_Crud.Model;
using Proj_Crud.Helpers;
using Proj_Crud.Interfaces;


namespace Proj_Crud.Controller;

[Route("/api/[controller]")]
[ApiController]

public class UsersController : ControllerBase
{
  private readonly UsersStorage _usersStorage;
  private readonly IUserService _usersInterface;

  public UsersController(UsersStorage usersStorage, IUserService usersInterface)
  {
    _usersStorage = usersStorage;
    _usersInterface = usersInterface;
  }
  
  [HttpGet]
  public IActionResult GetAllUsers()
  {
    return Ok(_usersStorage.Users);
  }

  [HttpGet("{userId}")]
  public IActionResult GetUser(Guid userId)
  {
      try
      {
          var user = _usersInterface.GetUserByID(userId);
          return Ok(user);
      }

      catch (NotFoundException ex)
      {
          Console.WriteLine(ex.Message);
          return NotFound(ex.Message);
      }
  }

  [HttpPost]
  public IActionResult CreateUser([FromBody] User user)
  {
      try
      {
          _usersInterface.AddUser(user);
          return Created("", user);
      }
      catch (Exception ex)
      {
          Console.WriteLine("Add user failed");
          return BadRequest(ex.Message);
      }
  }

  [HttpDelete("{userId}")]
  public IActionResult DeleteUser(Guid userId)
  {
      try
      {
        _usersInterface.DeleteUser(userId);
        return NoContent();
      }
      catch (Exception ex)
      {
          Console.WriteLine(ex.Message);
          return StatusCode(404);
      }
  }
}