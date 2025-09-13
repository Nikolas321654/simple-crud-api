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
    private readonly IUserService _usersInterface;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService usersInterface, ILogger<UsersController> logger)
    {
        _usersInterface = usersInterface;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_usersInterface.GetAllUsers());
    }

    [HttpGet("{userId}")]
    public IActionResult GetUser(Guid userId)
    {
        try
        {
            var user = _usersInterface.GetUserById(userId);
            return Ok(user);
        }

        catch (NotFoundException ex)
        {
            _logger.LogError($"User with ID {userId} not found");
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
            _logger.LogError($"Add user failed, user id: {user.Id}");
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser([FromBody] User newUserData, Guid userId)
    {
        try
        {
            _usersInterface.UpdateUser(newUserData, userId);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Update user failed, user id {userId} not found");
            return NotFound(ex.Message);
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
            _logger.LogError($"Delete user failed, user id {userId} not found");
            return NotFound(ex.Message);
        }
    }
}