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

  public async Task<ICollection<ProjectEntity>> GetProjects()
  {
    return await _projectRepository.GetProjects();
  }

  public async Task<ProjectEntity> GetProjectById(int id)
  {
    return await _projectRepository.GetProjectById(id)
      ?? throw new KeyNotFoundException();
  }

  public async Task<ProjectId> CreateProject(ProjectDto dto)
  {
    var projectEntity = new ProjectEntity
    {
      Name = dto.Name,
      Description = dto.Description,
      OwnerId = dto.Owner
    };
    var result = await _projectRepository.CreateProject(projectEntity);
    return new ProjectId { Id = result };
  }

  public async Task AddUsersInProject(int id, ProjectUsersDto dto)
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
    await _projUserRepository.AddUsersInProject(entities);
  }

  public async Task DeleteProjectById(int id)
  {
    await _projUserRepository.DeleteUsersInProject(id);
    await _projectRepository.DeleteProjectById(id);
  }
}