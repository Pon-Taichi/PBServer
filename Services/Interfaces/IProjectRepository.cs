using PBServer.Entities;

namespace PBServer.Services.Interfaces;

public interface IProjectRepository
{
  ICollection<ProjectEntity> GetProjects();
  ProjectEntity? GetProjectById(int id);
  int CreateProject(ProjectEntity project);
  void DeleteProjectById(int id);
}