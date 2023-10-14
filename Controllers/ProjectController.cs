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
  public ActionResult<IEnumerable<ProjectEntity>> GetProjectList()
  {
    return Ok(_projectService.GetProjects());
  }

  [HttpGet("{id}")]
  [ProducesResponseType(200)]
  public ActionResult<ProjectEntity> GetProjectById([FromRoute] int id)
  {
    return Ok(_projectService.GetProjectById(id));
  }

  [HttpPost]
  [ProducesResponseType(201)]
  public ActionResult<ProjectDto> CreateProject([FromBody] ProjectDto dto)
  {
    var resBody = _projectService.CreateProject(dto);
    var uri = HttpContext.Request.Path.Add(new PathString($"/{resBody.Id}"));
    return Created(uri, resBody);
  }

  [HttpPost("{id}/users")]
  [ProducesResponseType(201)]
  public ActionResult AddUsersInProject([FromRoute] int id, [FromBody] ProjectUsersDto dto)
  {
    _projectService.AddUsersInProject(id, dto);
    var uri = HttpContext.Request.Path;
    return Created(uri, null);
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  public ActionResult DeleteProjectById([FromRoute] int id)
  {
    try
    {
      _projectService.DeleteProjectById(id);
      return NoContent();
    }
    catch (KeyNotFoundException)
    {
      return NotFound(id);
    }
  }
}