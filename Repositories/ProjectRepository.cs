using Microsoft.EntityFrameworkCore;
using PBServer.Entities;
using PBServer.Services.Interfaces;
using PBServer.Utils;

namespace PBServer.Repositories;

public class ProjectRepository : IProjectRepository
{
  private readonly PbContext _context;
  public ProjectRepository(PbContext context)
  {
    _context = context;
  }

  public int CreateProject(ProjectEntity project)
  {
    _context.ProjectEntities.Add(project);
    _context.SaveChanges();
    return project.Id;
  }

  public void DeleteProjectById(int id)
  {
    var projEntity = _context.ProjectEntities.Find(id)
        ?? throw new KeyNotFoundException();
    _context.ProjectEntities.Remove(projEntity);
    _context.SaveChangesAsync();
  }

  public ProjectEntity? GetProjectById(int id)
  {
    return _context.ProjectEntities
      .Include(e => e.Owner)
      .GroupJoin(
        _context.ProjectUserEntities.Include(e => e.User),
        project => project.Id,
        projUser => projUser.ProjectId,
        (project, projUsers) => new ProjectEntity
        {
          Id = project.Id,
          Name = project.Name,
          Description = project.Description,
          Owner = project.Owner,
          Users = projUsers.Select(e => e.User).ToList()
        }
      )
      .FirstOrDefault(e => e.Id == id);
  }

  public ICollection<ProjectEntity> GetProjects()
  {
    return _context.ProjectEntities
      .Include(e => e.Owner)
      .GroupJoin(
        _context.ProjectUserEntities.Include(e => e.User),
        project => project.Id,
        projUser => projUser.ProjectId,
        (project, projUsers) => new ProjectEntity
        {
          Id = project.Id,
          Name = project.Name,
          Description = project.Description,
          Owner = project.Owner,
          Users = projUsers.Select(e => e.User).ToList()
        }
      )
      .ToList();
  }
}