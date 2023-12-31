using Microsoft.AspNetCore.Mvc;
using PBServer.Entities;

namespace PBServer.Controllers;

[ApiController]
[Route("api/users")]
[Consumes("application/json")]
[Produces("application/json")]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;
  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  [ProducesResponseType(200)]
  public ActionResult<UserEntity> GetUsers()
  {
    return Ok(_userService.GetUsers());
  }

  [HttpPost]
  [ProducesResponseType(201)]
  public ActionResult CreateUser([FromBody] UserEntity user)
  {
    // TODO: 認証サービスでidの整合性チェック

    _userService.CreateUser(user);
    var uri = HttpContext.Request.Path.Add(new PathString($"/{user.UserId}"));
    return Created(uri, null);
  }
}