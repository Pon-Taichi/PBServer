using PBServer.Entities;

namespace PBServer.Services.Interfaces;

public interface IProjectRepository
{
  Task<ICollection<ProjectEntity>> GetProjects();
  Task<ProjectEntity?> GetProjectById(int id);
  Task<int> CreateProject(ProjectEntity project);
  Task DeleteProjectById(int id);
}