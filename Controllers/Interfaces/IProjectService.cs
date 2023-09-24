using PBServer.Entities;

namespace PBServer.Controllers;

public interface IProjectService
{
  public Task<ICollection<ProjectEntity>> GetProjects();
}