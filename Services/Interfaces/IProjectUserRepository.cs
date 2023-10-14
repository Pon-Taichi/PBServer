using PBServer.Entities;

namespace PBServer.Services.Interfaces;

public interface IProjectUserRepository
{
  void AddUsersInProject(ICollection<ProjectUserEntity> users);
  void DeleteUsersInProject(int id);
}
