using PBServer.Entities;

namespace PBServer.Services.Interfaces;

public interface IProjectUserRepository
{
  Task AddUsersInProject(ICollection<ProjectUserEntity> users);
  Task DeleteUsersInProject(int id);
}
