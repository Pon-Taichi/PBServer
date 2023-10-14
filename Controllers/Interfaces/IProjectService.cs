using PBServer.Dto;
using PBServer.Entities;

namespace PBServer.Controllers;

public interface IProjectService
{
  public ICollection<ProjectEntity> GetProjects();
  public ProjectEntity GetProjectById(int id);
  public ProjectId CreateProject(ProjectDto dto);
  public void AddUsersInProject(int id, ProjectUsersDto dto);
  public void DeleteProjectById(int id);
}