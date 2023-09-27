using PBServer.Entities;

namespace PBServer.Services.Interfaces;

public interface IUserRepository
{
  Task<ICollection<UserEntity>> GetUsers();
  Task CreateUser(UserEntity user);
}