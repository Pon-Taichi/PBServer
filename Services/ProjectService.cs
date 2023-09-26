using Microsoft.EntityFrameworkCore;
using PBServer.Controllers;
using PBServer.Dto;
using PBServer.Entities;
using PBServer.Utils;

namespace PBServer.Services;

public class ProjectService : IProjectService
{
  private readonly PbContext _context;
  public ProjectService(PbContext context)
  {
    _context = context;
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

  public async Task<ProjectId> CreateProject(ProjectDto dto)
  {
    using var transaction = await _context.Database.BeginTransactionAsync();
    try
    {
      var projectEntity = new ProjectEntity
      {
        Name = dto.Name,
        Description = dto.Description,
        OwnerId = dto.Owner
      };

      await _context.ProjectEntities.AddAsync(projectEntity);
      await _context.SaveChangesAsync();

      var projUserEntities = new List<ProjectUserEntity>();
      foreach (var userId in dto.Users)
      {
        var entity = new ProjectUserEntity
        {
          ProjectId = projectEntity.Id,
          UserId = userId
        };
        projUserEntities.Add(entity);
      }

      await _context.ProjectUserEntities.AddRangeAsync(projUserEntities);
      await _context.SaveChangesAsync();

      transaction.Commit();

      return new ProjectId { Id = projectEntity.Id };
    }
    catch (Exception)
    {
      await transaction.RollbackAsync();
      throw;
    }
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

    await _context.ProjectUserEntities.AddRangeAsync(entities);
    await _context.SaveChangesAsync();
  }
}