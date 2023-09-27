using Microsoft.EntityFrameworkCore;
using PBServer.Dto;
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

  public async Task<int> CreateProject(ProjectEntity project)
  {
    await _context.ProjectEntities.AddAsync(project);
    await _context.SaveChangesAsync();
    return project.Id;
  }

  public async Task DeleteProjectById(int id)
  {
    var projEntity = await _context.ProjectEntities.FindAsync(id)
        ?? throw new KeyNotFoundException();
    _context.ProjectEntities.Remove(projEntity);
    await _context.SaveChangesAsync();
  }

  public async Task<ProjectEntity?> GetProjectById(int id)
  {
    return await _context.ProjectEntities
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
      .FirstOrDefaultAsync(e => e.Id == id);
  }

  public async Task<ICollection<ProjectEntity>> GetProjects()
  {
    return await _context.ProjectEntities
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
      .ToListAsync();
  }
}