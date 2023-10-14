using PBServer.Context;
using PBServer.Controllers;
using PBServer.Dto;
using PBServer.Entities;
using PBServer.Services.Interfaces;

namespace PBServer.Services;

public class ProjectService : IProjectService
{
  private readonly IContextProvider _context;
  private readonly IProjectRepository _projectRepository;
  private readonly IProjectUserRepository _projUserRepository;
  public ProjectService(IProjectRepository projectRepository, IProjectUserRepository projUserRepository, IContextProvider context)
  {
    _context = context;
    _projectRepository = projectRepository;
    _projUserRepository = projUserRepository;
  }

  public ICollection<ProjectEntity> GetProjects()
  {
    return _projectRepository.GetProjects();
  }

  public ProjectEntity GetProjectById(int id)
  {
    return _projectRepository.GetProjectById(id)
      ?? throw new KeyNotFoundException();
  }

  public ProjectId CreateProject(ProjectDto dto)
  {
    var projectEntity = new ProjectEntity
    {
      Name = dto.Name,
      Description = dto.Description,
      OwnerId = dto.Owner
    };
    var result = _projectRepository.CreateProject(projectEntity);
    return new ProjectId { Id = result };
  }

  public void AddUsersInProject(int id, ProjectUsersDto dto)
  {
    var entities = new List<ProjectUserEntity>();

    foreach (var userId in dto.Users)
    {
      var entity = new ProjectUserEntity
      {
        ProjectId = id,
        UserId = userId
      };
      entities.Add(entity);
    }
    _projUserRepository.AddUsersInProject(entities);
  }

  public void DeleteProjectById(int id)
  {
    _projUserRepository.DeleteUsersInProject(id);
    _projectRepository.DeleteProjectById(id);
  }
}