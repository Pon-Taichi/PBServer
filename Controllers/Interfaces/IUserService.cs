using PBServer.Entities;

namespace PBServer.Controllers;

public interface IUserService
{
  public ICollection<UserEntity> GetUsers();
  public void CreateUser(UserEntity user);
}