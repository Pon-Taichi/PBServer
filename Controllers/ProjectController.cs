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

  [HttpGet("{id}")]
  [ProducesResponseType(200)]
  public async Task<ActionResult<ProjectEntity>> GetProjectById([FromRoute] int id)
  {
    return Ok(await _projectService.GetProjectById(id));
  }

  [HttpPost]
  [ProducesResponseType(201)]
  public async Task<ActionResult<ProjectDto>> CreateProject([FromBody] ProjectDto dto)
  {
    var resBody = await _projectService.CreateProject(dto);
    var uri = HttpContext.Request.Path.Add(new PathString($"/{resBody.Id}"));
    return Created(uri, resBody);
  }

  [HttpPost("{id}/users")]
  [ProducesResponseType(201)]
  public async Task<ActionResult> AddUsersInProject([FromRoute] int id, [FromBody] ProjectUsersDto dto)
  {
    await _projectService.AddUsersInProject(id, dto);
    var uri = HttpContext.Request.Path;
    return Created(uri, null);
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  public async Task<ActionResult> DeleteProjectById([FromRoute] int id)
  {
    try
    {
      await _projectService.DeleteProjectById(id);
      return NoContent();
    }
    catch (KeyNotFoundException)
    {
      return NotFound(id);
    }
  }
}