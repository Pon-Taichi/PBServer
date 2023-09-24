using Microsoft.EntityFrameworkCore;
using PBServer.Entities;

namespace PBServer.Utils;

public class PbContext : DbContext
{
  public PbContext(DbContextOptions<PbContext> options) : base(options)
  {
  }

  public DbSet<ProjectEntity> ProjectEntities { get; set; }
  public DbSet<UserEntity> UserEntities { get; set; }
  public DbSet<ProjectUserEntity> ProjectUserEntities { get; set; }
}