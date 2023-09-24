using PBServer.Entities;

namespace PBServer.Controllers;

public interface IUserService
{
  public Task<ICollection<UserEntity>> GetUsers();
  public Task CreateUser(UserEntity user);
}