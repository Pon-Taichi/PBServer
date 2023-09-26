using PBServer.Dto;
using PBServer.Entities;

namespace PBServer.Controllers;

public interface IProjectService
{
  public Task<ICollection<ProjectEntity>> GetProjects();
  public Task<ProjectId> CreateProject(ProjectDto dto);
  public Task AddUsersInProject(int id, ProjectUsersDto dto);
}