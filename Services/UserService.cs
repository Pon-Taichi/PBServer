using PBServer.Controllers;
using PBServer.Entities;
using PBServer.Services.Interfaces;

namespace PBServer.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public ICollection<UserEntity> GetUsers()
  {
    return _userRepository.GetUsers();
  }

  public void CreateUser(UserEntity user)
  {
    _userRepository.CreateUser(user);
  }
}