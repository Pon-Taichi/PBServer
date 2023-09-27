using Microsoft.EntityFrameworkCore;
using PBServer.Controllers;
using PBServer.Entities;
using PBServer.Services.Interfaces;
using PBServer.Utils;

namespace PBServer.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<ICollection<UserEntity>> GetUsers()
  {
    return await _userRepository.GetUsers();
  }

  public async Task CreateUser(UserEntity user)
  {
    await _userRepository.CreateUser(user);
  }
}