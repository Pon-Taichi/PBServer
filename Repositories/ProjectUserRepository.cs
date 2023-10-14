using Microsoft.EntityFrameworkCore;
using PBServer.Entities;
using PBServer.Services.Interfaces;
using PBServer.Utils;

namespace PBServer.Repositories;

public class ProjectUserRepository : IProjectUserRepository
{
  private readonly PbContext _context;
  public ProjectUserRepository(PbContext context)
  {
    _context = context;
  }

  public void AddUsersInProject(ICollection<ProjectUserEntity> users)
  {
    _context.ProjectUserEntities.AddRangeAsync(users);
    _context.SaveChangesAsync();
  }

  public void DeleteUsersInProject(int id)
  {
    var projUserEntities = _context.ProjectUserEntities.Where(e => e.ProjectId == id).ToList()
      ?? throw new KeyNotFoundException();
    _context.ProjectUserEntities.RemoveRange(projUserEntities);
  }
}