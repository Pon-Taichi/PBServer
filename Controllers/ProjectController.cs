using Microsoft.AspNetCore.Mvc;
using PBServer.Entities;

namespace PBServer.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
  private readonly IProjectService _projectService;

  public ProjectController(IProjectService projectService)
  {
    _projectService = projectService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<ProjectEntity>>> GetProjectList()
  {
    return Ok(await _projectService.GetProjects());
  }
}