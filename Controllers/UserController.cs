using Microsoft.AspNetCore.Mvc;
using PBServer.Entities;
using PBServer.Services;

namespace PBServer.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
  private IUserService _userService;
  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public async Task<ActionResult<UserEntity>> GetUsers()
  {
    return Ok(await _userService.GetUsers());
  }

  [HttpPost]
  public async Task<ActionResult> CreateUser([FromBody] UserEntity user)
  {
    // TODO: 認証サービスでidの整合性チェック

    await _userService.CreateUser(user);
    var uri = HttpContext.Request.Path.Add(new PathString($"/{user.UserId}"));
    return Created(uri, null);
  }
}