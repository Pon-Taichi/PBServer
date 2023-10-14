using PBServer.Entities;

namespace PBServer.Services.Interfaces;

public interface IUserRepository
{
  ICollection<UserEntity> GetUsers();
  void CreateUser(UserEntity user);
}