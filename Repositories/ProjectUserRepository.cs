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

  public async Task AddUsersInProject(ICollection<ProjectUserEntity> users)
  {
    await _context.ProjectUserEntities.AddRangeAsync(users);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteUsersInProject(int id)
  {
    var projUserEntities = await _context.ProjectUserEntities.Where(e => e.ProjectId == id).ToListAsync()
      ?? throw new KeyNotFoundException();
    _context.ProjectUserEntities.RemoveRange(projUserEntities);
  }
}