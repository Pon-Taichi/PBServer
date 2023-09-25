using Microsoft.AspNetCore.Mvc;
using PBServer.Dto;
using PBServer.Entities;

namespace PBServer.Controllers;

[ApiController]
[Route("api/projects")]
[Consumes("application/json")]
[Produces("application/json")]
public class ProjectController : ControllerBase
{
  private readonly IProjectService _projectService;

  public ProjectController(IProjectService projectService)
  {
    _projectService = projectService;
  }

  [HttpGet]
  [ProducesResponseType(200)]
  public async Task<ActionResult<IEnumerable<ProjectEntity>>> GetProjectList()
  {
    return Ok(await _projectService.GetProjects());
  }

  [HttpPost("/{id}/users")]
  [ProducesResponseType(201)]
  public async Task<ActionResult> AddUsersInProject([FromRoute] int id, [FromBody] ProjectUsersDto dto)
  {
    await _projectService.AddUsersInProject(id, dto);
    var uri = HttpContext.Request.Path;
    return Created(uri, null);
  }
}